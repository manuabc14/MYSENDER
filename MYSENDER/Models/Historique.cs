using System;
using System.Collections.Generic;

namespace MYSENDER.Models
{
    public class Historique
    {
        public int Id { get; set; }
        public int? IdEmetteur { get; set; }
        public string Smstext { get; set; }
        public int? IdContact { get; set; }
        public DateTime? DateEnvoi { get; set; }
        public int? Statut { get; set; }

        public virtual Contact IdContactNavigation { get; set; }
        public virtual Emetteur IdEmetteurNavigation { get; set; }

        public static Historique NotFound = new Historique
        {
            Id = 0,
            IdEmetteur = 0,
            Smstext = string.Empty,
            IdContact = 0,
            IdEmetteurNavigation = new Emetteur(),
            DateEnvoi = DateTime.MinValue,
            Statut = 0,
            IdContactNavigation = new Contact()

        };
    }
}
