using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYSENDER.Models
{
    public class Menu
    {
        public string Title { get; set; }
        public Link Link { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        public bool HasSubMenu => SubMenus != null && SubMenus.Count > 0;
        public List<Menu> SubMenus { get; set; }

        public Menu(string title, int order, bool isActive = false)
        {
            Title = title;
            Order = order;
            IsActive = isActive;
        }

        public Menu(string title, Link link, int order, bool isActive = false)
        {
            Title = title;
            Link = link;
            Order = order;
            IsActive = isActive;
        }

        public Menu(string title, string controller, int order, bool isActive = false)
        {
            Title = title;
            Link = new Link("Index", controller);
            Order = order;
            IsActive = isActive;
        }

        public Menu(string title, string action, string controller, int order, bool isActive = false)
        {
            Title = title;
            Link = new Link(action, controller);
            Order = order;
            IsActive = isActive;
        }

        public void AddSubMenu(Menu subMenu)
        {
            if (SubMenus == null)
                SubMenus = new List<Menu>();
            SubMenus.Add(subMenu);
        }
    }
}
