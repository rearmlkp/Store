using AuthAPIs.Models;
using OAuth2;
using OAuth2.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthAPIs.Controllers
{
    public class HomeController : Controller
    {
        private readonly AuthorizationRoot _authorizationRoot;

        private const string ProviderNameKey = "providerName";

        private string ProviderName
        {
            get { return (string)Session[ProviderNameKey]; }
            set { Session[ProviderNameKey] = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="authorizationRoot">The authorization manager.</param>
        public HomeController(AuthorizationRoot authorizationRoot)
        {
            _authorizationRoot = authorizationRoot;
        }

        public HomeController() : this(new AuthorizationRoot())
        {
        }

        /// <summary>
        /// Renders home page with login link.
        /// </summary>
        public ActionResult Index()
        {
            var model = _authorizationRoot.Clients.Select(client => new LoginInfoModel
            {
                ProviderName = client.Name
            });
            return View(model);
        }

        /// <summary>
        /// Redirect to login url of selected provider.
        /// </summary>        
        public RedirectResult Login(string providerName)
        {
            ProviderName = providerName;
            return new RedirectResult(GetClient().GetLoginLinkUri());
        }

        /// <summary>
        /// Renders information received from authentication service.
        /// </summary>
        public ActionResult Auth()
        {
            OAuth2.Models.UserInfo info = GetClient().GetUserInfo(Request.QueryString);
            // Must call route in Store Project
            return Redirect("http://localhost:62254/Login/OAuth?Email=" + info.Email + "&Name=" + info.FirstName + " " + info.LastName);
        }

        private IClient GetClient()
        {
            return _authorizationRoot.Clients.First(c => c.Name == ProviderName);
        }
    }
}