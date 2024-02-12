namespace ProjectsTasks.Application.Project
{
    public record CreateProject(string ProjectName, string Description, int UserId)
    {
        public static CreateProject With(string ProjectName, string Description, int UserId)
        {
            return new CreateProject(ProjectName, Description, UserId);
        }
    }
}
 