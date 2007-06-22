using System;
using System.Web;	 
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;

using ExtremeSwank.Authentication.OpenID;
using WebComponents;

namespace Avalon.Web {

	public partial class _login : System.Web.UI.Page¡¡
	{

		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				if (Request.QueryString["openid.mode"] == "id_res") {
					 OpenIDConsumer openid = new OpenIDConsumer();
					 openid.Identity = (string)Session["OpenID_Login"];
					 if (openid.Validate()) {
							//UserObject thisuser = openid.RetreiveUser();
							//Session["OpenID_UserObject"] = thisuser;
							// Authentication successful - Perform login here
							opid.Visible=false;
							m.Value="logout";
							submit.Value=" ÍË³ö ";
					 }
					 else {
							// Authentication failure handled here
					 }
				}
				if (Request.QueryString["openid.mode"] == "cancel") {
					 // User has cancelled authentication - handle here
				}
			}else{

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
				}

			}
		}

		protected void Login(NameValueCollection form) {
			OpenIDConsumer openid = new OpenIDConsumer();
			openid.Identity = HttpContext.Current.Request["opid"];
			Session["OpenID_Login"] = openid.Identity;
			openid.BeginAuth();
				System.Web.HttpContext.Current.Trace.Write("ID", HttpContext.Current.Request["opid"].ToString());

		}

		protected void Logout() {
			Session["OpenID_UserObject"] = null;
			// Handle user logout here
		}

	}

}
	