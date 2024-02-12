namespace ProjectsTasks.Application.Task
{
    public record ChangeDescriptionInput(string  description)
    {
        public static ChangeDescriptionInput With(string description)
        {
            return new ChangeDescriptionInput(description);
        }
    }
}
