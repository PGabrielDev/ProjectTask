namespace ProjectsTasks.Application
{
    public interface UseCase<IN, OUT>
    {
        public abstract OUT Execute(IN input);
    }
}
