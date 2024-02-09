using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Marshalling;

namespace ProjectsTasks.Infrastruct.Database.entities
{

    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public User User { get; set; }
        
        [Required]
        public int Userid { get; set; }

        [Required]
        public int TaskDefinitionId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        

    }
}
