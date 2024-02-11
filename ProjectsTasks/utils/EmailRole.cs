namespace ProjectsTasks.utils
{
    public record EmailRole(string Email, ICollection<string> Roles)
    {
        public static EmailRole With(string email, ICollection<string> roles)
        {
            return new EmailRole(email, roles);
        }
    }
}
