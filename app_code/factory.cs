using System;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{
	public class Post
	{
		public static IDAL.IPost Create()
		{
			return new SQLServerDAL.Post();
		}
	}

	public class Comment
	{
		public static IDAL.IComment Create()
		{
			return new SQLServerDAL.Comment();
		}
	}

	public class Source
	{
		public static IDAL.ISource Create()
		{
			return new SQLServerDAL.Source();
		}
	}

	public class Clip
	{
		public static IDAL.IClip Create()
		{
			return new SQLServerDAL.Clip();
		}
	}


}