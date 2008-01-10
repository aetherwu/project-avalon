using System;
using System.Web;   
using System.Web.UI.WebControls;

using WebComponents;
using Utility;

using Model;
using BLL;

namespace Avalon.Web {

	public partial class _view : System.Web.UI.Page　
	{

		private DateTime logTime;

	　　protected void Page_Load(object sender, EventArgs e)　
		{
			int year = WebComponents.CleanString.GetInt(HttpContext.Current.Request["year"]);
			int month = WebComponents.CleanString.GetInt(HttpContext.Current.Request["month"]);
			int day = WebComponents.CleanString.GetInt(HttpContext.Current.Request["day"]);

			clips.Year=year;
			clips.Month=month;
			clips.Day=day;

			logTime = Convert.ToDateTime(Utility.FormatCode.GetFormatDay(year,month,day));
			comments.LogTime = logTime;

		}
	}

}