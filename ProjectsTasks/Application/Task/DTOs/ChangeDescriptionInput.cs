namespace ProjectsTasks.Application.Task.DTOs
{
    public record ChangeDescriptionInput(string description)
    {
        public static ChangeDescriptionInput With(string description)
        {
            return new ChangeDescriptionInput(description);
        }
    }
}
