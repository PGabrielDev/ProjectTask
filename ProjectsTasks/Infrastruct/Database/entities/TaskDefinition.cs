using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTasks.Infrastruct.Database.entities
{
    [Table("TaskDeinition")]
    public class TaskDefinition
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]
        public int TaskId { get; set; }

        [Required]

        public Status Stats { get; set; }
        

        public virtual User? Assined { get; set; }
        public int? AssinedId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = [];

        [Required]
        public DateTime createdAt { get; set; }
        
        [Required]

        public string ChangeDescription { get; set; }

    }
}
