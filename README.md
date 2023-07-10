# File Downloader

[Chinese](./README_CN.md)

![GitHub](https://img.shields.io/github/license/Grey-Wind/FileDownloader.svg?style=flat-square)

This document provides detailed instructions and sample code for using the File Downloader library.

## Introduction

The File Downloader library provides a simple yet powerful way to download files. You can use this library to download any number of files and save them in the specified path.

## Features

- Supports sequential downloading of multiple files.
- Provides a simple interface to manage download operations.
- Allows customizing the save path and file names.
- Supports resumable downloads to avoid re-downloading already downloaded parts.

## Installation

You can install the File Downloader library by following these steps:

Compile from source code:

```bash
git clone https://github.com/Grey-Wind/FileDownloader.git
cd FileDownloader
dotnet build
```

## Usage Example

The following example demonstrates how to use the File Downloader library to download files:

```csharp
using FileDownloader;

// Create a downloader object
Downloader downloader = new Downloader();

// Prepare URLs and save paths for files to be downloaded
string[] urls = {
   "http://www.example.com/file1.txt",
   "http://www.example.com/file2.txt",
   "http://www.example.com/file3.txt"
};

string[] savePaths = {
   "C:\\Downloads\\file1.txt",
   "C:\\Downloads\\file2.txt",
   "C:\\Downloads\\file3.txt"
};

// Call the DownloadFiles method of the downloader to sequentially download multiple files
downloader.DownloadFiles(urls, savePaths);
```

Make sure to keep the lengths of the `urls` and `savePaths` arrays consistent and ensure that each URL corresponds to the correct save path.

After running the above example code, the files will be downloaded sequentially to the specified save paths.

## License

This project is licensed under GNU GPL v3. For detailed license information, please refer to the [LICENSE](./LICENSE) file.

## Contribution

You are welcome to contribute to this project! If you would like to contribute code or report issues, please check the [Contribution Guidelines](./CONTRIBUTING.md)(Forgot to write).

## FAQ

### Q: How to handle errors and exceptions during the download process?

A: You can use try-catch blocks to catch and handle exceptions that occur during the download process. You can handle error situations appropriately by logging, outputting error messages, or sending notifications.

### Q: Does it support concurrent downloads?

A: The current File Downloader library downloads files sequentially and does not directly support concurrent downloads. However, you can extend the library according to your needs to support concurrent downloads.

## More Information

- API Documentation: Please refer to the [API Documentation](./API.md)(Forgot to write) for more information about the File Downloader class.

If you need further information about the functionality and usage of the File Downloader library, please refer to the API documentation.

If you have any other questions, feel free to ask or submit an issue on GitHub.