using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NsTasks.Web.Ui1.Controllers
{
	using Asana.Posture.Core.Data;

	public partial class AsanaController : Controller
    {
        //
        // GET: /Asana/

		public virtual ActionResult Index()
        {
            return View();
        }

		public virtual ActionResult GetAsanaNav()
		{
			var repository = new AsanaRespository();
			return Json(repository.GetAsanaNav(), JsonRequestBehavior.AllowGet);
		}

		public virtual ActionResult GetWorkspaceStats(long id)
		{
			var repository = new AsanaRespository();
			return Json(repository.GetWorkspaceStats(id), JsonRequestBehavior.AllowGet);
		}
    }
}
