using System;
using System.Collections.Generic;

namespace MYSENDER.DatabaseModels
{
    public partial class Historique
    {
        public int Id { get; set; }
        public int? IdEmetteur { get; set; }
        public string Smstext { get; set; }
        public int? IdContact { get; set; }
        public DateTime? DateEnvoi { get; set; }
        public int? Statut { get; set; }

        public virtual Contact IdContactNavigation { get; set; }
        public virtual Emetteur IdEmetteurNavigation { get; set; }
    }
}
