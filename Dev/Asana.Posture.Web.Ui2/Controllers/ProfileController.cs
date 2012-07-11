using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NsTasks.Web.Ui1.Controllers
{
	public partial class ProfileController : Controller
    {
        //
        // GET: /Profile/

		public virtual ActionResult Index()
        {
            return View();
        }

    }
}
