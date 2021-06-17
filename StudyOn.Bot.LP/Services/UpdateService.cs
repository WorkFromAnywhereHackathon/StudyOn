using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace StudyOn.Bot.Services
{
    public class UpdateService : IUpdateService
    {

        private readonly IMeetingService _meetingService;
        private readonly ITeamService _teamService;
        private readonly IExpertService _expertService;

        public UpdateService(
            IMeetingService scheduleService,
            ITeamService teamService,
            IExpertService expertService)
        {

            _meetingService = scheduleService ?? throw new System.ArgumentNullException(nameof(scheduleService));
            _teamService = teamService ?? throw new System.ArgumentNullException(nameof(teamService));
            _expertService = expertService ?? throw new System.ArgumentNullException(nameof(expertService));
        }
        ITelegramBotClient _bot;

        public async Task EchoAsync(Update update, ITelegramBotClient bot)
        {
            if (update.Type != UpdateType.Message || update.Message.Type != MessageType.Text)
                return;

            _bot = bot;

            var message = update.Message;
            await SendAnswer(message);
        }

        private async Task SendAnswer(Message message)
        {
            var text = message.Text;

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            if (text == "Назад" || text == "/start")
            {
                await _bot.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "Выберите один из вариантов",
                       replyMarkup: MenuKeyboard()
                   );
                return;
            }

            await Meetings(message);

            if (text == "Команды")
            {
                await Teams(message);
                return;
            }
            if (text == "Эксперты")
            {
                await Experts(message);
            }
        }

        private async Task Experts(Message message)
        {
            var experts = await _expertService.GetAsync();
            var sb = new StringBuilder();
            foreach (var expert in experts)
            {
                sb.AppendLine($"<b>{expert.Name}</b>");
                sb.AppendLine($"{expert.Description}");
                //sb.AppendLine($"{expert.Photo}");
                sb.AppendLine();
            }

            var text = sb.ToString();
            if (string.IsNullOrEmpty(text))
                return;

            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                parseMode: ParseMode.Html,
                text: sb.ToString()
            );
        }

        private async Task Teams(Message message)
        {

            var teams = await _teamService.GetAsync();
            var sb = new StringBuilder();
            foreach (var team in teams)
            {
                sb.AppendLine($"<b>{team.Name}</b>");
                //sb.AppendLine($"{team.Description}");
                sb.AppendLine($"{team.PassportLink}");
                sb.AppendLine();
            }

            var text = sb.ToString();
            if (string.IsNullOrEmpty(text))
                return;

            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                parseMode: ParseMode.Html,
                text: text
            );
        }

        private async Task Meetings(Message message)
        {
            var text = message.Text;
            if (text == "Расписание мероприятия")
            {
                var meetings = await _meetingService.GetAsync();
                var sb = new StringBuilder();
                foreach (var group in meetings.GroupBy(x => x.StartTime.Date))
                {
                    sb.AppendLine($"<b>{group.Key.Date.ToString("D")}</b>");
                    foreach (var meeting in group)
                    {
                        sb.AppendLine($"{meeting.StartTime.ToShortTimeString()}-{meeting.EndTime.ToShortTimeString()} - {meeting.Name} ");
                    }
                    sb.AppendLine();
                }

                await _bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: sb.ToString(),
                     parseMode: ParseMode.Html,
                    replyMarkup: MeetingKeyboard()
                ); ;
            }

            if (text == "Следующее событие")
            {
                var meeting = await _meetingService.GetNextAsync();

                var sb = new StringBuilder();
                if (meeting == null)
                {
                    sb.AppendLine("Все мероприятия прошли");
                }
                else
                {
                    sb.AppendLine($"{meeting.StartTime.ToShortTimeString()}-{meeting.EndTime.ToShortTimeString()} - {meeting.Name} ");
                }

                await _bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: sb.ToString(),
                     parseMode: ParseMode.Html,
                    replyMarkup: MeetingKeyboard()
                ); ;
            }

            if (text == "Расписание на сегодня")
            {
                var meetings = await _meetingService.GetTodayAsync();
                var sb = new StringBuilder();
                if (meetings.Any()==false)
                {
                    sb.AppendLine("Ничего не запланировано");
                }
                foreach (var group in meetings.GroupBy(x => x.StartTime.Date))
                {
                    sb.AppendLine($"<b>{group.Key.Date.ToString("D")}</b>");
                    foreach (var meeting in group)
                    {
                        sb.AppendLine($"{meeting.StartTime.ToShortTimeString()}-{meeting.EndTime.ToShortTimeString()} - {meeting.Name} ");
                    }
                    sb.AppendLine();
                }

                await _bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: sb.ToString(),
                     parseMode: ParseMode.Html,
                    replyMarkup: MeetingKeyboard()
                ); ;
            }

            if (text == "Расписание")
            {
                await _bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Расписание",
                     parseMode: ParseMode.Html,
                    replyMarkup: MeetingKeyboard()
                ); ;
            }
        }

        private static ReplyKeyboardMarkup MenuKeyboard()
        {
            return new ReplyKeyboardMarkup(
                            new KeyboardButton[][]
                            {
                            new KeyboardButton[] { "Расписание"},
                            //new KeyboardButton[] { "/documents "},
                            new KeyboardButton[] { "Команды"},
                            new KeyboardButton[] { "Эксперты"},
                            },
                            resizeKeyboard: true);
        }

        private static ReplyKeyboardMarkup MeetingKeyboard()
        {
            return new ReplyKeyboardMarkup(
                            new KeyboardButton[][]
                            {
                                new KeyboardButton[] { "Расписание мероприятия"},
                                new KeyboardButton[] { "Расписание на сегодня"},
                                new KeyboardButton[] { "Следующее событие"},
                                new KeyboardButton[] { "Назад"},
                            }, resizeKeyboard: true);
        }
    }
}
