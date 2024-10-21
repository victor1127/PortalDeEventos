using PortalDeEventos.Data;
using System.Reflection.Metadata.Ecma335;

namespace PortalDeEventos.Models
{
    public class EventRegistration
    {
        public int Id { get; set; }
        public string EventUserId { get; set; } // Foreign key to EventUser
        public int EventId { get; set; } // Foreign key to Events



        // Navigation properties
        public EventUser EventUser { get; set; }
        public Events Events { get; set; }
    }



}
