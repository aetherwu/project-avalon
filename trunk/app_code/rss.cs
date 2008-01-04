using System;
using System.Xml;
using System.IO;
using System.Net;
using System.Text;
namespace RSS
{
	/// <summary>
	/// rssFeed 的摘要说明。
	/// </summary>
	public class rssFeed
	{
		private string url;
		private System.DateTime lastModified;
		private System.DateTime lastRssDate;
		private rssChannel channel = new rssChannel();
		public string Url
		{
			get { return url; }
			set { url=value; }
		}
		public System.DateTime LastModified
		{
			get {return lastModified;}
		}
		public System.DateTime LastRssDate
		{
			set {lastRssDate=value;}
		}
		public rssChannel Channel
		{
			get {return channel; }
		}

		public rssFeed(){}
		public rssFeed(string url,System.DateTime dt)
		{
			this.url=url;
			this.lastRssDate=dt;
		}
		public void read()
		{
			XmlDocument xDoc=new XmlDocument();
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Timeout=15000;
			request.UserAgent=@"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.40607; .NET CLR 1.1.4322)";
			Stream stream;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			this.lastModified = response.LastModified;
			stream = response.GetResponseStream();
			StreamReader sr;
				//System.Xml.XmlReader = new XmlReader();
				//stream=Encoding.Convert(Encoding.GetEncoding("GBK"),Encoding.GetEncoding("gb2312"),Convert.ToSByte(stream));
			if(this.getch(response.Headers["Content-Type"].ToString())=="GBK")
			{
				sr= new StreamReader(stream,System.Text.Encoding.GetEncoding("GB2312"));
				xDoc.Load(sr);

			}
			else
			{
				//				sr= new StreamReader(stream,System.Text.Encoding.UTF8);
				xDoc.Load(stream);
			}
			if(this.lastRssDate<this.lastModified)
			{
				XmlNodeList xnList=xDoc.DocumentElement["channel"].SelectNodes("item");
				//				XmlNodeList xnList=xDoc.SelectNodes("items");
				int a= xnList.Count;
				foreach(XmlNode xNode in xnList)
				{				
					rssItem rt=new rssItem();
					rt.Title=xNode.SelectSingleNode("title").InnerText.Replace("'","''");
					rt.Link=xNode.SelectSingleNode("link").InnerText.Replace("'","''");
					rt.Description=xNode.SelectSingleNode("description").InnerText.Replace("'","''");
					try
					{
						rt.PubDate=xNode.SelectSingleNode("pubDate").InnerText;
					}
					catch
					{
						rt.PubDate=this.lastModified.ToString();
					}
					channel.Items.Add(rt);
				}
			}
		}
		private string getch(string s)
		{
			int l=s.IndexOf("charset=")+8;
			return s.Substring(l,s.Length-l);
		}

	}
}
