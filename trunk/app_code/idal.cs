using System;
using System.Collections.Generic;

using Model;

namespace IDAL
{
	public interface IPost
	{
		void Insert(PostInfo newPost);
		IList<PostInfo> GetOneDay(int year,int month,int day);
		IList<PostInfo> GetRecentPost();
		IList<PostIndexInfo> GetDays(int year,int month,int day,int page,string keywords,bool isRSS,int limit);
		IList<ArchiveIndexInfo> GetArchives();
	}

	public interface IComment
	{
		void Insert(CommentInfo newComment);
		IList<CommentInfo> GetCommentsByLog(DateTime logTime);
		IList<CommentInfo> GetRecentComment();
	}

	public interface IRefer
	{
		void Insert(ReferInfo newRefer);
		IList<ReferIndexInfo> GetRefersByLog(DateTime logTime);
	}

}