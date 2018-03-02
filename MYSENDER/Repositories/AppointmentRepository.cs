using MYSENDER.Common.IRepositories;
using MYSENDER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MYSENDER.DatabaseModels;
using Appointment = MYSENDER.Models.Appointment;

namespace MYSENDER.Repositories
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private readonly MYSENDERContext _ctx;

        public AppointmentRepository(MYSENDERContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Appointment>> List()
        {
            return await _ctx.Appointment.Select(t => new Appointment
            {
                AptId = t.Id,
                AppointmentTitle = t.Title,
                AppointmentStart = (DateTime) t.Startdate,
                AppointmentEnd = (DateTime) t.Enddate
            }).ToListAsync();
        }

        public async Task<Appointment> Get(int id)
        {
            return await _ctx.Appointment.Where(ap => ap.Id == id).Select(ap => new Appointment
            {
                AptId = ap.Id,
                AppointmentTitle = ap.Title,
                AppointmentStart = (DateTime)ap.Startdate,
                AppointmentEnd = (DateTime)ap.Enddate
            }).SingleOrDefaultAsync() ?? Appointment.NotFound;
        }

        public async  Task<Response> Add(Appointment entity)
        {
            _ctx.Appointment.Add(new DatabaseModels.Appointment
            {
                Title = entity.AppointmentTitle,
                Startdate = entity.AppointmentStart,
                Enddate = entity.AppointmentEnd,
                Idcontact = entity.Contact.Id
            });
            return await _ctx.SaveChangesResponseAsync();
        }

        public async Task<Response> Set(Appointment entity)
        {
            var old = await _ctx.Appointment.SingleOrDefaultAsync(h => h.Id == entity.AptId);
            if (old != null)
            {
                old.Title = entity.AppointmentTitle;
                old.Startdate = entity.AppointmentStart;
                old.Enddate = entity.AppointmentEnd;
            }
            return await _ctx.SaveChangesResponseAsync();
        }

        public Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
