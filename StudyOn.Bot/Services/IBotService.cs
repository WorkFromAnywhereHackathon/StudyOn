﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace StudyOn.Bot.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}
