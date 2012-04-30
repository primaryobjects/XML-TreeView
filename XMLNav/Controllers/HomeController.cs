using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XMLNav.Managers;
using XMLNav.Types;

namespace XMLNav.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<TreeNode> tree = XMLManager.ParseXML(Server.MapPath(".") + "\\" + ConfigurationManager.AppSettings["XMLFilePath"]);

            return View(tree);
        }
    }
}
