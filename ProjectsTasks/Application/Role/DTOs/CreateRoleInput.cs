namespace ProjectsTasks.Application.Role.DTOs
{
    public record CreateRoleInput(string Name)
    {
        public static CreateRoleInput With(string Name)
        {
            return new CreateRoleInput(Name);
        }
    }
}
