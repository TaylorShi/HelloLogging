## ASP.NET Core日志框架

ASP.NET Core提供了独立的日志模型，采用统一的API来完成日志的记录，支持各种内置日志记录器（如：Console、Debug、EventSource、EventLog、TraceSource等）和第三方日志框架（如：Log4Net、NLog、Loggr、Serilog、Sentry等），同时基于日志模型的扩展性，也可自定义更多的日志记录器。

ASP.NET Core日志框架的核心组件包是如下几个：

- Microsoft.Extensions.Logging
- Microsoft.Extensions.Logging.Console
- Microsoft.Extensions.Logging.Debug
- Microsoft.Extensions.Logging.TraceSource

## 相关文章

* [乘风破浪，遇见最佳跨平台跨终端框架.Net Core/.Net生态 - 浅析ASP.NET Core日志框架，通过Serilog来记录结构化日志](https://www.cnblogs.com/taylorshi/p/16749885.html)