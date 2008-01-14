using System;

using Rss;
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
		private DateTime localtime;
		public void loadRSS()
		{
			Avalon.Web._global.i++;

			Source src = new Source();
			sc = src.GetOneSource();
			if(sc.Type=="avalon") return;
			
			RssFeed feed = RssFeed.Read(sc.Source);
            RssChannel channel = (RssChannel)feed.Channels[0];
            RssItemCollection items = (RssItemCollection)channel.Items;
            DateTime lastUpdate = channel.Items.LatestPubDate();

			//if modified
            if (lastUpdate > sc.LastUpdate)
            {
				//foreach items
                for (int i = 0; i < channel.Items.Count-1; i++)
                {
                    //if items pudate > feed's last modify time
                    //give up the else
                    if (channel.Items[i].PubDate > sc.LastUpdate)
                    {
                        //save one new item into database
                        Clip clip = new Clip();
                        //对不同Feed的Item，例如Twitter、Del.icio.us、Flickr，需要处理成理想的格式然后才能入库。
                        content = Fliter.getContent(sc.Type, channel.Items[i].Title, channel.Items[i].Description, channel.Items[i].Link.ToString());
						if(sc.TimeZone!=0) {
							localtime = channel.Items[i].PubDate.AddHours(sc.TimeZone);
						}else{
							localtime = channel.Items[i].PubDate;
						}
                        ClipInfo cp = new ClipInfo(
                            0,
                            content,
                            localtime,
                            channel.Items[i].Link.ToString(),
							sc.Type,
                            sc.Owner
                        );
                        clip.Update(cp);
                    }
                }
				//updated the last modify time of Feed
                sc.LastUpdate = lastUpdate;
			}
			//源的updateHit加1，不管是否更新过HIT都要加1
			sc.UpdateHit++;
			src.Update(sc);
		}
	}
}
