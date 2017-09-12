using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MYSENDER.Models;
using MYSENDER.Services;
using MYSENDER.ViewModels;

namespace MYSENDER.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TotalAccount = SmsModeServices.Instance.GetSolde();
           // AjaxHandler(new DttbParameter());
            return View();
        }

        public ActionResult AjaxHandler(DttbParameter param)
        {
            var result = DttbResult.FilterResult(param);

            return Json(new
            {
                iTotalRecords = result.TotalResult,
                iTotalDisplayRecords = result.NbrDisplayResult,
                Data = result.ListResult
            });

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(SmsModeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var template = new SmsModeModel{ReceiverNumber = model.SmsMode.ReceiverNumber,Message = model.SmsMode.Message};
                    var response = SmsModeServices.Instance.SendSms(template);

                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
