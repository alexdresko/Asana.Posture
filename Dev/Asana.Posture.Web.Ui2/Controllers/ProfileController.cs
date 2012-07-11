namespace Asana.Posture.Web.Ui2.Controllers
{
	using System.Web.Mvc;

	public partial class ProfileController : Controller
    {
        //
        // GET: /Profile/

		public virtual ActionResult Index()
        {
            return this.View();
        }

    }
}
