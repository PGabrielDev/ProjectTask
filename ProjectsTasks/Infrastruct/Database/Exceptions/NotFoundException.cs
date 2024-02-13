namespace ProjectsTasks.Infrastruct.Database.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name) : base($"Entidade {name} não encontrada") { }

    }
}
