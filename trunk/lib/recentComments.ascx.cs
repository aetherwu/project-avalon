using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class recentComments : System.Web.UI.UserControl {

		private IList<CommentInfo> ci;

        public void Page_Load(object sender, EventArgs e) {

			Comment c = new Comment();
			ci = c.GetRecentComment();

			if (ci != null) {
                recentComment.DataSource = ci;
                recentComment.DataBind();
			}
        }

    }

}