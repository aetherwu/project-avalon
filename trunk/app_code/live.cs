using System;

using RSS;
using Model;
using BLL;
using Utility;

namespace Live
{

	//��־��������Ϊ��־���滹����һ���б�
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
						//�Բ�ͬFeed��Item������Twitter��Del.icio.us��Flickr����Ҫ���������ĸ�ʽȻ�������⡣
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
				//Դ��updateHit��1
				sc.UpdateHit++;
				src.Update(sc);
			}
		}
	}
}
