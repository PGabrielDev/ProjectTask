using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTasks.Infrastruct.Database.entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
    
        public string Name { get; set; }

        

    }
}
