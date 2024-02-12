namespace ProjectsTasks.Infrastruct.Database.Exceptions
{
    public class LimitTaskException : Exception
    {
        public LimitTaskException() : base("Limite máximo de tarefas excedido. O limite é 20 tarefas") { }
    }
}
