using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace demoForConsole31.Services
{
    public class OrderService
    {
        ILogger<OrderService> _logger;
        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }

        public void Show()
        {
            // 使用模板
            _logger.LogInformation("Show Now Time: {time}", DateTime.Now);
            // 不使用模板
            _logger.LogInformation($"Show Now Time: {DateTime.Now}");
        }
    }
}
