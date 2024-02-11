namespace ProjectsTasks.Application.User
{
    public record CreateUserInput(string Name, string Email, string Password)
    {
        public static CreateUser With(CreateUserInput input, ICollection<RoleInput> roles)
        {
            return CreateUser.With(input.Name,input.Email,input.Password, roles);
        }
    }
}
