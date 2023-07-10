# File Downloader

![GitHub](https://img.shields.io/github/license/Grey-Wind/FileDownloader.svg?style=flat-square)

本文档提供了使用下载器类库的详细说明和示例代码。

## 简介

该下载器类库提供了一个简单而强大的方式来下载文件。您可以使用该类库来下载任意数量的文件，并按照顺序将它们保存到指定的路径中。

## 特点

- 支持按顺序下载多个文件。
- 提供了简单的接口来管理下载操作。
- 可以自定义保存路径和文件名。
- 支持断点续传，避免重复下载已下载的部分。

## 安装

您可以通过以下方式安装下载器类库：

从源代码编译：

```bash
git clone https://github.com/Grey-Wind/FileDownloader.git
cd FileDownloader
dotnet build
```

## 使用示例

以下示例演示了如何使用下载器类库下载文件：

```c#
using FileDownloader;

// 创建下载器对象
Downloader downloader = new Downloader();

// 准备要下载的文件的 URL 和保存路径
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

// 调用下载器的 DownloadFiles 方法来顺序下载多个文件
downloader.DownloadFiles(urls, savePaths);
```

确保将 `urls` 和 `savePaths` 数组的长度保持一致，并且每个位置的 URL 对应正确的保存路径。

运行以上示例代码后，文件将按照顺序依次下载到指定的保存路径中。

## 许可证

该项目基于 GNU GPL v3 许可证。详细的许可证内容请参阅 [LICENSE](./LICENSE) 文件。

## 贡献

欢迎您为该项目做出贡献！如果您希望贡献代码或报告问题，请查阅 [贡献指南](./CONTRIBUTING.md)（忘写了）。

## 常见问题解答

### 问题 1

问：如何处理下载过程中的错误和异常？

答：您可以使用 `try-catch` 块捕获并处理下载过程中的异常。可以通过记录日志、输出错误信息或发送通知来适当地处理错误情况。

### 问题 2

问：是否支持并发下载？

答：目前的下载器类库是按顺序下载文件的，不直接支持并发下载。但是，您可以根据自己的需求扩展该类库，以支持并发下载。

## 更多信息

- API 文档：请参阅 [API 文档](./API.md) （也没写）了解更多关于下载器类的信息。

如果您需要进一步了解下载器类库的功能和使用方法，请参考 API 文档。

如有任何其他问题，请随时提问或在 GitHub 上提交问题。