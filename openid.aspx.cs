using System;
using System.Web;	 
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;

using ExtremeSwank.Authentication.OpenID;
using ExtremeSwank.Authentication.OpenID.Plugins.Extensions;
using WebComponents;

namespace Avalon.Web {

	public partial class _openid : System.Web.UI.Page¡¡
	{

		protected void Page_Load(object sender, EventArgs e) {

			NameValueCollection form;
			form=Request.Form;
				
			string method = HttpContext.Current.Request["m"];
			switch (method)
			{
			case "login":
				Login(form);
				break;
			case "logout":
				Logout();
				break;
			case "check":
				Check();
				break;
			}

            if (!IsPostBack)
            {
                OpenIDConsumer openid = new OpenIDConsumer();
                switch (openid.RequestedMode)
                {
                    case RequestedMode.IdResolution:
                        openid.Identity = (string)Session["OpenID_Login"];
                        if (openid.Validate())
                        {
                            Session["OpenID_UserObject"] = openid.RetrieveUser();
                            // Authentication successful - Perform login here
                            Response.Redirect("/");
                        }
                        else
                        {
                            // Authentication failure handled here
                            System.Web.HttpContext.Current.Trace.Write("LoginFailure", openid.GetError());
                            Response.Redirect("/login?failure=" + openid.GetError());
                        }
                        break;
                    case RequestedMode.CancelledByUser:
                        // User has cancelled authentication - handle here
                        Response.Redirect("/error");
                        break;
                }
            }

		}

		protected void Check() {
            if (Session["OpenID_UserObject"] != null)
            {
				status.Text="1";
			}else{
				status.Text="0";
			}
		}

		protected void Login(NameValueCollection form) {
			OpenIDConsumer openid = new OpenIDConsumer();
            openid.Identity = HttpContext.Current.Request["opid"];

            SimpleRegistration sr = new SimpleRegistration(openid);
            sr.RequiredFields = "nickname,email";
            sr.OptionalFields = "gender";

            Session["OpenID_Identity"] = openid.Identity;
			openid.BeginAuth();
		}

		protected void Logout() {
			// Handle user logout here
			// Session
			Session["OpenID_UserObject"] = null;
			// Return
			Response.Redirect("/");
		}

	}

}