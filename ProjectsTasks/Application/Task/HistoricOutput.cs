namespace ProjectsTasks.Application.Task
{
    public record HistoricOutput(string alter, string author)
    {
        public static HistoricOutput With(string alter, string author)
        {
            return new HistoricOutput(alter, author);
        }
    }
}
