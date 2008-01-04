using System;

using RSS;
using Model;
using BLL;
using Utility;

namespace Live
{

	//日志索引，因为日志里面还包含一个列表
	public class Runer
	{

		private SourceInfo sc;
		private string content;
		public void loadRSS()
		{
			Avalon.Web._global.i++;

			Source src = new Source();
			sc = src.GetOneSource();
			
			rssFeed feed = new rssFeed(sc.Source,sc.LastUpdate);
			feed.read();

			//if modified
			if (sc.LastUpdate != feed.LastModified) {
				//foreach items
				foreach (rssItem item in feed.Channel.Items) {
					//if items pudate > feed's last modify time
					//give up the else
					if(Convert.ToDateTime(item.PubDate) > sc.LastUpdate) {
						//save one new item into database
						Clip clip = new Clip();
						//对不同Feed的Item，例如Twitter、Del.icio.us、Flickr，需要处理成理想的格式然后才能入库。
						content = Fliter.getContent(sc.Type, item.Title, item.Description ,item.Link.ToString());
						ClipInfo cp = new ClipInfo(
							0,
							sc.ID,
							content,
							item.Link.ToString(),
							Convert.ToDateTime(item.PubDate)
						);
						clip.Update(cp);
					}
				}
				//updated the last modify time of Feed
				sc.LastUpdate=feed.Channels[0].LastBuildDate;
				//源的updateHit加1
				sc.UpdateHit++;
				src.Update(sc);
			}
		}
	}
}
