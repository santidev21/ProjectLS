using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndLS.Models
{
    public class UserProfilePic
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Pic { get; set; }
    }
}
