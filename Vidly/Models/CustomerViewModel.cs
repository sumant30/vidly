using System;
using System . Collections . Generic;
using System . ComponentModel . DataAnnotations;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace Vidly . Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        [DisplayFormat ( DataFormatString = "{0:MM/dd/yyyy}" )]
        public DateTime? BirthDate { get; set; }
    }
}
