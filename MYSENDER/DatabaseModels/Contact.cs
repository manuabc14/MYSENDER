using System;
using System.Collections.Generic;

namespace MYSENDER.DatabaseModels
{
    public partial class Contact
    {
        public Contact()
        {
            Historique = new HashSet<Historique>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }

        public virtual ICollection<Historique> Historique { get; set; }
    }
}
