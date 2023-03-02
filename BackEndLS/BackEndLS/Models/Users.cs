using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndLS.Models
{
    public class Users
    {
        [Required] // Data anotations para requerir el valor
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Email { get; set; }

    }
}
