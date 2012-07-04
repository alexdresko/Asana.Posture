namespace NsTasks.Web.Ui1.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;
	using System.Web.Security;

	using DotNetOpenAuth.Messaging;
	using DotNetOpenAuth.OpenId;
	using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
	using DotNetOpenAuth.OpenId.RelyingParty;

	using NsTasks.Web.Ui1.Models;

	[Authorize]
	public partial class AccountController : Controller
	{

		//
		// GET: /Account/Login

		[AllowAnonymous]
		public virtual ActionResult Login()
		{
			return RedirectToAction("Authenticate");

			//return this.ContextDependentView();
		}

		//
		// POST: /Account/JsonLogin

		[AllowAnonymous]
		[HttpPost]
		public virtual JsonResult JsonLogin(LoginModel model, string returnUrl)
		{
			if (this.ModelState.IsValid)
			{
				if (Membership.ValidateUser(model.UserName, model.Password))
				{
					FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
					return this.Json(new { success = true, redirect = returnUrl });
				}
				else
				{
					this.ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}
			}

			// If we got this far, something failed
			return this.Json(new { errors = this.GetErrorsFromModelState() });
		}

		//
		// POST: /Account/Login

		[AllowAnonymous]
		[HttpPost]
		public virtual ActionResult Login(LoginModel model, string returnUrl)
		{
			if (this.ModelState.IsValid)
			{
				if (Membership.ValidateUser(model.UserName, model.Password))
				{
					FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
					if (this.Url.IsLocalUrl(returnUrl))
					{
						return this.Redirect(returnUrl);
					}
					else
					{
						return this.RedirectToAction("Index", "Home");
					}
				}
				else
				{
					this.ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}
			}

			// If we got this far, something failed, redisplay form
			return this.View(model);
		}

		//
		// GET: /Account/LogOff

		public virtual ActionResult LogOff()
		{
			FormsAuthentication.SignOut();

			return this.RedirectToAction("Index", "Home");
		}

		//
		// GET: /Account/Register

		[AllowAnonymous]
		public virtual ActionResult Register()
		{
			return this.ContextDependentView();
		}

		//
		// POST: /Account/JsonRegister

		[AllowAnonymous]
		[HttpPost]
		public virtual ActionResult JsonRegister(RegisterModel model)
		{
			if (this.ModelState.IsValid)
			{
				// Attempt to register the user
				MembershipCreateStatus createStatus;
				Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);

				if (createStatus == MembershipCreateStatus.Success)
				{
					FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
					return this.Json(new { success = true });
				}
				else
				{
					this.ModelState.AddModelError("", ErrorCodeToString(createStatus));
				}
			}

			// If we got this far, something failed
			return this.Json(new { errors = this.GetErrorsFromModelState() });
		}

		//
		// POST: /Account/Register

		[AllowAnonymous]
		[HttpPost]
		public virtual ActionResult Register(RegisterModel model)
		{
			if (this.ModelState.IsValid)
			{
				// Attempt to register the user
				MembershipCreateStatus createStatus;
				Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);

				if (createStatus == MembershipCreateStatus.Success)
				{
					FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
					return this.RedirectToAction("Index", "Home");
				}
				else
				{
					this.ModelState.AddModelError("", ErrorCodeToString(createStatus));
				}
			}

			// If we got this far, something failed, redisplay form
			return this.View(model);
		}

		//
		// GET: /Account/ChangePassword

		public virtual ActionResult ChangePassword()
		{
			return this.View();
		}

		//
		// POST: /Account/ChangePassword

		[HttpPost]
		public virtual ActionResult ChangePassword(ChangePasswordModel model)
		{
			if (this.ModelState.IsValid)
			{

				// ChangePassword will throw an exception rather
				// than return false in certain failure scenarios.
				bool changePasswordSucceeded;
				try
				{
					MembershipUser currentUser = Membership.GetUser(this.User.Identity.Name, userIsOnline: true);
					changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
				}
				catch (Exception)
				{
					changePasswordSucceeded = false;
				}

				if (changePasswordSucceeded)
				{
					return this.RedirectToAction("ChangePasswordSuccess");
				}
				else
				{
					this.ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
				}
			}

			// If we got this far, something failed, redisplay form
			return this.View(model);
		}

		//
		// GET: /Account/ChangePasswordSuccess

		public virtual ActionResult ChangePasswordSuccess()
		{
			return this.View();
		}

		private ActionResult ContextDependentView()
		{
			string actionName = this.ControllerContext.RouteData.GetRequiredString("action");
			if (this.Request.QueryString["content"] != null)
			{
				this.ViewBag.FormAction = "Json" + actionName;
				return this.PartialView();
			}
			else
			{
				this.ViewBag.FormAction = actionName;
				return this.View();
			}
		}

		private IEnumerable<string> GetErrorsFromModelState()
		{
			return this.ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
		}

		private static OpenIdRelyingParty openid = new OpenIdRelyingParty();

		[ValidateInput(false)]
		[AllowAnonymous]
		public virtual ActionResult Authenticate(string returnUrl)
		{
			var response = openid.GetResponse();
			if (response == null)
			{
				// Stage 2: user submitting Identifier
				var suppliedIdentifier = @"https://www.google.com/accounts/o8/id";

				Identifier id;
				if (Identifier.TryParse(suppliedIdentifier, out id))
				{
					try
					{
						var request = openid.CreateRequest(id);

						request.AddExtension(new ClaimsRequest
						{
							Email = DemandLevel.Require,
							FullName = DemandLevel.Request

						});

						return request.RedirectingResponse.AsActionResult();
					}
					catch (ProtocolException ex)
					{
						ViewData["Message"] = ex.Message;
						return RedirectToAction("Index", "Home");
					}
				}

				this.ViewData["Message"] = "Invalid identifier";
				return this.RedirectToAction("Index", "Home");
			}

			// Stage 3: OpenID Provider sending assertion response
			switch (response.Status)
			{
				case AuthenticationStatus.Authenticated:
					var claims = response.GetExtension<ClaimsResponse>();

					this.Session["FriendlyIdentifier"] = claims.Email;
					FormsAuthentication.SetAuthCookie(claims.Email, false);
					if (Membership.GetUser(claims.Email) == null)
					{
						Membership.CreateUser(claims.Email, Guid.NewGuid().ToString());
						this.RedirectToAction(MVC.Profile.Index());
					}
					if (!string.IsNullOrEmpty(returnUrl))
					{
						return this.Redirect(returnUrl);
					}

					return this.RedirectToAction("Index", "Home");
				case AuthenticationStatus.Canceled:
					this.ViewData["Message"] = "Canceled at provider";
					return this.RedirectToAction("Index", "Home");

				case AuthenticationStatus.Failed:
					this.ViewData["Message"] = response.Exception.Message;
					return this.RedirectToAction("Index", "Home");

			}
			return new EmptyResult();
		}


		#region Status Codes
		private static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
				case MembershipCreateStatus.DuplicateUserName:
					return "User name already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}
		#endregion
	}
}
