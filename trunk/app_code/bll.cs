using System;
using System.Text;
using System.Collections.Generic;

using Model;
using IDAL;

//业务逻辑
namespace BLL
{

	//日志操作
	public class Post
	{
		
		//新增
		public void Insert(PostInfo newPost) {
			IPost dal = DALFactory.Post.Create();
			dal.Insert(newPost);
		}

		//更新
		public void Update(PostInfo existdPost) {
			IPost dal = DALFactory.Post.Create();
			dal.Update(existdPost);
		}

		//删除
		public void Delete(PostInfo existdPost) {
			IPost dal = DALFactory.Post.Create();
			dal.Delete(existdPost);
		}

		//获取指定带有查询条件的日志索引
		public IList<PostIndexInfo> GetDays(int year,int month,int day,int page,string keywords,bool isRSS,int limit,DateTime after)
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetDays(year,month,day,page,keywords,isRSS,limit,after);
		}

		//获取指定某天的日志
		public IList<PostInfo> GetOneDay(int year,int month,int day)
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetOneDay(year, month, day);
		}

		//获取一组默认的日志索引
		public IList<PostIndexInfo> GetDays()
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetDays();
		}

		//获取默认的一天日志
		public IList<PostInfo> GetOneDay()
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetOneDay();
		}

		//输出按月存档的列表
		public IList<ArchiveIndexInfo> GetArchives()
		{
			IPost dal = DALFactory.Post.Create();
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

	//实时日志
	public class Clip
	{
		public void Update(ClipInfo clip)
		{
			IClip dal = DALFactory.Clip.Create();
			dal.Update(clip);
		}
	}

}
