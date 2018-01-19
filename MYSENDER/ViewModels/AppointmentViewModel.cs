using MYSENDER.Models;
using System.Collections.Generic;

namespace MYSENDER.ViewModels
{
    public class AppointmentViewModel:BaseViewModel
    {
        public IEnumerable<Appointment> Appointment { get; set; }
    }
}
