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

		private int _year;
		private int _month;
		private int _day;
		private int _page;
		private string _keyword;
		private DateTime _begin;
		private DateTime now;

	protected void Page_Load(object sender, EventArgs e)
		{
			
			Clip c = new Clip();
			lst = c.GetDays(_year,_month,_day,_page,_keyword,true,5,_begin);

			if (lst != null) {
                clipList.DataSource = lst;
                clipList.DataBind();
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
				clipInDay.DataSource = d.GetOneDay(year, month, day);
				clipInDay.DataBind();
			} 
		}

	}

}