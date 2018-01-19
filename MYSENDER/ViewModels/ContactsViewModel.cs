using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYSENDER.Models;

namespace MYSENDER.ViewModels
{
    public class ContactsViewModel:BaseViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public Contact Contact { get; set; }
    }
}
