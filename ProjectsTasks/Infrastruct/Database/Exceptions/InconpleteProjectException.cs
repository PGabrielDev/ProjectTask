namespace ProjectsTasks.Infrastruct.Database.Exceptions
{
    public class IncompleteProjectException : Exception
    {
        public IncompleteProjectException(string message) : base($"Projeto so pode ser excluido quando todas tarefaz estiverem concluidas\n Tarefas a serem concluidas: {message}") { }
    }
}
