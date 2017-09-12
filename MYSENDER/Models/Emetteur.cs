using System;
using System.Collections.Generic;

namespace MYSENDER.Models
{
    public partial class Emetteur
    {
        public Emetteur()
        {
            Historique = new HashSet<Historique>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Accestoken { get; set; }
        public string Tel { get; set; }

        public virtual ICollection<Historique> Historique { get; set; }
    }
}
