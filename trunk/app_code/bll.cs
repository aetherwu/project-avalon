using System;
using System.Text;
using System.Collections.Generic;

using Model;
using IDAL;

namespace BLL
{

	public class Post
	{

		public void Insert(PostInfo newPost) {
			IPost dal = DALFactory.Post.Create();
			dal.Insert(newPost);
		}

		public IList<PostIndexInfo> GetDays(int year,int month,int day,int page,string keywords,bool isRSS,int limit,DateTime after)
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetDays(year,month,day,page,keywords,isRSS,limit,after);
		}
			public IList<PostInfo> GetOneDay(int year,int month,int day)
			{
				IPost dal = DALFactory.Post.Create();
				return dal.GetOneDay(year, month, day);
			}

		public IList<PostIndexInfo> GetDays()
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetDays();
		}
			public IList<PostInfo> GetOneDay()
			{
				IPost dal = DALFactory.Post.Create();
				return dal.GetOneDay();
			}

		public IList<ArchiveIndexInfo> GetArchives()
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetArchives();
		}

	}

	public class Comment
	{

		public void Insert(CommentInfo newComment) {
			IComment dal = DALFactory.Comment.Create();
			dal.Insert(newComment);
		}
		
		public IList<CommentInfo> GetCommentsByLog(DateTime logTime)
		{
			IComment dal = DALFactory.Comment.Create();
			return dal.GetCommentsByLog(logTime);
		}

		public IList<CommentInfo> GetRecentComment()
		{
			IComment dal = DALFactory.Comment.Create();
			return dal.GetRecentComment();
		}

	}

	public class Refer
	{

		public void Insert(ReferInfo newRefer) {
			IRefer dal = DALFactory.Refer.Create();
			dal.Insert(newRefer);
		}
		
		public IList<ReferIndexInfo> GetRefersByLog(DateTime logTime)
		{
			IRefer dal = DALFactory.Refer.Create();
			return dal.GetRefersByLog(logTime);
		}

	}

}
