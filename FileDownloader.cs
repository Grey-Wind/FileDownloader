using System;
using System.Net;

namespace FileDownloader
{
    public class Downloader
    {
        public void DownloadFiles(string[] urls, string[] savePaths)
        {
            if (urls.Length != savePaths.Length)
            {
                throw new ArgumentException("URL 数量必须与保存路径数量相匹配。");
            }

            for (int i = 0; i < urls.Length; i++)
            {
                DownloadFile(urls[i], savePaths[i]);
            }
        }

        private void DownloadFile(string url, string savePath)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, savePath);
                Console.WriteLine($"文件 \"{savePath}\" 下载成功！");
            }
        }
    }
}
