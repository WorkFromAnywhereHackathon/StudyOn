namespace Telegram.Bot.Examples.Echo
{
    public static class Configuration
    {
        public readonly static string BotToken = "1743101867:AAGqsl5cZfm544or-5HC8xVE-Pv_IaltlA8";

#if USE_PROXY
        public static class Proxy
        {
            public readonly static string Host = "{PROXY_ADDRESS}";
            public readonly static int Port = 8080;
        }
#endif
    }
}