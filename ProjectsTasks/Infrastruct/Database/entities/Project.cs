
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTasks.Infrastruct.Database.entities
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Task> Tasks { get; set; } = [];
        
        [Required]
        public virtual User Author { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
   }
}

