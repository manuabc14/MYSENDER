using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MYSENDER.Common.IRepositories;
using MYSENDER.DatabaseModels;
using MYSENDER.Models;
using Contact = MYSENDER.Models.Contact;
using Historique = MYSENDER.Models.Historique;

namespace MYSENDER.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private readonly MySenderContext _ctx;

        public ContactRepository(MySenderContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Contact>> List()
        {
            return await _ctx.Contact.Select(t => new Contact
            {
                Id = t.Id,
                Nom = t.Nom,
                Prenom = t.Prenom,
                Tel = t.Tel,
                Historique = t.Historique.Select(h=>new Historique
                {
                    Id = h.Id,
                    IdEmetteur = h.IdEmetteur,
                    IdContact = h.IdContact,
                    Smstext = h.Smstext,
                    DateEnvoi = h.DateEnvoi,
                    Statut = h.Statut
                }).ToList()
            }).ToListAsync();
        }

        public async Task<Contact> Get(int id)
        {
            return await _ctx.Contact.Where(c => c.Id == id).Select(c => new Contact
            {
               Id = c.Id,
               Nom = c.Nom,
               Prenom = c.Prenom,
               Tel = c.Tel,
               Historique = c.Historique.Select(h=>new Historique
                {
                    Id = h.Id,
                    IdEmetteur = h.IdEmetteur,
                    IdContact = h.IdContact,
                    Smstext = h.Smstext,
                    DateEnvoi = h.DateEnvoi,
                    Statut = h.Statut
                }).ToList()
            }).SingleOrDefaultAsync() ?? Contact.NotFound;
        }

        public Task<Response> Add(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Set(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
