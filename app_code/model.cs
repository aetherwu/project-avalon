using System;

//�����ݿ�Ϊ������������������Ҫ���ݺ͵��õ�����ģ��
namespace Model
{

	//��־��������Ϊ��־���滹����һ���б�
	public class ClipIndexInfo
	{
		private DateTime postTime;

		public ClipIndexInfo(DateTime postTime)
		{
			this.postTime = postTime;
		}

		public DateTime PostTime { get	{ return postTime; } }
	}

	//��־Դ
	public class SourceInfo
	{
		private int id;
		private string owner; //������
		private string type; //����Ӧ��
		private string site; //��ϸλ��
		private string source; //Feed/XML���κ�Э��� URL
		private DateTime lastUpdate; 
		private int timeZone; //ʱ��
		private int updateHit;

		public SourceInfo(int id, string owner, string type, string site, string source, DateTime lastUpdate, int timeZone, int updateHit)
		{
			this.id = id;
			this.owner = owner;
			this.type = type;
			this.site = site;
			this.source = source;
			this.lastUpdate = lastUpdate;
			this.timeZone = timeZone;
			this.updateHit = updateHit;
		}

		public int ID { get	{ return id; } set { id = value; } }
		public string Type { get	{ return type; } set { type = value; } }
		public string Owner { get	{ return owner; } set { owner = value; } }
		public string Site { get	{ return site; } set { site = value; } }
		public string Source { get	{ return source; } set { source = value; } }
		public DateTime LastUpdate { get	{ return lastUpdate; } set { lastUpdate = value; } }
		public int TimeZone { get	{ return timeZone; } set { timeZone = value; } }
		public int UpdateHit { get	{ return updateHit; } set { updateHit = value; } }
	}

	//��־
	public class ClipInfo
	{
		private int id;
		private string content;
		private DateTime postTime; 
		private int sourceID; //��ӦSourceԴ�е�ID
		private string link;

		public ClipInfo(int id, string content, DateTime postTime, int sourceID, string link)
		{
			this.id = id;
			this.content = content;
			this.postTime = postTime;
			this.sourceID = sourceID;
			this.link = link;
		}

		public int ID { get	{ return id; } set { id = value; } }
		public string Content { get	{ return content; } set { content = value; } }
		public DateTime PostTime { get	{ return postTime; } set { postTime = value; } }
		public int SourceID { get { return sourceID; } set { sourceID = value; } }
		public string Link { get	{ return link; } set { link = value; } }
	}

	//����
	public class CommentInfo
	{
		private int id;
		private DateTime logTime;
		private string content;
		private DateTime postTime;
		private string author;
		private string homepage;
		private string ip;

		public CommentInfo(int id, DateTime logTime, string author, string content,string homepage, DateTime postTime,  string ip)
		{
			this.id = id;
			this.logTime = logTime;
			this.content = content;
			this.postTime = postTime;
			this.author = author;
			this.homepage = homepage;
			this.ip = ip;
		}

		public int ID { get	{ return id; } }
		public DateTime LogTime { get	{ return logTime; } }
		public string Content { get	{ return content; } }
		public string Author { get	{ return author; } }
		public string Homepage { get	{ return homepage; } }
		public DateTime PostTime { get	{ return postTime; } }
		public string IP { get	{ return ip; } }

	}

	//���´浵���б�
	public class ArchiveIndexInfo
	{
		private DateTime month;
		private int count;

		public ArchiveIndexInfo(DateTime month, int count)
		{
			this.month = month;
			this.count = count;
		}

		public DateTime Month { get	{ return month; } }
		public int Count { get	{ return count; } }
	}

}
