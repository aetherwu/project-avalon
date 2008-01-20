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
		private bool _getFriend;
		public bool GetFriend
		{
			get { return _getFriend; }
			set { this._getFriend = value; }
		}
        private int _personID;
        public int PersonID
        {
            get { return _personID; }
            set { this._personID = value; }
        }
        private bool _getToday;
        public bool GetToday
        {
            get { return _getToday; }
            set { this._getToday = value; }
        }
		DateTime dt = DateTime.Now.Date;

		public void Page_Load(object sender, EventArgs e)��
		{
			Clip c = new Clip();
			if(_getToday){
				_year =  dt.Year;
				_month = dt.Month;
                _day = dt.Day;
			}else{
			}

			lst = c.GetDays(_year, _month, _day, _personID, _getFriend, _limit, _after);

			if (lst != null) {
                clipList.DataSource = lst;
                clipList.DataBind();
			}
		}

		//���ڲ�Repeater�ؼ�
		public void clipList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			Clip clip =new Clip();
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.SelectedItem)
			{
				//find data in parent source
				ClipIndexInfo clips = (ClipIndexInfo)e.Item.DataItem; 
				
				int year =  Convert.ToInt32( clips.PostTime.ToString("yyyy") );
				int month = Convert.ToInt32( clips.PostTime.ToString("MM") );
				int day = Convert.ToInt32( clips.PostTime.ToString("dd") );
				Repeater clipInDay = (Repeater)e.Item.FindControl("clipInDay");
				
				clipInDay.DataSource = clip.GetOneDay(year, month, day, _personID, _getFriend, _getToday);
				clipInDay.DataBind();

			} 
		}


    }

}