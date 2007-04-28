using System;
using System.Web;   
using System.Web.UI.WebControls;

using WebComponents;

namespace Avalon.Web {

	public partial class _page : System.Web.UI.Page　
	{

	　　protected void Page_Load(object sender, EventArgs e)　
		{
			int year = WebComponents.CleanString.GetInt(HttpContext.Current.Request["year"]);
			int month = WebComponents.CleanString.GetInt(HttpContext.Current.Request["month"]);

			DateTime after = Convert.ToDateTime(HttpContext.Current.Request["after"]);
			string keywords = HttpContext.Current.Request["key"];
			
			posts.Year=year;
			posts.Month=month;
			posts.After=after;
			posts.Limit=1;


		}

	}

}