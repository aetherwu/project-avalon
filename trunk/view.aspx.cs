using System;
using System.Web;   
using System.Web.UI.WebControls;

using WebComponents;
using Utility;

using BLL;
using Model;

namespace Avalon.Web {

	public partial class _view : System.Web.UI.Page　
	{

		private DateTime logTime;

	　　protected void Page_Load(object sender, EventArgs e)　
		{
			int year = WebComponents.CleanString.GetInt(HttpContext.Current.Request["year"]);
			int month = WebComponents.CleanString.GetInt(HttpContext.Current.Request["month"]);
			int day = WebComponents.CleanString.GetInt(HttpContext.Current.Request["day"]);
			string personName = HttpContext.Current.Request["person"];

            //check if it is existed
			Person person = new Person();
			PersonInfo p = person.GetPerson(personName);

            if (p == null)
            {
                Response.Redirect("/");
            }
            else
            {
				persona.Text = p.Name;

				clips.Year=year;
				clips.Month=month;
				clips.Day=day;
                clips.PersonID = p.ID;

				clips_f.Year=year;
				clips_f.Month=month;
				clips_f.Day=day;
                clips_f.GetFriend = true;
				clips_f.PersonID = p.ID;

				logTime = Convert.ToDateTime(Utility.FormatCode.GetFormatDay(year,month,day));
				comments.LogTime = logTime;
            }

		}
	}

}