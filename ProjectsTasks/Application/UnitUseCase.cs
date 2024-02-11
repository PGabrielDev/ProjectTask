using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectsTasks.Application
{
    public interface UnitUseCase<IN>
    {
        public abstract void Execute (IN input);
    }
}
