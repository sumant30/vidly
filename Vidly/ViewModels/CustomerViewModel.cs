using System;
using System . Collections . Generic;
using System . ComponentModel . DataAnnotations;
using Vidly . Models;

namespace Vidly . ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        [Display(Name="Date of Birth")]
        [DisplayFormat ( DataFormatString = "{0:dd MMM yyyy}" , ApplyFormatInEditMode = true )]
        public DateTime? BirthDate { get; set; }
    }
}
