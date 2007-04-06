using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class recentPosts : System.Web.UI.UserControl {

		private IList<PostInfo> ci;

		private string _name;
		public string Name
		{
			get { return _name; }
			set { this._name = value; }
		}			
        public void Page_Load(object sender, EventArgs e) {

			Post c = new Post();
			ci = c.GetRecentPost();

			this.postType.Text= _name;

			if (ci != null) {
                recentList.DataSource = ci;
                recentList.DataBind();
			}
        }
    }

}