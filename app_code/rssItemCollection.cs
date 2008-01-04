using System;

namespace RSS
{
	/// <summary>
	/// rssChannelCollection ��ժҪ˵����
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
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
	}
}
