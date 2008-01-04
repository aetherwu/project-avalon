using System;

namespace RSS
{
	/// <summary>
	/// rssChannelCollection 的摘要说明。
	/// </summary>
	public class rssItemCollection : System.Collections.CollectionBase
	{
		public rssItem this[int index]
		{
			get { return ((rssItem)(List[index])); }
			set 
			{ 
				List[index] = value;
			}
		}
		public int Add(rssItem item)
		{
			return List.Add(item);
		}

		public rssItemCollection()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}
