using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class archives : System.Web.UI.UserControl {

		private IList<PostIndexInfo> ar;

        public void Page_Load(object sender, EventArgs e) {

			Post p = new Post();
			ar = p.GetArchives();

			if (ar != null) {
                monthList.DataSource = ar;
                monthList.DataBind();
			}
        }
    }

}