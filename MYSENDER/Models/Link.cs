using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYSENDER.Models
{
    public class Link
    {
        public string Action { get; set; }
        public string Controller { get; set; }

        public Link(string action, string controller)
        {
            Action = action;
            Controller = controller;
        }
    }
}
