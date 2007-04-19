using System;
using System.Web;   
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

	public partial class _sitmap : System.Web.UI.Page　
	{

		private IList<PostIndexInfo> lst;
		private IList<ArchiveIndexInfo> ar;

		private int _year;
		private int _month;
		private int _day;
		private int _page;
		private string _keyword;
		private DateTime now;

	　　protected void Page_Load(object sender, EventArgs e)　
		{
			
			Post c = new Post();
			lst = c.GetDays(_year,_month,_day,_page,_keyword,true,9999);

			if (lst != null) {
                postList.DataSource = lst;
                postList.DataBind();
			}

			Post p = new Post();
			ar = p.GetArchives();

			if (ar != null) {
                monthList.DataSource = ar;
                monthList.DataBind();
			}

		}

	}

}