using System;
using System.Web;   
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

	public partial class _rss : System.Web.UI.Page
	{

		private IList<ClipIndexInfo> lst;
        string personName = HttpContext.Current.Request["person"];
		DateTime dt = DateTime.Now.Date;

		private int _year;
		private int _month;
		private int _day;
		private string _keyword;
        private PersonInfo p;

	    protected void Page_Load(object sender, EventArgs e)
		{

			Person person = new Person();
			p = person.GetPerson(personName);

            if (p == null)
            {
                Response.Redirect("/");
            }
            else
            {
                Clip c = new Clip();
                lst = c.GetDays(_year, _month, _day, p.ID , false, 5, dt);

                if (lst != null)
                {
                    clipList.DataSource = lst;
                    clipList.DataBind();
                }
            }

		}

		//bind the child repeater
		public void clipList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			Clip d =new Clip();
			 if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.SelectedItem)
			{
				//find data in parent source
				ClipIndexInfo clips = (ClipIndexInfo)e.Item.DataItem; 

				int year =  Convert.ToInt32( clips.PostTime.ToString("yyyy") );
                int month = Convert.ToInt32(clips.PostTime.ToString("MM"));
                int day = Convert.ToInt32(clips.PostTime.ToString("dd"));
				//*/

				Repeater clipInDay = (Repeater)e.Item.FindControl("clipInDay");
				clipInDay.DataSource = d.GetOneDay(year, month, day ,p.ID , false, false);
				clipInDay.DataBind();
			} 
		}

	}

}