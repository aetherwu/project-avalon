using System;
using System.Collections.Generic;

using Model;

namespace IDAL
{
	public interface IPost
	{
		void Insert(PostInfo newPost);
		void Update(PostInfo existdPost);
		void Delete(PostInfo existdPost);
		IList<PostIndexInfo> GetDays();
		IList<PostInfo> GetOneDay();
		IList<PostIndexInfo> GetDays(int year,int month,int day,int page,string keywords,bool isRSS,int limit,DateTime after);
		IList<PostInfo> GetOneDay(int year,int month,int day);
		IList<ArchiveIndexInfo> GetArchives();
	}

	public interface IComment
	{
		void Insert(CommentInfo newComment);
		IList<CommentInfo> GetCommentsByLog(DateTime logTime);
		IList<CommentInfo> GetRecentComment();
	}

	public interface ISource
	{
		void Update(SourceInfo source);
		SourceInfo GetOneSource();
	}

	public interface IClip
	{
		void Update(ClipInfo clip);
	}

}