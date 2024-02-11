namespace ProjectsTasks.Application.User
{
    public record CreateUserOutput(int Id, string Name, string Email)
    {
        public static CreateUserOutput With (int Id, string Name, string Email)
        {
            return new CreateUserOutput (Id, Name, Email);
        }
    }
}
