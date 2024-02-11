namespace ProjectsTasks.Application.Project
{
    public record CreateProjectInput(string ProjectName, string Description, string email)
    {
        public static CreateProjectInput With(string ProjectName, string Description, string email)
        {
            return new CreateProjectInput(ProjectName, Description, email);
        }
    }
}
