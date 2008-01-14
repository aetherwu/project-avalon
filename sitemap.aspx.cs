using System;
using System.Web;   
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

	public partial class _sitmap : System.Web.UI.Page　
	{

		private IList<ClipIndexInfo> clips;
		private IList<ArchiveIndexInfo> archives;

		private int _year;
		private int _month;
		private int _day;
		private int _page;
		private string _keyword;
		private DateTime _begin;
		private DateTime now;

	　　protected void Page_Load(object sender, EventArgs e)　
		{
			
			Clip clip = new Clip();
            clips = clip.GetDays(_year, _month, _day, _page, _keyword, 1, 9999, _begin, 1);
			archives = clip.GetArchives();

            if (clips != null)
            {
                clipList.DataSource = clips;
                clipList.DataBind();
			}


			if (archives != null) {
                monthList.DataSource = archives;
                monthList.DataBind();
			}

		}

	}

}