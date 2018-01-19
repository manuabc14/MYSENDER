using MYSENDER.Models;
using System;
using System.Collections.Generic;

namespace MYSENDER.Helpers
{
    public class MenuHelper
    {
        public static List<Menu> GetMenus(string controller, string action)
        {
            var menu = GetMenu();
            ActiveMenu(menu, controller, action);
            return menu;
        }

        public static List<Menu> GetLeftMenus(string controller, string action, List<Menu> leftMenus)
        {
            controller = controller.ToLower();
            action = action.ToLower();

            var menus = GetMenus(controller, action);

            return menus ?? new List<Menu>();
        }

        private static void ActiveMenu(IEnumerable<Menu> menu, string controller, string action)
        {
            foreach (var sm in menu)
            {
                var isSameController = sm.Link?.Controller.Equals(controller, StringComparison.CurrentCultureIgnoreCase);
                var isSameAction = sm.Link?.Action.Equals(action, StringComparison.CurrentCultureIgnoreCase);
                sm.IsActive = (isSameController ?? false) && isSameAction.Value;
            }
        }

        public static List<Menu> GetMenu()
        {
            var result = new List<Menu>();
            var home = new Menu("Accueil", "Home", 1);
            home.IsVisible = true;

            var calendrier = new Menu("Calendrier","Calendar", 2);
            calendrier.IsVisible = true;

            result.Add(home);
            result.Add(calendrier);
 
            return result;
        }
    }
}
