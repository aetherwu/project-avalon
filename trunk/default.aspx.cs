using System;
using System.Web;   
using System.Web.UI.WebControls;

using WebComponents;

namespace Avalon.Web {

	public partial class _default : System.Web.UI.Page��
	{

	����protected void Page_Load(object sender, EventArgs e)��
		{
			int year = WebComponents.CleanString.GetInt(HttpContext.Current.Request["year"]);
			int month = WebComponents.CleanString.GetInt(HttpContext.Current.Request["month"]);
			int day = WebComponents.CleanString.GetInt(HttpContext.Current.Request["day"]);

			int page = WebComponents.CleanString.GetInt(HttpContext.Current.Request["page"]);
			string keywords = HttpContext.Current.Request["key"];
			
			posts.Year=year;
			posts.Month=month;

			posts.Limit=5;

		}

	}

}