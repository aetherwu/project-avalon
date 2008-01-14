using System;
using System.Text;
using System.Collections.Generic;

using Model;
using IDAL;

//ҵ���߼�
namespace BLL
{

	//��־����
	public class Clip
	{

		//����//����
		public void Update(ClipInfo existdClip) {
			IClip dal = DALFactory.Clip.Create();
			dal.Update(existdClip);
		}

		//ɾ��
		public void Delete(ClipInfo existdClip) {
			IClip dal = DALFactory.Clip.Create();
			dal.Delete(existdClip);
		}

		//��ȡָ�����в�ѯ��������־����
		public IList<ClipIndexInfo> GetDays(int year,int month,int day,int page,string keywords,int getType,int limit,DateTime after, int personID)
		{
			IClip dal = DALFactory.Clip.Create();
            return dal.GetDays(year, month, day, page, keywords, getType, limit, after, personID);
		}

		//��ȡָ��ĳ�����־
		public IList<ClipInfo> GetOneDay(int year,int month,int day, int personID,int getType)
		{
			IClip dal = DALFactory.Clip.Create();
			return dal.GetOneDay(year, month, day, personID,getType);
		}

		//��ȡһ��Ĭ�ϵ���־����
		public IList<ClipIndexInfo> GetDays()
		{
			IClip dal = DALFactory.Clip.Create();
			return dal.GetDays();
		}

		//��ȡĬ�ϵ�һ����־
		public IList<ClipInfo> GetOneDay()
		{
			IClip dal = DALFactory.Clip.Create();
			return dal.GetOneDay();
		}

		//������´浵���б�
		public IList<ArchiveIndexInfo> GetArchives()
		{
			IClip dal = DALFactory.Clip.Create();
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

}
