using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amplify_Fitness.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult Forum_Home()
        {
            return View();
        }
    }
}