using Cinemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinemax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        //start custom code
        public ActionResult SearchOne()
        {
            SearchModel model = new SearchModel();
            model.Search = "";
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult SearchOne(SearchModel model)
        {
            Response.Redirect("/Movies/Search/?search=" + model.Search);
            return PartialView(model);
        }
        // end custom code
    }
}