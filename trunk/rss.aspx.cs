using System;
using System.Web;   
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

	public partial class _rss : System.Web.UI.Page　
	{

		private IList<PostIndexInfo> lst;

		private int _year;
		private int _month;
		private int _day;
		private int _page;
		private string _keyword;
		private DateTime _begin;
		private DateTime now;

	　　protected void Page_Load(object sender, EventArgs e)　
		{
			
			Post c = new Post();
			lst = c.GetDays(_year,_month,_day,_page,_keyword,true,10,_begin);

			if (lst != null) {
                postList.DataSource = lst;
                postList.DataBind();
			}

		}

		//bind the child repeater
		public void postList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			Post d =new Post();
			 if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.SelectedItem)
			{
				//find data in parent source
				PostIndexInfo clips = (PostIndexInfo)e.Item.DataItem; 

				//format and get the params
				/*/
				int year = 2007;
				int month = 2;
				int day = 6;
				/*/
				int year =  Convert.ToInt32( clips.PostTime.ToString("yyyy") );
				int month = Convert.ToInt32( clips.PostTime.ToString("MM") );
				int day = Convert.ToInt32( clips.PostTime.ToString("dd") );
				//*/

				Repeater postInDay = (Repeater)e.Item.FindControl("postInDay");
				postInDay.DataSource = d.GetOneDay(year, month, day);
				postInDay.DataBind();
			} 
		}

	}

}