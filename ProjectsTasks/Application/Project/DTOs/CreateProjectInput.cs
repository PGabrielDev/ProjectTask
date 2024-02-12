namespace ProjectsTasks.Application.Project
{
    public record CreateProjectInput(string ProjectName, string Description)
    {
        public static CreateProjectInput With(string ProjectName, string Description)
        {
            return new CreateProjectInput(ProjectName, Description);
        }
    }
}
