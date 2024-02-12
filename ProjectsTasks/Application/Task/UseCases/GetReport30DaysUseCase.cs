using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

namespace ProjectsTasks.Application.Task.UseCases
{
    public class GetReport30DaysUseCase : NullaryUseCase<ICollection<ReportOutPut>>
    {
        private readonly ITaskRepository taskRepository;

        public GetReport30DaysUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public ICollection<ReportOutPut> Execute()
        {

            var result = taskRepository.GetAllTask30Days();
            var taskDefinitions = result.SelectMany(t => t.TaskDefinitions).ToList();
            var average30Days = taskDefinitions.GroupBy(td => new { td.AssinedId, td.Assined.Email }) // Supondo que a entidade de usuário tenha uma propriedade UserName
                    .Select(group => ReportOutPut.With(group.Key.Email, group.Count() / 30.0))
                    .ToList();

            return average30Days;
        }
    }
}
