using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndLS.Models
{
    public class PetType
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string PetTypeName { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string DefaultPetPic { get; set;}
    }
}
