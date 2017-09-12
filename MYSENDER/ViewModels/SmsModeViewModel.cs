using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYSENDER.Models;

namespace MYSENDER.ViewModels
{
    public class SmsModeViewModel
    {
        public SmsModeModel SmsMode { get; set; }
        public List<Historique> Historiques { get; set; }
    }
}
