using PortalDeEventos.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace PortalDeEventos.Models
{
    public class EventRegistration
    {
        public int Id { get; set; }

        [Column("EventUserId")]
        public string EventUserId { get; set; } // Foreign key to EventUser

        [Column("EventId")]
        public int EventsId { get; set; } // Foreign key to Events



        // Navigation properties
        public EventUser EventUser { get; set; }
        public Events Events { get; set; }
    }



}
