using System;

namespace RSS
{
	/// <summary>
	/// rssChannelCollection ��ժҪ˵����
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
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
	}
}
