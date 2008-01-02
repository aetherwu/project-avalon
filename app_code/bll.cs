using System;
using System.Text;
using System.Collections.Generic;

using Model;
using IDAL;

//ҵ���߼�
namespace BLL
{

	//��־����
	public class Post
	{
		
		//����
		public void Insert(PostInfo newPost) {
			IPost dal = DALFactory.Post.Create();
			dal.Insert(newPost);
		}

		//����
		public void Update(PostInfo existdPost) {
			IPost dal = DALFactory.Post.Create();
			dal.Update(existdPost);
		}

		//ɾ��
		public void Delete(PostInfo existdPost) {
			IPost dal = DALFactory.Post.Create();
			dal.Delete(existdPost);
		}

		//��ȡָ�����в�ѯ��������־����
		public IList<PostIndexInfo> GetDays(int year,int month,int day,int page,string keywords,bool isRSS,int limit,DateTime after)
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetDays(year,month,day,page,keywords,isRSS,limit,after);
		}

		//��ȡָ��ĳ�����־
		public IList<PostInfo> GetOneDay(int year,int month,int day)
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetOneDay(year, month, day);
		}

		//��ȡһ��Ĭ�ϵ���־����
		public IList<PostIndexInfo> GetDays()
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetDays();
		}

		//��ȡĬ�ϵ�һ����־
		public IList<PostInfo> GetOneDay()
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetOneDay();
		}

		//������´浵���б�
		public IList<ArchiveIndexInfo> GetArchives()
		{
			IPost dal = DALFactory.Post.Create();
			return dal.GetArchives();
		}

	}

	//����
	public class Comment
	{
		
		//��������
		public void Insert(CommentInfo newComment) {
			IComment dal = DALFactory.Comment.Create();
			dal.Insert(newComment);
		}

		/*
		TODO:
		//�޸�
		public void Update();
		//ɾ��
		public void Delete();
		*/
		
		//�����ȡ����
		public IList<CommentInfo> GetCommentsByLog(DateTime logTime)
		{
			IComment dal = DALFactory.Comment.Create();
			return dal.GetCommentsByLog(logTime);
		}

		//��ʾ�������
		public IList<CommentInfo> GetRecentComment()
		{
			IComment dal = DALFactory.Comment.Create();
			return dal.GetRecentComment();
		}

		/*
		TODO:
		//��ʾȫ�����ۣ���������һ����ѯ�����µ������б�
		public IList<CommentInfo> GetComment();
		*/

	}

	//ʵʱ��־��Դ
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

	//ʵʱ��־
	public class Clip
	{
		public void Update(ClipInfo clip)
		{
			IClip dal = DALFactory.Clip.Create();
			dal.Update(clip);
		}
	}

}
