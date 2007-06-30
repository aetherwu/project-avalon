using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class _today : System.Web.UI.UserControl {

		private IList<PostIndexInfo> lst;

		public void Page_Load(object sender, EventArgs e)　
		{
			Post c = new Post();
			lst = c.GetDays();

			if (lst != null) {
                postToday.DataSource = lst;
                postToday.DataBind();
			}
		}

		//绑定内部Repeater控件
		public void postList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			Post d =new Post();
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.SelectedItem)
			{
				//find data in parent source
				PostIndexInfo clips = (PostIndexInfo)e.Item.DataItem; 

				Repeater postInDay = (Repeater)e.Item.FindControl("postInDay");
				postInDay.DataSource = d.GetOneDay();
				postInDay.DataBind();
			} 
		}
    }
}