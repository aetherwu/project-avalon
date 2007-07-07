using System;
using System.Web;	 
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;

using ExtremeSwank.Authentication.OpenID;
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

			if (Request.QueryString["openid.mode"] == "id_res") {
				OpenIDConsumer openid = new OpenIDConsumer();
				openid.Identity = (string)Session["OpenID_Login"];
				if (openid.Validate()) {
					//UserObject thisuser = openid.RetreiveUser();
					//Authentication successful - Perform login here
					//Session
					Session["OpenID_UserObject"] = "ok";
					//Return
					Response.Redirect("/");
				} else {
					// Authentication failure handled here
					System.Web.HttpContext.Current.Trace.Write("LoginFailure",openid.GetError());
					Response.Redirect("/login?failure="+openid.GetError());
				}
			}

			if (Request.QueryString["openid.mode"] == "cancel") {
				 // User has cancelled authentication - handle here
				 Response.Redirect("/error");
			}

		}

		protected void Check() {
			if (Session["OpenID_UserObject"] == "ok") {
				status.Text="1";
			}else{
				status.Text="0";
			}
		}

		protected void Login(NameValueCollection form) {
			OpenIDConsumer openid = new OpenIDConsumer();
			openid.Identity = HttpContext.Current.Request["opid"];
			Session["OpenID_Login"] = openid.Identity;
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