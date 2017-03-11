using System;
using System . Collections . Generic;
using System . ComponentModel . DataAnnotations;
using System . Linq;
using System . Web;

namespace Vidly . Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Genre { get; set; }

        [DisplayFormat ( DataFormatString = "{0:MM/dd/yyyy}" )]
        public DateTime ReleaseDate { get; set; }

        [DisplayFormat ( DataFormatString = "{0:MM/dd/yyyy}" )]
        public DateTime DateAdded { get; set; }

        public int InStock { get; set; }
    }
}