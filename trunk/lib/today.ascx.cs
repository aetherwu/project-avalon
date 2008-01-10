using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class _today : System.Web.UI.UserControl {

		private IList<ClipIndexInfo> clips;

		public void Page_Load(object sender, EventArgs e)　
		{
			Clip c = new Clip();
			clips = c.GetDays();

			if (clips != null) {
                clipToday.DataSource = clips;
                clipToday.DataBind();
			}
		}

		//绑定内部Repeater控件
		public void clipList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			Clip d =new Clip();
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.SelectedItem)
			{
				//find data in parent source
				ClipIndexInfo clips = (ClipIndexInfo)e.Item.DataItem; 

				Repeater clipInDay = (Repeater)e.Item.FindControl("clipInDay");
				clipInDay.DataSource = d.GetOneDay();
				clipInDay.DataBind();
			} 
		}
    }
}