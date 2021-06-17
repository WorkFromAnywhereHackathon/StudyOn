using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace StudyOn.Bot.Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update, ITelegramBotClient bot);
    }
}
