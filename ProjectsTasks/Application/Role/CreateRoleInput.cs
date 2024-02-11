namespace ProjectsTasks.Application.Role
{
    public record CreateRoleInput(string Name)
    {
        public static CreateRoleInput With(string Name)
        {
            return new CreateRoleInput(Name);
        }
    }
}
