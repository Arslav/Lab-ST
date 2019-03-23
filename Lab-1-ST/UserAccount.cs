namespace Lab_1_ST
{
    public static class UserAccount
    {
        public static string Database { get; private set; } = "";
        public static string Server { get; private set; } = "";
        public static string Uid { get; private set; } = "";
        public static string Password { get; private set; } = "";
        public static string StrConnection{get; private set; } = $"Server={UserAccount.Server};Database={UserAccount.Database};Uid={UserAccount.Uid};Pwd={UserAccount.Password}";//строка для подключения к БД
    }
}