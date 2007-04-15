using System;

namespace Model
{
	public class PostIndexInfo
	{
		private DateTime _PostTime;

		public PostIndexInfo(DateTime postTime)
		{
			this._PostTime = postTime;
		}

		public DateTime PostTime { get	{ return _PostTime; } }
	}

	public class PostInfo
	{
		private int _ID;
		private string _Content;
		private DateTime _PostTime;

		public PostInfo(int id, string content, DateTime postTime)
		{
			this._ID = id;
			this._Content = content;
			this._PostTime = postTime;
		}

		public int ID { get	{ return _ID; } }
		public string Content { get	{ return _Content; } }
		public DateTime PostTime { get	{ return _PostTime; } }

	}

	public class CommentInfo
	{
		private int _ID;
		private DateTime _LogTime;
		private string _Content;
		private DateTime _PostTime;
		private string _Author;
		private string _Homepage;
		private string _IP;

		public CommentInfo(int id, DateTime logTime, string author, string content,string homepage, DateTime postTime,  string ip)
		{
			this._ID = id;
			this._LogTime = logTime;
			this._Content = content;
			this._PostTime = postTime;
			this._Author = author;
			this._Homepage = homepage;
			this._IP = ip;
		}

		public int ID { get	{ return _ID; } }
		public DateTime LogTime { get	{ return _LogTime; } }
		public string Author { get	{ return _Author; } }
		public string Content { get	{ return _Content; } }
		public string Homepage { get	{ return _Homepage; } }
		public DateTime PostTime { get	{ return _PostTime; } }
		public string IP { get	{ return _IP; } }

	}

	public class ReferIndexInfo
	{
		private string _urlrefer;
		private int _count;

		public ReferIndexInfo(string urlRefer, int count)
		{
			this._urlrefer = urlRefer;
			this._count = count;
		}

		public string UrlRefer { get	{ return _urlrefer; } }
		public int Count { get	{ return _count; } }
	}

	public class ReferInfo
	{
		private int _ID;
		private DateTime _logTime;
		private string _urlrefer;
		private DateTime _requestDate;

		public ReferInfo(int id, DateTime logTime, string urlRefer, DateTime requestDate)
		{
			this._ID = id;
			this._urlrefer = urlRefer;
			this._requestDate = requestDate;
			this._logTime = logTime;
		}

		public int ID { get	{ return _ID; } }
		public DateTime LogTime { get	{ return _logTime; } }
		public string UrlRefer { get	{ return _urlrefer; } }
		public DateTime RequestDate { get	{ return _requestDate; } }
	}


	public class ArchiveIndexInfo
	{
		private DateTime _month;
		private int _count;

		public ArchiveIndexInfo(DateTime month, int count)
		{
			this._month = month;
			this._count = count;
		}

		public DateTime Month { get	{ return _month; } }
		public int Count { get	{ return _count; } }
	}

}
