namespace NsTasks.Web.Ui1.Controllers
{
	using System.Web.Mvc;

	using Asana.Posture.Core.Data;

	public partial class AsanaController : Controller
	{
		// GET: /Asana/
		#region Public Methods and Operators

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

		public virtual ActionResult Index()
		{
			return this.View();
		}

		#endregion
	}
}