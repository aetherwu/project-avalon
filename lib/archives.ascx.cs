using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class archives : System.Web.UI.UserControl {

		private IList<ArchiveIndexInfo> ar;

        public void Page_Load(object sender, EventArgs e) {

			Clip p = new Clip();
			ar = p.GetArchives();

			if (ar != null) {
                monthList.DataSource = ar;
                monthList.DataBind();
			}
        }
    }

}