using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MYSENDER.Common.IRepositories;
using MYSENDER.DatabaseModels;
using MYSENDER.Models;
using Historique = MYSENDER.Models.Historique;

namespace MYSENDER.Repositories
{
    public class HistoriqueRepository:IHistoriqueRepository
    {

        private readonly MYSENDERContext _ctx;

        public HistoriqueRepository(MYSENDERContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Historique>> List()
        {
            return await _ctx.Historique.Select(t => new Historique
            {
                Id = t.Id,
                IdEmetteur = t.IdEmetteur,
                IdContact = t.IdContact,
                //IdContactNavigation = t.IdContactNavigation,
                Smstext = t.Smstext,
                Statut = t.Statut,
                //IdEmetteurNavigation = t.IdEmetteurNavigation,
                DateEnvoi = t.DateEnvoi
            }).ToListAsync();
        }

        public Task<Historique> Get(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<DatabaseModels.Historique> Get(int id)
        //{
        //    var result = _ctx.Historique.Where(h => h.Id == id);
        //    return await result.SingleOrDefaultAsync() ?? Historique.NotFound;
        //}

        public async Task<Response> Add(Historique entity)
        {
            _ctx.Historique.Add(new DatabaseModels.Historique
            {
                IdEmetteur = entity.IdEmetteur,
                IdContact = entity.IdContact,
                //IdContactNavigation = entity.IdContactNavigation,
                Smstext = entity.Smstext,
                Statut = entity.Statut,
                //IdEmetteurNavigation = entity.IdEmetteurNavigation,
                DateEnvoi = entity.DateEnvoi
            });
            return await _ctx.SaveChangesResponseAsync();
        }

        public async Task<Response> Set(Historique entity)
        {
            var old = await _ctx.Historique.SingleOrDefaultAsync(h => h.Id == entity.Id);
            if (old != null)
            {
                old.Smstext = entity.Smstext;
                old.IdEmetteur = entity.IdEmetteur;
            }
            return await _ctx.SaveChangesResponseAsync();
        }

        public Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
