using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkillTreeHW1.Models;

namespace SkillTreeHW1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var costService = new CostService();
            var data = new AccountViewModel()
            {
                ViewModel = costService.GenCost(100)
            };
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}