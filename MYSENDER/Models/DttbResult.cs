using System.Collections.Generic;

namespace MYSENDER.Models
{
    public class DttbResult
    {
        public DttbResult()
        {
            NbrDisplayResult = 10;
            ListResult = new List<HistoriqueModel>();
        }

        public int TotalResult { get; set; }
        public int NbrDisplayResult { get; set; }
        public List<HistoriqueModel> ListResult { get; set; }

        public class HistoriqueModel
        {
            public int Id { get; set; }
            public string Smstext { get; set; }
            public string NomEmetteur { get; set; }
            public string NomContact { get; set; }
            public string DateEnvoi { get; set; }
            public int StatutDef { get; set; }

        }
        /// <summary>
        /// Filtre du resultat de la recherche
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static DttbResult FilterResult(DttbParameter parameter)
        {
            var result = new DttbResult
            {
                TotalResult = 6,
                NbrDisplayResult = 6,
                ListResult = new List<HistoriqueModel>()
                {
                    new HistoriqueModel
                    {
                        Id = 1,
                        Smstext = "rdv le 30 pour votre séance avec Elise MOLINA ",
                        DateEnvoi = "25/01/2017",
                        NomContact = "clem",
                        NomEmetteur = "Redmond",
                        StatutDef = 1
                    },
                    new HistoriqueModel
                    {
                        Id = 7,
                        Smstext = "rdv le 12/12/2017 pour votre séance avec Elise MOLINA",
                        DateEnvoi = "22/12/2017",
                        NomContact = "jean",
                        NomEmetteur = "Redmond",
                        StatutDef = 0
                    },
                    new HistoriqueModel
                    {
                        Id = 6,
                        Smstext = "rdv le 25/07/2017 pour votre séance avec Elise MOLINA ",
                        DateEnvoi = "27/10/2017",
                        NomContact = "bernard",
                        NomEmetteur = "Redmond",
                        StatutDef = 0
                    },
                    new HistoriqueModel
                    {
                        Id = 4,
                        Smstext = "rdv le 01/04/2017 pour votre séance avec Elise MOLINA",
                        DateEnvoi = "26/03/2017",
                        NomContact = "ken",
                        NomEmetteur = "Redmond",
                        StatutDef = 1
                    },
                    new HistoriqueModel
                    {
                        Id = 5,
                        Smstext = "rdv le 01/04/2017 pour votre séance avec Elise MOLINA",
                        DateEnvoi = "27/05/2017",
                        NomContact = "damien",
                        NomEmetteur = "Redmond",
                        StatutDef = 0
                    },
                    new HistoriqueModel
                    {
                        Id = 2,
                        Smstext = "rdv le 01/04/2017 pour votre séance avec Elise MOLINA",
                        DateEnvoi = "20/01/2017",
                        NomContact = "Eric",
                        NomEmetteur = "Redmond",
                        StatutDef = -1
                    }
                }
            };


            return result;
        }
    }
}
