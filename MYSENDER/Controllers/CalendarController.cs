using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSENDER.Common.IRepositories;
using MYSENDER.Models;
using MYSENDER.ViewModels;
using MYSENDER.ViewModels.Modals;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MYSENDER.Controllers
{
    public class CalendarController : BaseController
    {
        private readonly IContactRepository _contactRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public CalendarController(IContactRepository contactRepository, IAppointmentRepository appointmentRepository)
        {
            _contactRepository = contactRepository;
            _appointmentRepository = appointmentRepository;
        }

        // GET: Calendar
        public async Task<ActionResult> Index()
        {
            var model = new AppointmentViewModel
            {
                Appointments = await _appointmentRepository.List()
            };
            return View(model);
        }

        // GET: Calendar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calendar/Create
        public async Task<ActionResult> AddEvent()
        {
            var viewModel = new AppointmentViewModel
            {
                Appointment = new Appointment{AppointmentStart = DateTime.Today},
                Contacts = await _contactRepository.List()
            };

            var model = new ModalViewModel
            {
                Name = "Modals/_Appointment",
                Title = "Ajouter un nouveau rendez-vous",
                Action = "AddEvent",
                Controller = "Calendar",
                Buttons = new List<ModalViewModel.ButtonViewModel>
                {
                    new ModalViewModel.ButtonViewModel { Text = "Ajouter", Id = "addAppointment" }
                },
                Model = viewModel,
                FormId = "addAppointmentForm",
                Required = true
            };
            return PartialView("_Modal", model);
        }

        // POST: Calendar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEvent(IFormCollection collection)
        {
            try
            {
                var app = new Appointment
                {
                    AppointmentTitle = Convert.ToString(collection["AppointmentTitle"]),
                    AppointmentStart = Convert.ToDateTime(collection["AppointmentStart"]),
                    AppointmentEnd = Convert.ToDateTime(collection["AppointmentEnd"])
                };

                _appointmentRepository.Add(app);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calendar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calendar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calendar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calendar/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}