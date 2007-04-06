using System;
using System.Web;
using System.Configuration;

namespace Utility
{
	public class ConnectionInfo
	{ 
		public static string GetSqlServerConnectionString()
		{
			return ConfigurationSettings.AppSettings["SQLConnString"];
		}
	}

	public class FormatCode
    {   
		public static string getBreak(string str)
		{
            str = str.Replace("\r\n", "<br />");
            return str;
        }

		public static string getEscape(string str)
		{
			str = str.Replace("<", "&lt;");
			str = str.Replace(">", "&gt;");
			str = str.Replace(Convert.ToChar(32).ToString(), "&nbsp;");
			str = str.Replace(Convert.ToChar(13).ToString(), "");
			str = str.Replace(Convert.ToChar(10).ToString()+Convert.ToChar(10).ToString(), "&lt;BR/&gt;&lt;BR/&gt;");
			str = str.Replace(Convert.ToChar(10).ToString(), "&lt;BR/&gt;");
			str = str.Replace("'", "''");
			return str;
        }

		public static string GetFormatDay(int year,int month,int day)
		{
			DateTime s_day = Convert.ToDateTime(year.ToString()+"-"+month.ToString()+"-"+day.ToString());
			return s_day.ToString("D");
		}
		
		//Code from
		//http://www.cnblogs.com/skylaugh/archive/2006/09/01/492476.html
		public static string getBasicHTML(string str)
		{
			System.Text.RegularExpressions.Regex Regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			System.Text.RegularExpressions.Regex Regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			System.Text.RegularExpressions.Regex Regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			System.Text.RegularExpressions.Regex Regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			System.Text.RegularExpressions.Regex Regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			str = Regex1.Replace(str, ""); //过滤<script></script>标记
			str = Regex2.Replace(str, ""); //过滤href=javascript: (<a>) 属性
			str = Regex3.Replace(str, " _disibledevent="); //过滤其它控件的on...事件
			str = Regex4.Replace(str, ""); //过滤iframe
			str = Regex5.Replace(str, ""); //过滤frameset
			return str;
		}

    }

}
