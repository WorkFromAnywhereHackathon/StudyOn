using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace StudyOn.Bot.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ILogger<UpdateService> _logger;
        private readonly IMeetingService _meetingService;
        private readonly ITeamService _teamService;
        private readonly IExpertService _expertService;

        public UpdateService(IBotService botService,
            ILogger<UpdateService> logger,
            IMeetingService scheduleService,
            ITeamService teamService,
            IExpertService expertService)
        {
            _botService = botService;
            _logger = logger;
            _meetingService = scheduleService ?? throw new System.ArgumentNullException(nameof(scheduleService));
            _teamService = teamService ?? throw new System.ArgumentNullException(nameof(teamService));
            _expertService = expertService ?? throw new System.ArgumentNullException(nameof(expertService));
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message || update.Message.Type != MessageType.Text)
                return;

            var message = update.Message;

            _logger.LogInformation("Received Message from {0}", message.Chat.Id);
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
                await _botService.Client.SendTextMessageAsync(
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
                sb.AppendLine($"{expert.Name}");
                sb.AppendLine($"{expert.Description}");
                sb.AppendLine($"{expert.Photo}");
                sb.AppendLine();
            }

            var text = sb.ToString();
            if (string.IsNullOrEmpty(text))
                return;

            await _botService.Client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                parseMode: ParseMode.Default,
                text: sb.ToString()
            );
        }

        private async Task Teams(Message message)
        {

            var teams = await _teamService.GetAsync();
            var sb = new StringBuilder();
            foreach (var team in teams)
            {
                sb.AppendLine($"{team.Name}");
                sb.AppendLine($"{team.Description}");
                sb.AppendLine($"{team.PassportLink}");
                sb.AppendLine();
            }

            var text = sb.ToString();
            if (string.IsNullOrEmpty(text))
                return;

            await _botService.Client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                parseMode: ParseMode.Default,
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
                foreach (var meeting in meetings)
                {
                    sb.AppendLine($"{meeting.StartTime.ToShortTimeString()}-{meeting.EndTime.ToShortTimeString()} - {meeting.Name} ");
                }              

                await _botService.Client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: sb.ToString(),
                    replyMarkup: MeetingKeyboard()
                ); ;
            }

            if (text == "Следующее событие")
            {
                var meeting = await _meetingService.GetNextAsync();

                var sb = new StringBuilder();
                if (meeting == null)
                {
                    sb.AppendLine("Больше мероприятий не запланировано");
                }
                else
                {
                    sb.AppendLine($"{meeting.StartTime.ToShortTimeString()}-{meeting.EndTime.ToShortTimeString()} - {meeting.Name} ");
                }

                await _botService.Client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: sb.ToString(),
                    replyMarkup: MeetingKeyboard()
                ); ;
            }

            if (text == "Расписание на сегодня")
            {
                var meetings = await _meetingService.GetTodayAsync();
                var sb = new StringBuilder();
                foreach (var meeting in meetings)
                {
                    sb.AppendLine($"{meeting.StartTime.ToShortTimeString()}-{meeting.EndTime.ToShortTimeString()} - {meeting.Name} ");
                }

                await _botService.Client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: sb.ToString(),
                    replyMarkup: MeetingKeyboard()
                ); ;
            }

            if (text == "Расписание")
            {
                await _botService.Client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Расписание",
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
