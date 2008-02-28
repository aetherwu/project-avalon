using System;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
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
			DateTime dt = DateTime.Now.AddDays(1);

            //check if it is existed
			Person person = new Person();
			PersonInfo p = person.GetPerson(personName);

            if (p == null)
            {
                //Response.Redirect("/error.html");
            }
            else
            {
				persona.Text = p.Name;

                clips.PersonID = p.ID;
                clips.After = dt;
				clips.GetPost = true;
				clips.Limit = 3;

                live.PersonID = p.ID;
                live.After = dt;
				live.GetPost = false;
         }

		}
	}
}