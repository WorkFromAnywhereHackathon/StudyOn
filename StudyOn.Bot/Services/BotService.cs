using Microsoft.Extensions.Options;
using StudyOn.Bot.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace StudyOn.Bot.Services
{
    public class BotService : IBotService
    {
        private readonly BotOptions _config;

        public BotService(IOptions<BotOptions> config)
        {
            _config = config.Value;
            // use proxy if configured in appsettings.*.json
            Client = new TelegramBotClient(_config.BotToken);
            //Client = string.IsNullOrEmpty(_config.Socks5Host)
            //    ? new TelegramBotClient(_config.BotToken)
            //    : new TelegramBotClient(
            //        _config.BotToken,
            //        new HttpToSocks5Proxy(_config.Socks5Host, _config.Socks5Port));
        }

        public TelegramBotClient Client { get; }
    }
}
