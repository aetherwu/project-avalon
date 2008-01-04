using System;

using Rss;
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
			
			RssFeed feed = RssFeed.Read(sc.Source);
            RssChannel channel = (RssChannel)feed.Channels[0];
            RssItemCollection items = (RssItemCollection)channel.Items;
            DateTime lastUpdate = channel.Items.LatestPubDate();

			//if modified
            if (sc.LastUpdate != lastUpdate)
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
                        //�Բ�ͬFeed��Item������Twitter��Del.icio.us��Flickr����Ҫ���������ĸ�ʽȻ�������⡣
                        content = Fliter.getContent(sc.Type, channel.Items[i].Title, channel.Items[i].Description, channel.Items[i].Link.ToString());
                        ClipInfo cp = new ClipInfo(
                            0,
                            sc.ID,
                            content,
                            channel.Items[i].Link.ToString(),
                            channel.Items[i].PubDate
                        );
                        clip.Update(cp);
                    }
                }
				//updated the last modify time of Feed
                sc.LastUpdate = lastUpdate;
			}
			//Դ��updateHit��1�������Ƿ���¹�HIT��Ҫ��1
			sc.UpdateHit++;
			src.Update(sc);
		}
	}
}
