namespace ProjectsTasks.Application
{
    public interface NullaryUseCase<OUT>
    {
        public abstract OUT Execute();
    }
}
