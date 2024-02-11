namespace ProjectsTasks.Application.User
{
    public record LoginOutPut(string name, string token)
    {
        public static LoginOutPut With(string name, string token)
        {
            return new LoginOutPut(name, token);
        }
    }
}
