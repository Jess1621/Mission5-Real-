using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class ApplicationResponse
    {
        [Key, Required]
        public int ApplicationID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage ="Please Enter the Year the Movie Came Out")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }


        //Build Foreign Key Relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
