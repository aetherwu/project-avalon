using System;
using System.Web;	 
using System.Web.UI.WebControls;

using Live;
using ExtremeSwank.Authentication.OpenID;
using ExtremeSwank.Authentication.OpenID.Plugins.Extensions;

namespace Avalon.Web {

	public partial class _live : System.Web.UI.Page¡¡
	{

		protected void Page_Load(object sender, EventArgs e) {
			Runer runer = new Runer();
			runer.loadRSS();


		}
	}
}