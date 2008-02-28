using System;
using System.IO;
using System.Xml;

using RssToolkit.Rss;
using Model;
using BLL;
using Utility;

namespace Live
{


	public class Runer
	{

		private SourceInfo sc;
		private string content;
        private string outerXml;
        private DateTime thisTime;
		public void loadRSS()
		{
			Avalon.Web._global.i++;

			Source src = new Source();
			sc = src.GetOneSource();
			if(sc.Type=="avalon") return;

            //load can convert to rss 2.0
            using (Stream actual = DownloadManager.GetFeed(sc.Source))
            {
                using (XmlTextReader reader = new XmlTextReader(actual))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            break;
                        }
                    }
                    outerXml = RssXmlHelper.ConvertToRssXml(reader.ReadOuterXml());
                }
            }

            if (outerXml != null)
            {
                RssDocument rssDoc = RssDocument.Load(outerXml);
                RssChannel feed = rssDoc.Channel;
                DateTime lastUpdate = RssXmlHelper.Parse(feed.LastBuildDate);
                if (feed.LastBuildDate == "")
                {
                    lastUpdate.AddHours(8);
                }
                else {
                    lastUpdate.AddHours(sc.TimeZone);
                }

			    //if modified
                if (lastUpdate > sc.LastUpdate)
                {
				    //foreach items
                    for (int i = 0; i < feed.Items.Count-1; i++)
                    {
                        //if items pudate > feed's last modify time
                        //give up the else
                        thisTime = feed.Items[i].PubDateParsed.AddHours(sc.TimeZone);
                        if (thisTime > sc.LastUpdate)
                        {
                            //save one new item into database
                            Clip clip = new Clip();
                            //�Բ�ͬFeed��Item������Twitter��Del.icio.us��Flickr����Ҫ���������ĸ�ʽȻ�������⡣
                            content = Fliter.getContent(sc.Type, feed.Items[i].Title, feed.Items[i].Description, feed.Items[i].Link.ToString());

                            ClipInfo cp = new ClipInfo(
                                0,
                                content,
                                feed.Items[i].PubDateParsed.AddHours(sc.TimeZone),
                                feed.Items[i].Link.ToString(),
							    sc.Type,
                                sc.Owner
                            );
                            clip.Update(cp);
                            if (lastUpdate < thisTime)
                                lastUpdate = thisTime;
                        }
                    }
				    //updated the last modify time of Feed
                    //sc.LastUpdate = lastUpdate;
			    }
                //*/ 

			    //Դ��updateHit��1�������Ƿ���¹�HIT��Ҫ��1
			    sc.UpdateHit++;
			    src.Update(sc);

            }
		}
	}
}
