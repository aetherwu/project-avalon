using System;

namespace RSS
{
	/// <summary>
	/// channel 
	/// </summary>
	[Serializable()]
	public class rssChannel
	{
		private string title;
		private string link;
		private string description;
		private rssItemCollection items = new rssItemCollection();
		/// <summary>
		/// ����
		/// </summary>
		public string Title
		{
			get{return title;}
			set{title=value.ToString();}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Link
		{
			get{return link;}
			set{link=value.ToString();}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Description
		{
			get{return description;}
			set{description=value.ToString();}
		}
		public rssItemCollection Items
		{
			get { return items; }
		}

		public rssChannel(){}
	}
}
