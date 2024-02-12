namespace ProjectsTasks.Application.Task.DTOs
{
    public record CreateTaskInput(int priority, string name, string description)
    {
        public static CreateTaskInput With(int priority, string name, string description)
        {
            return new CreateTaskInput(priority, name, description);
        }


    }
}
