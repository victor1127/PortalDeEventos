using PortalDeEventos.Data;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace PortalDeEventos.Models
{
    public class Events 
    {
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at most {1}", MinimumLength = 2)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Location")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1}", MinimumLength = 2)]
        public string Location { get; set; }



        [Required]
        public DateTime? Time { get; set; }



        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }



        public EventUser Author { get; set; }
        public ICollection<EventRegistration> EventRegistrations { get; set; } = new HashSet<EventRegistration>();

    }


}
