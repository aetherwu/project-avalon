using System;

namespace RSS
{
	/// <summary>
	/// rssItem 的摘要说明。
	/// </summary>
	public class rssItem
	{
		private string title;
		private string link;
		private string description;
		private string pubDate;
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			get{return title;}
			set{title=value.ToString();}
		}
		/// <summary>
		/// 链接
		/// </summary>
		public string Link
		{
			get{return link;}
			set{link=value.ToString();}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			get{return description;}
			set{description=value.ToString();}
		}
		public string PubDate
		{
			get{return pubDate;}
			set{pubDate=cdate(value);}
		}
		public rssItem(){}
		private string cdate(string input)
		{
			System.DateTime dt;
			try
			{
				dt=Convert.ToDateTime(input);
			}
			catch
			{
				dt=System.DateTime.Now;
			}
			return dt.ToString();
		}
	}
}
