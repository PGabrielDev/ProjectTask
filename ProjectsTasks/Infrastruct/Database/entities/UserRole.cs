using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsTasks.Infrastruct.Database.entities
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public int userId { get; set; }
    }
}
