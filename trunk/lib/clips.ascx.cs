using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class _clips : System.Web.UI.UserControl {

		private IList<ClipIndexInfo> lst;

		private int _year;
		public int Year
		{
			get { return _year; }
			set { this._year = value; }
		}
		private int _month;
		public int Month
		{
			get { return _month; }
			set { this._month = value; }
		}
		private int _day;
		public int Day
		{
			get { return _day; }
			set { this._day = value; }
		}
		private int _page;
		public int Page
		{
			get { return _page; }
			set { this._page = value; }
		}
		private string _keyword;
		public string Keyword
		{
			get { return _keyword; }
			set { this._keyword = value; }
		}
		private int _limit;
		public int Limit
		{
			get { return _limit; }
			set { this._limit = value; }
		}
		private DateTime _after;
		public DateTime After
		{
			get { return _after; }
			set { this._after = value; }
		}

		public void Page_Load(object sender, EventArgs e)　
		{
			Clip c = new Clip();
			lst = c.GetDays(_year,_month,_day,_page,_keyword,false,_limit,_after);

			if (lst != null) {
                clipList.DataSource = lst;
                clipList.DataBind();
			}
		}

		//绑定内部Repeater控件
		public void clipList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			Clip clip =new Clip();
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.SelectedItem)
			{
				//find data in parent source
				ClipIndexInfo clips = (ClipIndexInfo)e.Item.DataItem; 

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

				Repeater clipInDay = (Repeater)e.Item.FindControl("clipInDay");
				clipInDay.DataSource = clip.GetOneDay(year, month, day);
				clipInDay.DataBind();
			} 
		}


    }

}