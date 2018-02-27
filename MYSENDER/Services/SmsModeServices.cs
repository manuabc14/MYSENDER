using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MYSENDER.Common.IRepositories;
using MYSENDER.DatabaseModels;
using MYSENDER.Models;
using Historique = MYSENDER.Models.Historique;

namespace MYSENDER.Services
{
    public class SmsModeServices
    {
        private readonly IHistoriqueRepository _historiqueRepository;

        public SmsModeServices(IHistoriqueRepository historiqueRepository)
        {
            _historiqueRepository = historiqueRepository;
        }

        private static SmsModeServices _intance;

        private static MySenderContext _dbContext;

        private SmsModeServices()
        {
            _dbContext = new MySenderContext();
            //var connection = @"Server=DESKTOP-0M7S8I3\SQLEXPRESS2012;Database=MYSENDER;Trusted_Connection=True;";
        }

        public static SmsModeServices Instance => _intance ?? (_intance = new SmsModeServices());

        /// <summary>
        /// GEt Connexion to httpClient
        /// </summary>
        /// <returns></returns>
        private HttpClient GetConnexion()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        /// <summary>
        /// Get response from request
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string GetContent(HttpResponseMessage response)
        {
            HttpContent content = response.Content;
            {
                Task<string> result = content.ReadAsStringAsync();
                return result.Result;
            }
        }
        /// <summary>
        /// Get account balance
        /// </summary>
        /// <returns>solde</returns>
        public decimal GetSolde()
        {
            var response = GetConnexion().GetAsync("https://api.smsmode.com/http/1.6/credit.do?accessToken=ZjJrj36bCrAUmxnXwKTLxRPR0xkP1f1w").Result;
            var res = GetContent(response);
            char[] delimiters = new char[] { '\r', '\n' };
            var value = res.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var solde = decimal.Parse(value[0], CultureInfo.InvariantCulture);
            return solde;
        }

        public ResponseSms SendSms(SmsModeModel model)
        {
            ResponseSms retour = null;

            var historique = new Historique
            {
                Smstext = model.Message,
                IdEmetteur = _dbContext.Emetteur.FirstOrDefault(id => id.Id == 1).Id,
                IdContact = _dbContext.Contact.FirstOrDefault(id => id.Tel == model.ReceiverNumber).Id,
                Statut = 1
            };


            //var requestString = string.Format("https://api.smsmode.com/http/1.6/sendSMS.do?accessToken=ZjJrj36bCrAUmxnXwKTLxRPR0xkP1f1w&message={0}&numero={1}",model.Message,model.ReceiverNumber);

            //var response = GetConnexion().GetAsync(requestString).Result;

            //var res = GetContent(response);

            //char[] delimiters = new char[] { '|' };
            //var value = res.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //retour = new ResponseSms
            //{
            //    StatusCode = value[0],
            //    Description = value[1],
            //    SmsId = value[2]
            //};


            // insertion dans notre base de données
            _historiqueRepository.Add(historique);
            return retour;
        }

        //public void InsertHistorique(Historique model)
        //{
        //    var context = _dbContext;

        //    var histo = new Historique()
        //    {
        //        DateEnvoi = DateTime.Now,
        //        Smstext = model.Smstext,
        //        IdEmetteur = model.IdEmetteur,
        //        IdContact = model.IdContact,
        //        Statut = model.Statut
        //    };

        //    context.Historique.Add(histo);
        //    context.SaveChanges();
        //}
    }
}
