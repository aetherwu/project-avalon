using System;
using System.Web;   
using System.Web.UI.WebControls;

using WebComponents;

namespace Avalon.Web {

	public partial class _default : System.Web.UI.Page��
	{

	����protected void Page_Load(object sender, EventArgs e)��
		{
			int year = WebComponents.CleanString.GetInt(HttpContext.Current.Request["year"]);
			int month = WebComponents.CleanString.GetInt(HttpContext.Current.Request["month"]);
			string keywords = HttpContext.Current.Request["key"];

			if (year==0||month==0) {
				//��ҳ���
				clips.Limit=3;
			}else{
				//���´浵���
				clipToday.Visible=false;
				clips.Year=year;
				clips.Month=month;
			}
			//���ؼ������
			//***δ����***
		}

	}

}