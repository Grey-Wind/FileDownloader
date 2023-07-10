# File Downloader

`FileDownloader` 类库是一个用于并发下载文件的简单实用工具。它允许您从指定的 URL 下载文件，并提供了控制最大并发下载数的选项。

### 特点

- 支持多线程下载，可同时下载多个文件块以加快下载速度。
- 可通过设置最大并发下载数来控制同时进行的下载线程数量。
- 提供灵活的接口，允许您指定下载文件的 URL、保存目录和文件名。
- 自动处理文件大小，确保下载完整的文件。

### 安装

您可以通过以下方式将 `FileDownloader` 类库集成到您的项目中：

1. 从代码仓库中下载源代码。
2. 将源代码编译为类库文件（DLL）。
3. 将生成的 DLL 文件添加到您的项目中的引用。

### 使用示例

```c#
using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        string url = "https://example.com/file.txt";
        string saveDirectory = "C:\\Downloads";
        string fileName = "file.txt";
        int maxConcurrentDownloads = 4;

        FileDownloader downloader = new FileDownloader();
        await downloader.DownloadFile(url, saveDirectory, fileName, maxConcurrentDownloads);
    }
}
```

在上述示例中，我们创建了一个 `FileDownloader` 实例，并使用 `DownloadFile` 方法下载了指定 URL 的文件。您可以根据需求修改 `url`、`saveDirectory`、`fileName` 和 `maxConcurrentDownloads` 变量来适应您的实际情况。

你可以不使用`maxConcurrentDownloads`参数，默认是4。

------

在一行内使用：
```c#
await new FileDownloader().DownloadFile("https://example.com/file.txt", "C:\\Downloads", "file.txt", 4);
```

### 方法

下面是 `FileDownloader` 类中的主要方法：

- `DownloadFile(string url, string saveDirectory, string fileName, int? maxConcurrentDownloads = null)`: 从给定的 URL 下载文件，并将其保存到指定的目录和文件名中。可选择性地设置最大并发下载数。

### 注意事项

- 在使用 `FileDownloader` 类库时，请确保您具备合法的下载权限和网络连接。
- 对于大型文件或网络条件不佳的情况，建议适当调整最大并发下载数以避免对服务器造成过多负担或导致下载失败。

这是对 `FileDownloader` 类库的详细介绍。您可以根据需要将此类库集成到自己的项目中，以实现高效的并发文件下载功能。祝您使用愉快！