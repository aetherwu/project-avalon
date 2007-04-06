using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class recentComments : System.Web.UI.UserControl {

		private IList<CommentInfo> ci;

		private string _name;
		public string Name
		{
			get { return _name; }
			set { this._name = value; }
		}			
        public void Page_Load(object sender, EventArgs e) {

			Comment c = new Comment();
			ci = c.GetRecentComment();

			this.postType.Text= _name;

			if (ci != null) {
                recentComment.DataSource = ci;
                recentComment.DataBind();
			}
        }

    }

}