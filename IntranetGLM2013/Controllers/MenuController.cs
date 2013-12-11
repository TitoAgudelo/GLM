using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntranetGLM2013.Controllers
{
    public class MenuController : Controller
    {
        // GET: /Menu/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Daily()
        {
            return View();
        }
	}
}