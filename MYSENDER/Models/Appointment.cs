using System;
using System.ComponentModel.DataAnnotations;

namespace MYSENDER.Models
{
    public class Appointment
    {
        [ScaffoldColumn(false)]
        public int AptId { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        public string AppointmentTitle { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        public Contact Contact { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AppointmentStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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
