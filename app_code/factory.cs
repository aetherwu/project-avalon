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

	public class Refer
	{
		public static IDAL.IRefer Create()
		{
			return new SQLServerDAL.Refer();
		}
	}

}