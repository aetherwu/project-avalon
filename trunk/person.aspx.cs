using System;
using System.Web;   
using System.Web.UI.WebControls;

using WebComponents;

namespace Avalon.Web {

	public partial class _person : System.Web.UI.Page��
	{

	����protected void Page_Load(object sender, EventArgs e)��
		{
			int year = WebComponents.CleanString.GetInt(HttpContext.Current.Request["year"]);
			int month = WebComponents.CleanString.GetInt(HttpContext.Current.Request["month"]);
			string person = HttpContext.Current.Request["person"];
			string keywords = HttpContext.Current.Request["key"];

            //check if it is existed
            

            clips.PersonID = 1;
            friendsClips.PersonID = 1;
            friendsClips.getType = 1;
			if (year==0||month==0) {
				//������ҳ���
                clips.Limit = 1;
			}else{
				//���´浵���
				//clipToday.Visible = false;
				clips.Year = year;
				clips.Month = month;
				clips.Limit = 9999;
			}
			//���ؼ������
			//***δ����***
		}

	}

}