using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

public class FileDownloader
{
    private int _maxConcurrentDownloads;
    private List<Task> _downloadTasks;

    public FileDownloader()
    {
        _maxConcurrentDownloads = 4;
        _downloadTasks = new List<Task>();
    }

    public async Task DownloadFile(string url, string saveDirectory, string fileName, int? maxConcurrentDownloads = null)
    {
        // 检查并发下载数是否合法
        int concurrentDownloads = maxConcurrentDownloads ?? _maxConcurrentDownloads;
        if (concurrentDownloads <= 0)
        {
            throw new ArgumentException("Concurrent downloads must be greater than 0.");
        }

        // 创建Web请求
        var webRequest = (HttpWebRequest)WebRequest.Create(url);
        webRequest.Method = "HEAD";

        // 获取文件大小
        long fileSize;

        using (var response = await webRequest.GetResponseAsync())
        {
            var contentLength = response.Headers.Get("Content-Length");
            fileSize = Convert.ToInt64(contentLength);
        }

        // 计算每个线程需要下载的字节数
        long chunkSize = fileSize / concurrentDownloads;

        // 启动多个下载任务
        for (int i = 0; i < concurrentDownloads; i++)
        {
            long startByte = i * chunkSize;
            long endByte = (i == concurrentDownloads - 1) ? fileSize - 1 : (i + 1) * chunkSize - 1;

            _downloadTasks.Add(DownloadChunk(url, saveDirectory, fileName, startByte, endByte));
        }

        // 等待所有下载任务完成
        await Task.WhenAll(_downloadTasks);
    }

    private async Task DownloadChunk(string url, string saveDirectory, string fileName, long startByte, long endByte)
    {
        var webRequest = (HttpWebRequest)WebRequest.Create(url);
        webRequest.AddRange(startByte, endByte);

        using (var response = await webRequest.GetResponseAsync())
        {
            using (var contentStream = response.GetResponseStream())
            {
                string filePath = Path.Combine(saveDirectory, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await contentStream.CopyToAsync(fileStream);
                }
            }
        }
    }
}
