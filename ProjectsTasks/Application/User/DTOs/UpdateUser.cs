namespace ProjectsTasks.Application.User.DTOs
{
    public record UpdateUser(int Id, string Name, string Email, string Password)
    {
        public static UpdateUser With(int Id, string Name, string Email, string Password)
        {
            return new UpdateUser(Id, Name, Email, Password);
        }
    }
}
