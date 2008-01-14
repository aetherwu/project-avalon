using System;
using System.Web;	 
using System.Web.UI.WebControls;

namespace Avalon.Web {

	public partial class _ing : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e) {
			if (Session["OpenID_UserObject"] != "ok") {
				Response.Redirect("/login");
			}
		}

	}
}