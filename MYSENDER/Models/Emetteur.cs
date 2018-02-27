using System;
using System.Collections.Generic;

namespace MYSENDER.Models
{
    public class Emetteur
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

        public static Emetteur NotFound = new Emetteur
        {
            Id = 0,
            Nom = string.Empty,
            Prenom = string.Empty,
            Accestoken = string.Empty,
            Tel = string.Empty,
            Historique = new List<Historique>()
        };
    }
}
