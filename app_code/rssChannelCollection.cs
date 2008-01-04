using System;

namespace RSS
{
	/// <summary>
	/// rssChannelCollection 的摘要说明。
	/// </summary>
	public class rssChannelCollection : System.Collections.CollectionBase
	{
		public rssChannel this[int index]
		{
			get { return ((rssChannel)(List[index])); }
			set 
			{ 
				List[index] = value;
			}
		}
		public int Add(rssChannel item)
		{
			return List.Add(item);
		}


		public rssChannelCollection()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}
