using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asana.Posture.Web.Ui2;
using Asana.Posture.Web.Ui2.Controllers;

namespace Asana.Posture.Web.Ui2.Tests.Controllers
{
	using System.Web.Mvc;

	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.AreEqual("Modify this template to kick-start your ASP.NET MVC application.", result.ViewBag.Message);
		}

	
	}
}
