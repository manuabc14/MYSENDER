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
       // public List<Notification> Notifications { get; set; }
        public List<Menu> LeftMenus { get; set; }
       // public BreadcrumbViewModel Breadcrumb { get; set; }
        public Dictionary<string, bool> Rights { get; set; } = new Dictionary<string, bool>();
    }
}
