using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MYSENDER.ViewModels;

namespace MYSENDER.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            //var user = context.HttpContext.GetObject<User>("user");
            //var controller = context.Controller as Controller;
            //BaseViewModel model = null;
            //if (controller != null)
            //    model = controller.ViewData.Model as BaseViewModel;
            //if (model == null) return;

            //var ctrl = context.ActionDescriptor.ControllerDescriptor.ControllerName;
            //var action = context.ActionDescriptor.ActionName;

            //model.Header = new HeaderViewModel
            //{
            //    User = user ?? Common.Models.Atrium.User.NotFound,
            //    Menus = MenuHelper.GetMenus(ctrl, action)
            //};
            //model.LeftMenus = MenuHelper.GetLeftMenus(ctrl, action);
            //model.Breadcrumb = new BreadcrumbViewModel
            //{
            //    Title = BreadcrumbHelper.GetPageTitle(ctrl, action),
            //    Breadcrumb = BreadcrumbHelper.GetBreadcrumb(ctrl, action)
            //};
            //model.Notifications = (List<Notification>)TempData["notifications"];
        }
    }
}