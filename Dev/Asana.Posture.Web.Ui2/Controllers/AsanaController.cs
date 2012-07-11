namespace Asana.Posture.Web.Ui2.Controllers
{
	using System.Web.Mvc;

	using Asana.Posture.Core.Data;

	public partial class AsanaController : Controller
    {
        //
        // GET: /Asana/

		public virtual ActionResult Index()
        {
            return this.View();
        }

		public virtual ActionResult GetAsanaNav()
		{
			var repository = new AsanaRespository();
			return this.Json(repository.GetAsanaNav(), JsonRequestBehavior.AllowGet);
		}

		public virtual ActionResult GetWorkspaceStats(long id)
		{
			var repository = new AsanaRespository();
			return this.Json(repository.GetWorkspaceStats(id), JsonRequestBehavior.AllowGet);
		}
    }
}
