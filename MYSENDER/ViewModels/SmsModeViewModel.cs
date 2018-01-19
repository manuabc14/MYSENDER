using MYSENDER.Models;
using System.Collections.Generic;

namespace MYSENDER.ViewModels
{
    public class SmsModeViewModel : BaseViewModel
    {
        public SmsModeModel SmsMode { get; set; }
        public List<Historique> Historiques { get; set; }
    }
}
