using System;

namespace MYSENDER.Models
{
    public class Appointment
    {
        public int AptId { get; set; }
        public string AppointmentTitle { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
