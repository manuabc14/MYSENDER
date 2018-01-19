using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYSENDER.Models;

namespace MYSENDER.Services
{
    public class AppointmentService
    {
        private static AppointmentService _intance;
        public static AppointmentService Instance => _intance ?? (_intance = new AppointmentService());

        public IEnumerable<Appointment> GetAppointments()
        {
            var appointments = new List<Appointment>
            {
                new Appointment
                {
                    AptId = 1,
                    AppointmentTitle = "rdv le 30 pour votre séance avec Elise MOLINA ",
                    Start = new DateTime(2018,01,18),
                    End = new DateTime(2018,01,19)
                },
                new Appointment
                {
                    AptId = 2,
                    AppointmentTitle = "rdv le 30 pour votre séance avec Elise MOLINA ",
                    Start = new DateTime(2018,01,20),
                    End = new DateTime(2018,01,20)
                },
                new Appointment
                {
                    AptId = 3,
                    AppointmentTitle = "rdv le 30 pour votre séance avec Elise MOLINA ",
                    Start = new DateTime(2018,01,21),
                    End = new DateTime(2018,01,22)
                },
                new Appointment
                {
                    AptId = 4,
                    AppointmentTitle = "rdv le 30 pour votre séance avec Elise MOLINA ",
                    Start = new DateTime(2018,01,23),
                    End = new DateTime(2018,01,23)
                }
            };

            return appointments;
        }
    }
}
