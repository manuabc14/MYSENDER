using MYSENDER.Models;
using System.Collections.Generic;

namespace MYSENDER.ViewModels
{
    public class AppointmentViewModel:BaseViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public Appointment Appointment { get; set; }
    }
}
