using System;
using System.Web;	 
using System.Web.UI.WebControls;

namespace Avalon.Web {

	public partial class _live : System.Web.UI.Page¡¡
	{

		protected void Page_Load(object sender, EventArgs e) {
			System.Web.HttpContext.Current.Trace.Write("runtime", Avalon.Web._global.i.ToString() );
			time.Text = Avalon.Web._global.i.ToString();
		}

	}
}