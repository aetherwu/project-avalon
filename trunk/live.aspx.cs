using System;
using System.Web;	 
using System.Web.UI.WebControls;

using Live;

namespace Avalon.Web {

	public partial class _live : System.Web.UI.Page¡¡
	{

		protected void Page_Load(object sender, EventArgs e) {
			//Runer runer = new Runer();
			//runer.loadRSS();
			time.Text = Avalon.Web._global.i.ToString();
		}
	}
}