using System;
using System.ComponentModel.DataAnnotations;

namespace MS.Models
{
    public class Movie
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Director { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(ValidationMethods), "ValidateLessThanNow")]
        public DateTime ReleaseDate { get; set; }

        //public bool Deleted { get; set; }
    }
}
