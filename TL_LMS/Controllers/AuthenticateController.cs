using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TL_LMS.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {

          
            return View();
          

        }
    }
}