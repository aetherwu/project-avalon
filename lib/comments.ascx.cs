using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class comments : System.Web.UI.UserControl {

		private IList<CommentInfo> cmt;

		private DateTime _logTime;
		public DateTime LogTime
		{
			get { return _logTime; }
			set { this._logTime = value; }
		}

        public void Page_Load(object sender, EventArgs e) {

			Comment c = new Comment();
			cmt = c.GetCommentsByLog(_logTime);

			if (cmt != null) {
                commentList.DataSource = cmt;
                commentList.DataBind();
			}
        }
    }

}