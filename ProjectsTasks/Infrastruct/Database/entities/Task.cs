
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTasks.Infrastruct.Database.entities
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }


        [Required]
        public Priority Priority { get; set; }
        public virtual ICollection<TaskDefinition> TaskDefinitions { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}

