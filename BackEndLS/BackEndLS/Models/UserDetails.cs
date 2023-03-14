using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndLS.Models
{
    public class UserDetails
    {
        [Required] 
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PetTypeId { get; set; }

        [Required]
        public int RaceId { get; set; }

        [Required]
        public int UserProfilePicId { get; set; }

        [Required]
        public int GenderId { get; set; }

    }
}
