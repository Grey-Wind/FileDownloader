# File Downloader

[Chinese](./README_CN.md)

The FileDownloader library is a simple utility for concurrent file downloads. It allows you to download files from specified URLs and provides options to control the maximum concurrent downloads.

### Features

- Supports multithreaded downloading, allowing simultaneous downloading of multiple file chunks to speed up the process.
- Provides the flexibility to specify the URL of the file to be downloaded, as well as the save directory and file name.
- Automatically handles file size to ensure the complete download of files.

### Installation

To integrate the FileDownloader library into your project, you can follow these steps:

1. Download the source code from the code repository.
2. Compile the source code into a library file (DLL).
3. Add the generated DLL file as a reference in your project.

### Usage Example

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

In the above example, we create an instance of `FileDownloader` and use the `DownloadFile` method to download the file from the specified URL. You can modify the `url`, `saveDirectory`, `fileName`, and `maxConcurrentDownloads` variables according to your requirements.

You can omit the `maxConcurrentDownloads` parameter, the default value is 4.

------

Use in one line:
```c#
await new FileDownloader().DownloadFile("https://example.com/file.txt", "C:\\Downloads", "file.txt", 4);
```

### Methods

Here are the main methods available in the `FileDownloader` class:

- `DownloadFile(string url, string saveDirectory, string fileName, int? maxConcurrentDownloads = null)`: Downloads a file from the given URL and saves it to the specified directory with the provided file name. The maximum concurrent downloads can be optionally set.

### Notes

- Ensure that you have legal download permissions and a stable network connection when using the FileDownloader library.
- For large files or poor network conditions, it is recommended to adjust the maximum concurrent downloads to avoid excessive server load or download failures.

This concludes the detailed introduction to the `FileDownloader` library. You can integrate this library into your project as per your requirements to achieve efficient concurrent file downloading functionality. Happy downloading!