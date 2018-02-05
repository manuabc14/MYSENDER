using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MYSENDER.Helpers;
using MYSENDER.Services;
using MYSENDER.ViewModels;

namespace MYSENDER.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            var controller = context.Controller as Controller;
            BaseViewModel model = null;
            if (controller != null)
                model = controller.ViewData.Model as BaseViewModel;
            if (model == null) return;

            var ctrl = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            model.LeftMenus = MenuHelper.GetLeftMenus(ctrl, action, MenuHelper.GetMenu());
            model.Header = new HeaderViewModel
            {
                Menus = MenuHelper.GetMenus(ctrl, action)
            };
            model.TotalAccount = SmsModeServices.Instance.GetSolde();
        }
    }
}