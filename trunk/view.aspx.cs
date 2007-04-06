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

			posts.Year=year;
			posts.Month=month;
			posts.Day=day;

			logTime = Convert.ToDateTime(Utility.FormatCode.GetFormatDay(year,month,day));
			comments.LogTime = logTime;
			refers.LogTime = logTime;

			try
			{
				string refer = Request.UrlReferrer.ToString();
				if (refer!=null && refer!="")
				{
					if (refer.IndexOf("localhost")>0 || refer.IndexOf("woooh")>0)
					{
					}else{
						ReferInfo newRefer = new ReferInfo(0,logTime, refer, Convert.ToDateTime("1999-1-1"));
						Refer rf = new Refer();
						rf.Insert(newRefer);
					}
				}
			}
			catch (Exception msg)
			{
			}

		}
	}

}