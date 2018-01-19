using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYSENDER.Models;

namespace MYSENDER.ViewModels
{
    public class BaseViewModel
    {
        public HeaderViewModel Header { get; set; }
        public List<Menu> LeftMenus { get; set; }
        public decimal TotalAccount { get; set; }
    }
}
