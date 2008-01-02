using System;
using System.Web;	 
using System.Web.UI.WebControls;

using Rss;
using Model;
using BLL;
using Utility;

namespace Live
{
	public class Runer
	{

		private SourceInfo sc;
		private string content;
		public void loadRSS(Object state) {
			
			/*
			prapare the source
			Read out the source config
			- source URL
			- last modify time
			*/
			Source src = new Source();
			sc = src.GetOneSource();
			
			//read the Feed
			//example: "http://localhost/rss"
			//try {

				Avalon.Web._global.i++;

				RssFeed feed = RssFeed.Read(sc.Source);

				//if modified
				if (sc.LastUpdate != feed.Channels[0].LastBuildDate) {
					//foreach items
					foreach (RssItem item in feed.Channels[0].Items) {
						//if items pudate > feed's last modify time
						//give up the else
						if(item.PubDate > sc.LastUpdate) {
							//save one new item into database
							Clip clip = new Clip();
							//对不同Feed的Item，例如Twitter、Del.icio.us、Flickr，需要处理成理想的格式然后才能入库。
							content = Fliter.getContent(sc.Type, item.Title, item.Description ,item.Link.ToString());
							ClipInfo cp = new ClipInfo(
								0,
								sc.ID,
								content,
								item.Link.ToString(),
								item.PubDate
							);
							clip.Update(cp);
						}
					}

					//updated the last modify time of Feed
					//源的updateHit加1
					//sc.LastUpdate=feed.Channels[0].LastBuildDate;
					sc.UpdateHit++;
					src.Update(sc);

				}

			//} catch(Exception ae) {
				//write a failure log, or read one default feed.
			//}

		}
	}

}