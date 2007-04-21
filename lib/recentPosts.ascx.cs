using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class recentPosts : System.Web.UI.UserControl {

		private IList<PostInfo> ci;

        public void Page_Load(object sender, EventArgs e) {

			Post c = new Post();
			ci = c.GetRecentPost();

			if (ci != null) {
                recentList.DataSource = ci;
                recentList.DataBind();
			}
        }
    }

}