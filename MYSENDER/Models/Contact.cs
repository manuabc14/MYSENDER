using System.Collections.Generic;

namespace MYSENDER.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public virtual ICollection<Historique> Historique { get; set; } = new HashSet<Historique>();

        public static Contact NotFound = new Contact
        {
            Id = 0,
            Nom = string.Empty,
            Prenom = string.Empty,
            Tel = string.Empty,
            Historique = new List<Historique>()
        };
    }
}
