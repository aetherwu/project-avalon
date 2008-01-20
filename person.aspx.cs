using System;
using System.Web;   
using System.Web.UI.WebControls;

using BLL;
using Model;
using WebComponents;

namespace Avalon.Web {

	public partial class _person : System.Web.UI.Page　
	{

	　　protected void Page_Load(object sender, EventArgs e)　
		{
			int year = WebComponents.CleanString.GetInt(HttpContext.Current.Request["year"]);
			int month = WebComponents.CleanString.GetInt(HttpContext.Current.Request["month"]);
			string personName = HttpContext.Current.Request["person"];
			DateTime dt = DateTime.Now.Date;

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

                clips_today.GetToday = true;
                clips_today.GetFriend = false;
                clips_today.PersonID = p.ID;

                clips.GetToday = false;
                clips.GetFriend = false;
                clips.PersonID = p.ID;
                clips.After = dt;

                clips_today_f.GetToday = true;
                clips_today_f.GetFriend = true;
                clips_today_f.PersonID = p.ID;

                clips_f.GetToday = false;
                clips_f.GetFriend = true;
                clips_f.PersonID = p.ID;
                clips_f.After = dt;
            }

		}

	}

}