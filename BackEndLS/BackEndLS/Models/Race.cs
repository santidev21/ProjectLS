﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndLS.Models
{
    public class Race
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string RaceName { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int PetTypeId { get; set; }
    }
}
