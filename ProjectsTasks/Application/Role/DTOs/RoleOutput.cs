namespace ProjectsTasks.Application.Role.DTOs
{
    public record RoleOutput(int Id, string Name)
    {
        public static RoleOutput With(int Id, string Name)
        {
            return new RoleOutput(Id, Name);
        }
    }
}
