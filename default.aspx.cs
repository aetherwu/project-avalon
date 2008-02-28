using System;
using System.Web;   
using System.Web.UI.WebControls;

using WebComponents;

namespace Avalon.Web {

	public partial class _default : System.Web.UI.Page　
	{

	　　protected void Page_Load(object sender, EventArgs e)　
		{
			 Response.Redirect("/aether/");
		}

	}

}