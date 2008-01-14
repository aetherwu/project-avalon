using System;
using System.Text;
using System.Collections.Generic;

using Model;
using IDAL;

//业务逻辑
namespace BLL
{

	//日志操作
	public class Clip
	{

		//新增//更新
		public void Update(ClipInfo existdClip) {
			IClip dal = DALFactory.Clip.Create();
			dal.Update(existdClip);
		}

		//删除
		public void Delete(ClipInfo existdClip) {
			IClip dal = DALFactory.Clip.Create();
			dal.Delete(existdClip);
		}

		//获取指定带有查询条件的日志索引
		public IList<ClipIndexInfo> GetDays(int year,int month,int day,int page,string keywords,int getType,int limit,DateTime after, int personID)
		{
			IClip dal = DALFactory.Clip.Create();
            return dal.GetDays(year, month, day, page, keywords, getType, limit, after, personID);
		}

		//获取指定某天的日志
		public IList<ClipInfo> GetOneDay(int year,int month,int day, int personID,int getType)
		{
			IClip dal = DALFactory.Clip.Create();
			return dal.GetOneDay(year, month, day, personID,getType);
		}

		//获取一组默认的日志索引
		public IList<ClipIndexInfo> GetDays()
		{
			IClip dal = DALFactory.Clip.Create();
			return dal.GetDays();
		}

		//获取默认的一天日志
		public IList<ClipInfo> GetOneDay()
		{
			IClip dal = DALFactory.Clip.Create();
			return dal.GetOneDay();
		}

		//输出按月存档的列表
		public IList<ArchiveIndexInfo> GetArchives()
		{
			IClip dal = DALFactory.Clip.Create();
			return dal.GetArchives();
		}

	}

	//评论
	public class Comment
	{
		
		//新增评论
		public void Insert(CommentInfo newComment) {
			IComment dal = DALFactory.Comment.Create();
			dal.Insert(newComment);
		}

		/*
		TODO:
		//修改
		public void Update();
		//删除
		public void Delete();
		*/
		
		//按天读取评论
		public IList<CommentInfo> GetCommentsByLog(DateTime logTime)
		{
			IComment dal = DALFactory.Comment.Create();
			return dal.GetCommentsByLog(logTime);
		}

		//显示最近评论
		public IList<CommentInfo> GetRecentComment()
		{
			IComment dal = DALFactory.Comment.Create();
			return dal.GetRecentComment();
		}

		/*
		TODO:
		//显示全部评论，或者允许一定查询条件下的评论列表
		public IList<CommentInfo> GetComment();
		*/

	}

	//实时日志，源
	public class Source
	{
		public void Update(SourceInfo source)
		{
			ISource dal = DALFactory.Source.Create();
			dal.Update(source);
		}

		public SourceInfo GetOneSource()
		{
			ISource dal = DALFactory.Source.Create();
			return dal.GetOneSource();
		}
	}

}
