using System;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{

	public class Source
	{
		public static IDAL.ISource Create()
		{
			return new SQLServerDAL.Source();
		}
	}

	public class Person
	{
		public static IDAL.IPerson Create()
		{
			return new SQLServerDAL.Person();
		}
	}

	public class Clip
	{
		public static IDAL.IClip Create()
		{
			return new SQLServerDAL.Clip();
		}
	}

	public class Comment
	{
		public static IDAL.IComment Create()
		{
			return new SQLServerDAL.Comment();
		}
	}

}