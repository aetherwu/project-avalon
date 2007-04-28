using System;
using System.Web;	 
using System.Web.UI.WebControls;

using ExtremeSwank.Authentication.OpenID;
using WebComponents;

namespace Avalon.Web {

	public partial class _login : System.Web.UI.Page¡¡
	{

		protected void LoginButton_Click(object sender, EventArgs e) {
			OpenIDConsumer openid = new OpenIDConsumer();
			openid.Identity = LoginBox1.Text;
			Session["OpenID_Login"] = openid.Identity;
			openid.BeginAuth();
		}

		protected void LogOutButton_Click(object sender, EventArgs e) {
			Session["OpenID_UserObject"] = null;
			// Handle user logout here
		}

		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				if (Request.QueryString["openid.mode"] == "id_res") {
					 OpenIDConsumer openid = new OpenIDConsumer();
					 openid.Identity = (string)Session["OpenID_Login"];
					 if (openid.Validate()) {
							//UserObject thisuser = openid.RetreiveUser();
							//Session["OpenID_UserObject"] = thisuser;
							// Authentication successful - Perform login here
					 }
					 else {
							// Authentication failure handled here
					 }
				}
				if (Request.QueryString["openid.mode"] == "cancel") {
					 // User has cancelled authentication - handle here
				}
			}
		}

	}

}
	