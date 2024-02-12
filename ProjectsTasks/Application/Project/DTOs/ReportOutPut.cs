namespace ProjectsTasks.Application.Project.DTOs
{
    public record ReportOutPut(string user, double avarege)
    {
        public static ReportOutPut With(string user, double avarage)
        {
            return new ReportOutPut(user, avarage);
        }
    }
}
