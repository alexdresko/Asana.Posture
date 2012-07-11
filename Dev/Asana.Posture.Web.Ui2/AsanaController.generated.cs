// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Asana.Posture.Web.Ui2.Controllers {
    public partial class AsanaController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AsanaController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AsanaController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult GetWorkspaceStats() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.GetWorkspaceStats);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AsanaController Actions { get { return MVC.Asana; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Asana";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Asana";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string GetAsanaNav = "GetAsanaNav";
            public readonly string GetWorkspaceStats = "GetWorkspaceStats";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string Index = "Index";
            public const string GetAsanaNav = "GetAsanaNav";
            public const string GetWorkspaceStats = "GetWorkspaceStats";
        }


        static readonly ActionParamsClass_GetWorkspaceStats s_params_GetWorkspaceStats = new ActionParamsClass_GetWorkspaceStats();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetWorkspaceStats GetWorkspaceStatsParams { get { return s_params_GetWorkspaceStats; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetWorkspaceStats {
            public readonly string id = "id";
        }
        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_AsanaController: Asana.Posture.Web.Ui2.Controllers.AsanaController {
        public T4MVC_AsanaController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult GetAsanaNav() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.GetAsanaNav);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult GetWorkspaceStats(long id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.GetWorkspaceStats);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
