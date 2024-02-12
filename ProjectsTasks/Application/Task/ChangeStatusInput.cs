using System.ComponentModel.DataAnnotations;

namespace ProjectsTasks.Application.Task
{
    public class ChangeStatusInput
    {
        [Range(0, 2, ErrorMessage = "O valor deve estar entre 0 e 2. 0 PARA BACKLOG, 1 PARA EM ANDAMENTO E 2 PARA CONCLUIDO")]
        public int status { get; set; }
    }
}
