using System;

//以数据库为基础构建程序中所需要传递和调用的数据模型
namespace Model
{

	//日志索引，因为日志里面还包含一个列表
	public class ClipIndexInfo
	{
		private DateTime postTime;

		public ClipIndexInfo(DateTime postTime)
		{
			this.postTime = postTime;
		}

		public DateTime PostTime { get	{ return postTime; } }
	}

	//日志源
	public class SourceInfo
	{
		private int id;
		private int owner; //所有者
		private string type; //所在应用
		private string site; //详细位置
		private string source; //Feed/XML等任何协议的 URL
		private DateTime lastUpdate; 
		private int timeZone; //时区
		private int updateHit;
		private string doing;

        public SourceInfo(int id, int owner, string type, string site, string source, DateTime lastUpdate, int timeZone, int updateHit, string doing)
		{
			this.id = id;
			this.owner = owner;
			this.type = type;
			this.site = site;
			this.source = source;
			this.lastUpdate = lastUpdate;
			this.timeZone = timeZone;
			this.updateHit = updateHit;
			this.doing = doing;
		}

		public int ID { get	{ return id; } set { id = value; } }
		public string Type { get	{ return type; } set { type = value; } }
        public int Owner { get { return owner; } set { owner = value; } }
		public string Site { get	{ return site; } set { site = value; } }
		public string Source { get	{ return source; } set { source = value; } }
		public DateTime LastUpdate { get	{ return lastUpdate; } set { lastUpdate = value; } }
		public int TimeZone { get	{ return timeZone; } set { timeZone = value; } }
		public int UpdateHit { get	{ return updateHit; } set { updateHit = value; } }
		public string Doing { get	{ return doing; } set { doing = value; } }
	}

	//日志
	public class ClipInfo
	{
		private int id;
		private string content;
		private DateTime postTime; 
		private string link;
		private string sourceType; //对应Source源
        private int sourceOwner;
		private string sourceLink;
		private string sourceDoing;

        public ClipInfo(int id, string content, DateTime postTime, string link, string sourceType, int sourceOwner, string sourceLink, string sourceDoing)
		{
			this.id = id;
			this.content = content;
			this.postTime = postTime;
			this.link = link;
			this.sourceType = sourceType;
            this.sourceOwner = sourceOwner;
			this.sourceLink = sourceLink;
			this.sourceDoing = sourceDoing;
		}
        public ClipInfo(int id, string content, DateTime postTime, string link, string sourceType, int sourceOwner)
        {
            this.id = id;
            this.content = content;
            this.postTime = postTime;
            this.link = link;
            this.sourceType = sourceType;
            this.sourceOwner = sourceOwner;
        }

		public int ID { get	{ return id; } set { id = value; } }
		public string Content { get	{ return content; } set { content = value; } }
		public DateTime PostTime { get	{ return postTime; } set { postTime = value; } }
		public string Link { get	{ return link; } set { link = value; } }
		public string SourceType { get	{ return sourceType; } set { sourceType = value; } }
		public string SourceLink { get	{ return sourceLink; } set { sourceLink = value; } }
        public string SourceDoing { get { return sourceDoing; } set { sourceDoing = value; } }
        public int SourceOwner { get { return sourceOwner; } set { sourceOwner = value; } }
	}

	//评论
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

	//按月存档的列表
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
