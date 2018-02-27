using MYSENDER.Models;
using System;
using System.Collections.Generic;

namespace MYSENDER.Services
{
    public class AppointmentService
    {
        private static AppointmentService _intance;
        public static AppointmentService Instance => _intance ?? (_intance = new AppointmentService());
        //public IEnumerable<Appointment> GetAppointments()
        //{
        //    var appointments = new List<Appointment>
        //    {
        //        new Appointment
        //        {
        //            AptId = 1,
        //            AppointmentTitle = "rdv le 30 pour votre séance avec Elise MOLINA ",
        //            AppointmentStart = new DateTime(2018,02,18),
        //            AppointmentEnd = new DateTime(2018,02,19)
        //        },
        //        new Appointment
        //        {
        //            AptId = 2,
        //            AppointmentTitle = "rdv le 31 pour votre séance avec Elise MOLINA ",
        //            AppointmentStart = new DateTime(2018,02,20),
        //            AppointmentEnd = new DateTime(2018,02,20)
        //        },
        //        new Appointment
        //        {
        //            AptId = 3,
        //            AppointmentTitle = "rdv le 14 pour votre séance avec Elise MOLINA ",
        //            AppointmentStart = new DateTime(2018,02,21),
        //            AppointmentEnd = new DateTime(2018,02,22)
        //        },
        //        new Appointment
        //        {
        //            AptId = 4,
        //            AppointmentTitle = "rdv le 44 pour votre séance avec Elise MOLINA ",
        //            AppointmentStart = new DateTime(2018,02,23),
        //            AppointmentEnd = new DateTime(2018,02,23)
        //        }
        //    };

        //    return appointments;
        //}
    }
}
