using System;
using System.Collections.Generic;

using Model;

namespace IDAL
{
	public interface IClip
	{
		void Update(ClipInfo existdClip);
		void Delete(ClipInfo existdClip);
		IList<ClipIndexInfo> GetDays(int year, int month, int day, int personID, int limit, DateTime after, bool getPost);
		IList<ClipInfo> GetOneDay(int year, int month, int day, int personID, bool getPost);
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

	public interface IPerson
	{
		void Update(PersonInfo person);
		PersonInfo GetPerson(string name);
	}

}