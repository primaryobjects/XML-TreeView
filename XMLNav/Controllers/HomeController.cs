using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XMLNav.Managers;
using XMLNav.Models;
using XMLNav.Types;

namespace XMLNav.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModel homeModel = new HomeModel();

            // Create the left-side and right-side XML tree controls.
            homeModel.LeftTree = XMLManager.ParseXML(Server.MapPath(".") + "\\" + ConfigurationManager.AppSettings["XMLFilePath"]);
            homeModel.RightTree = XMLManager.ParseXML(Server.MapPath(".") + "\\" + ConfigurationManager.AppSettings["AEFilePath"], true);

            return View(homeModel);
        }
    }
}
