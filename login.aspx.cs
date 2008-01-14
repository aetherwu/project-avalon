using System;
using System.Web;	 
using System.Web.UI.WebControls;

namespace Avalon.Web {

	public partial class _login : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e) {
            if (Session["OpenID_UserObject"] == "ok")
			{
				Response.Redirect("/ing");
			}
			if (HttpContext.Current.Request["failure"] != null) {
				status.Text="Login failure : "+HttpContext.Current.Request["failure"];
				Session["OpenID_Login"]=null;
			}
		}
	}
}