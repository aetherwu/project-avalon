using System;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Utility
{
	public class ConnectionInfo
	{ 
		public static string GetSqlServerConnectionString()
		{
			return ConfigurationSettings.AppSettings["SQLConnString"];
		}
	}

	public class Fliter
	{ 
		public static string getContent(string type, string title, string desc, string link)
		{
			string str;
			string uri;
			string pic;
			Regex rx;
			MatchCollection matches;
			switch (type)
			{
				case "twitter":
					str = desc.Substring( desc.IndexOf(":")+2 , desc.Length-desc.IndexOf(":")-2 );
					return str;
					break;
				case "delicious":
					str = "<a href='"+ link +"' target='_blank'>"+ title +"</a>";
					if (desc!="") {
						str = str +"<br />"+ desc;
					}
					return str;
					break;
				case "flickr":
					rx = new Regex(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
					matches = rx.Matches(desc);

					uri = matches[1].Value;
					pic = matches[2].Value;
					str = "<a href='"+ uri +"' target='_blank'><img src='"+ pic +"' alt='"+ title +"' /></a>";
					return str;
					break;
				case "douban":
					rx = new Regex(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
					matches = rx.Matches(desc);

					uri = matches[0].Value;
					pic = matches[1].Value;
					str = "<a href='"+ uri +"' target='_blank'><img src='"+ pic +"' alt='"+ title +"' /></a>";
					return str;
					break;

				default:
					str = title +"<br />"+ desc;
					return str;
					break;
			}
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
			Regex Regex1 = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
			Regex Regex2 = new Regex(@" href *= *[\s\S]*script *:", RegexOptions.IgnoreCase);
			Regex Regex3 = new Regex(@" on[\s\S]*=", RegexOptions.IgnoreCase);
			Regex Regex4 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
			Regex Regex5 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);
			str = Regex1.Replace(str, ""); //过滤<script></script>标记
			str = Regex2.Replace(str, ""); //过滤href=javascript: (<a>) 属性
			str = Regex3.Replace(str, " _disibledevent="); //过滤其它控件的on...事件
			str = Regex4.Replace(str, ""); //过滤iframe
			str = Regex5.Replace(str, ""); //过滤frameset
			return str;
		}

    }

}
