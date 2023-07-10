using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

public class FileDownloader
{
    private const int MaxConcurrentDownloads = 4; // 设置最大并发下载数
    private List<Task> _downloadTasks;

    public FileDownloader()
    {
        _downloadTasks = new List<Task>();
    }

    public void DownloadFile(string url, string saveDirectory, string fileName)
    {
        // 创建Web请求
        var webRequest = (HttpWebRequest)WebRequest.Create(url);
        webRequest.Method = "HEAD";

        // 获取文件大小
        long fileSize;
        using (var response = webRequest.GetResponse())
        {
            var contentLength = response.Headers.Get("Content-Length");
            fileSize = Convert.ToInt64(contentLength);
        }

        // 计算每个线程需要下载的字节数
        long chunkSize = fileSize / MaxConcurrentDownloads;

        // 启动多个下载任务
        for (int i = 0; i < MaxConcurrentDownloads; i++)
        {
            long startByte = i * chunkSize;
            long endByte = (i == MaxConcurrentDownloads - 1) ? fileSize - 1 : (i + 1) * chunkSize - 1;

            _downloadTasks.Add(DownloadChunk(url, saveDirectory, fileName, startByte, endByte));
        }

        // 等待所有下载任务完成
        Task.WhenAll(_downloadTasks).Wait();

        Console.WriteLine("下载完成！");
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
