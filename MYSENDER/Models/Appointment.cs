using System;

namespace MYSENDER.Models
{
    public class Appointment
    {
        public int AptId { get; set; }
        public string AppointmentTitle { get; set; }
        public Contact Contact { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }



        public static Appointment NotFound = new Appointment
        {
            AptId = 0,
            AppointmentTitle = string.Empty,
            AppointmentStart = DateTime.MinValue,
            AppointmentEnd = DateTime.MinValue,
            Contact = Contact.NotFound

        };
    }
}
