using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Model;
using BLL;

namespace Avalon.Web {

    public partial class refers : System.Web.UI.UserControl {

		private IList<ReferIndexInfo> rl;

		private DateTime _logTime;
		public DateTime LogTime
		{
			get { return _logTime; }
			set { this._logTime = value; }
		}			
        public void Page_Load(object sender, EventArgs e) {

			Refer c = new Refer();
			rl = c.GetRefersByLog(_logTime);

			if (rl != null) {
                referList.DataSource = rl;
                referList.DataBind();
			}
        }
    }

}