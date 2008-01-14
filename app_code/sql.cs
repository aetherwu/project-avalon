using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Utility;
using Model;
using IDAL;

namespace SQLServerDAL
{

	public class Clip:IClip  
	{
		private string tmpStr;
		private int i;
		private DateTime tmpDate;


		private const string PARM_ID = "@id";
        private const string PARM_SourceType = "@sourceType";
        private const string PARM_Person = "@person";
		private const string PARM_Content = "@content";
		private const string PARM_Link = "@link";
		private const string PARM_PostTime = "@postTime";

		private const string SQL_ADD = "INSERT INTO [live_Clip] VALUES(@content, CONVERT(datetime,@postTime,120), @link, @sourceType, @person)";

		private const string SQL_UPDATE = "UPDATE [live_Clip] SET [sourceType]=@sourceType, [content]=@content, [link]=@link, [postTime]=CONVERT(datetime,@postTime,120)) WHERE [c_ID]=@id";

		private const string SQL_UPDATE_BYDATE = "UPDATE [live_Clip] SET [sourceType]=@sourceType, [content]=@content, [link]=@link, [postTime]=CONVERT(datetime,@postTime,120)) WHERE [postTime]=@postTime";

		public void Update(ClipInfo clip) {

			if (clip.PostTime == Convert.ToDateTime("1999-1-1")) {
				DateTime dt = DateTime.Now;
				tmpDate = dt;
			} else {
				tmpDate = clip.PostTime;
			}

			SqlCommand cmd = new SqlCommand();

			SqlParameter parmID =  new SqlParameter(PARM_ID, SqlDbType.BigInt);
				parmID.Value = clip.ID;
                cmd.Parameters.Add(parmID);

            SqlParameter parmContent = new SqlParameter(PARM_Content, SqlDbType.NText);
                parmContent.Value = clip.Content;
                cmd.Parameters.Add(parmContent);

            SqlParameter parmPostTime = new SqlParameter(PARM_PostTime, SqlDbType.DateTime);
                parmPostTime.Value = tmpDate;
                cmd.Parameters.Add(parmPostTime);

			SqlParameter parmLink =  new SqlParameter(PARM_Link, SqlDbType.NChar);
				parmLink.Value = clip.Link;
                cmd.Parameters.Add(parmLink);

            SqlParameter parmSourceType = new SqlParameter(PARM_SourceType, SqlDbType.NChar);
                parmSourceType.Value = clip.SourceType;
                cmd.Parameters.Add(parmSourceType);

                SqlParameter parmPerson = new SqlParameter(PARM_Person, SqlDbType.BigInt);
                parmPerson.Value = clip.SourceOwner;
                cmd.Parameters.Add(parmPerson);

            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.CONN_STR)) {

                // Open the connection
                conn.Open();

                //Set up the command
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
				//TODO:fit for update by datetime
				if(clip.ID==0){
					cmd.CommandText = SQL_ADD;
				}else{
					cmd.CommandText = SQL_UPDATE;
				}

                //Execute the query
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }

		}

		//删除clip
		private const string SQL_DELETE = "DELETE FROM [live_Clip] WHERE [postTime]=@postTime";

		public void Delete(ClipInfo existdClip) {

            SqlCommand cmd = new SqlCommand();

			SqlParameter parmPostTime =  new SqlParameter(PARM_PostTime, SqlDbType.DateTime);
				parmPostTime.Value = existdClip.PostTime;
					cmd.Parameters.Add(parmPostTime);

            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.CONN_STR)) {

                // Open the connection
                conn.Open();

                //Set up the command
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL_DELETE;

                //Execute the query
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }

		}

		//取得按组聚合的日期，这组索引会调用GetOneDay()绑定每日的数据。
		//
		//1、取得某天的日志。
		//2、取得一天/某天以前的日志。
		//3、取得经过Keyword全文搜索过滤以后的数据（未实现）。
		private const string PARM_keyword = "@keyword";
		private const string PARM_page = "@page";
        private const string PARM_after = "@after";
        private const string PARM_person = "@person";
		private const string SQL_SELECT_Clips_Start = "SELECT CONVERT(char(10), postTime, 21) AS PostTime FROM [live_Clip] ";
		private const string SQL_SELECT_Clips_Begin = "Where [postTime] < @after ";
		private const string SQL_SELECT_Clips_Year = "AND YEAR(postTime) = @year ";
		private const string SQL_SELECT_Clips_Month = "AND MONTH(postTime) = @month ";
        private const string SQL_SELECT_Clips_Day = "AND DAY(postTime) = @day ";
        private const string SQL_SELECT_Clips_Person = "AND person = @person ";
		private const string SQL_SELECT_Clips_Friend = "AND (person IN (SELECT watcher FROM live_friend AS f WHERE f.holder = @person)) ";
		private const string SQL_SELECT_Clips_End = "GROUP BY CONVERT(char(10), postTime, 21) ORDER BY PostTime DESC";

        public IList<ClipIndexInfo> GetDays(int year, int month, int day, int page, string keywords, int getType, int limit, DateTime after, int personID)
        {
			
			if (limit==0)
				limit=1;
			if (after==Convert.ToDateTime("0001-1-1 0:00:00"))
			{
				DateTime dt = DateTime.Now.Date;
				after = dt;
			}

			IList<ClipIndexInfo> clips = new List<ClipIndexInfo>();
			
			SqlParameter[] parms = new SqlParameter[5];
				parms[0] = new SqlParameter(PARM_year, SqlDbType.BigInt, 4);
				parms[1] = new SqlParameter(PARM_month, SqlDbType.BigInt, 2);
				parms[2] = new SqlParameter(PARM_day, SqlDbType.BigInt, 2);
                parms[3] = new SqlParameter(PARM_after, SqlDbType.DateTime);
                parms[4] = new SqlParameter(PARM_person, SqlDbType.BigInt);
                parms[0].Value = year;
                parms[1].Value = month;
				parms[2].Value = day;
                parms[3].Value = after;
                parms[4].Value = personID;
				System.Web.HttpContext.Current.Trace.Write("DO","Get history's clips' list");

			StringBuilder sql = new StringBuilder(SQL_SELECT_Clips_Start);
				sql.Append(SQL_SELECT_Clips_Begin);
			if (year!=0)
				sql.Append(SQL_SELECT_Clips_Year);
			if (month!=0)
				sql.Append(SQL_SELECT_Clips_Month);
			if (day!=0)
                sql.Append(SQL_SELECT_Clips_Day);
            if (getType == 0 && personID != 0) {
                sql.Append(SQL_SELECT_Clips_Person);
			} else if (getType == 1 && personID != 0) {
                sql.Append(SQL_SELECT_Clips_Friend);
			}

			sql.Append(SQL_SELECT_Clips_End);
            string sqlClips = sql.ToString();

            //Execute
			i=0;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, sqlClips, parms)) {
                while (sdr.Read())
				{
					ClipIndexInfo clip = new ClipIndexInfo(Convert.ToDateTime(sdr.GetString(0)));
					clips.Add(clip);
					i++;
					if (i>=limit)
						break;
                }
            }
			return clips;
		}

		//单日的日志内容
		//
		//带有参数的日志，通常在日志列表绑定的时候调用，输出旧新排序的数据，看上去符合正常的时间数据。
		private const string PARM_year = "@year";
		private const string PARM_month = "@month";
		private const string PARM_day = "@day";

        private const string SQL_GET_DAY_START = "SELECT a.c_ID, a.content, a.postTime, a.link, b.type, b.owner, b.site, b.doing FROM [live_Clip] a INNER JOIN [live_Source] b ON (a.sourceType = b.type) AND (a.person = b.owner) WHERE YEAR(a.postTime) = @year AND MONTH(a.postTime) = @month AND DAY(a.postTime) = @day ";
		private const string SQL_GET_DAY_OWNER = "AND (a.person = @person) ";
		private const string SQL_GET_DAY_FRIEND =  "AND (a.person IN (SELECT watcher FROM live_friend AS f WHERE f.holder = @person)) ";
		private const string SQL_GET_DAY_END = "ORDER BY a.postTime ASC";

		public IList<ClipInfo> GetOneDay(int year,int month,int day,int personID,int getType)
		{ 
            IList<ClipInfo> clips = new List<ClipInfo>();

			SqlParameter[] parms = new SqlParameter[4];
				parms[0] = new SqlParameter(PARM_year, SqlDbType.BigInt, 4);
				parms[1] = new SqlParameter(PARM_month, SqlDbType.BigInt, 2);
				parms[2] = new SqlParameter(PARM_day, SqlDbType.BigInt, 2);
				parms[3] = new SqlParameter(PARM_person, SqlDbType.BigInt, 2);
				parms[0].Value = year;
				parms[1].Value = month;
				parms[2].Value = day;
				parms[3].Value = personID;
				System.Web.HttpContext.Current.Trace.Write("DO","Bind each clip in history list");

			StringBuilder sqlday = new StringBuilder(SQL_GET_DAY_START);
            if (getType == 0 && personID != 0) {
                sqlday.Append(SQL_GET_DAY_OWNER);
			} else if (getType == 1 && personID != 0) {
                sqlday.Append(SQL_GET_DAY_FRIEND);
			}
            sqlday.Append(SQL_GET_DAY_END);
            string sqlClips = sqlday.ToString();

            //Execute
			using(SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, sqlClips, parms))
			{
                while (sdr.Read())
				{
                    ClipInfo clip = new ClipInfo(
						sdr.GetInt32(0),
						FormatCode.getBreak(sdr.GetString(1)),
						sdr.GetDateTime(2),
						FormatCode.getBreak(sdr.GetString(3)),
						sdr.GetString(4),
                        sdr.GetInt32(5),
						FormatCode.getBreak(sdr.GetString(6)),
						sdr.GetString(7)
					);
                    clips.Add(clip);
                }
			}
			return clips;
		}

		//取得日志序列索引，这些索引会再次调用GetOneDay()取得并绑定每日日志。
		//
		//没有参数的GetDays，将返回今日。
		private const string SQL_SELECT_TODAY = "SELECT CONVERT(char(10), postTime, 21) AS PostTime FROM [live_Clip] Where  (YEAR(postTime) = @year) AND (MONTH(postTime) = @month) AND (DAY(postTime) = @day) GROUP BY CONVERT(char(10), postTime, 21) ORDER BY PostTime DESC";
        public IList<ClipIndexInfo> GetDays() {
			
			IList<ClipIndexInfo> clips = new List<ClipIndexInfo>();
			
			DateTime dt = DateTime.Now;
			SqlParameter[] parms = new SqlParameter[3];
				parms[0] = new SqlParameter(PARM_year, SqlDbType.BigInt, 4);
				parms[1] = new SqlParameter(PARM_month, SqlDbType.BigInt, 2);
				parms[2] = new SqlParameter(PARM_day, SqlDbType.BigInt, 2);
				parms[0].Value = dt.Year;
				parms[1].Value = dt.Month;
				parms[2].Value = dt.Day;
				System.Web.HttpContext.Current.Trace.Write("DO","Get today's clips' list");

            //Execute
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_SELECT_TODAY, parms)) {
                while (sdr.Read())
				{
					ClipIndexInfo clip = new ClipIndexInfo(Convert.ToDateTime(sdr.GetString(0)));
					clips.Add(clip);
                }
            }
			return clips;
		}

		//单日的日志内容
		//
		//没有参数的GetOneDay，将返回当天数据，并且按照新旧顺序排序
        private const string SQL_GET_TODAY = "SELECT a.c_ID, a.content, a.postTime, a.link, b.type, b.owner, b.site, b.doing FROM [live_Clip] a INNER JOIN [live_Source] b ON a.sourceType = b.type WHERE YEAR(a.postTime) = @year AND MONTH(a.postTime) = @month AND DAY(a.postTime) = @day ORDER BY a.postTime DESC";
        public IList<ClipInfo> GetOneDay()
		{ 
            IList<ClipInfo> clips = new List<ClipInfo>();

			DateTime dt = DateTime.Now;
			SqlParameter[] parms = new SqlParameter[3];
				parms[0] = new SqlParameter(PARM_year, SqlDbType.BigInt, 4);
				parms[1] = new SqlParameter(PARM_month, SqlDbType.BigInt, 2);
				parms[2] = new SqlParameter(PARM_day, SqlDbType.BigInt, 2);
				parms[0].Value = dt.Year;
				parms[1].Value = dt.Month;
				parms[2].Value = dt.Day;
				System.Web.HttpContext.Current.Trace.Write("DO","Bind each clip in today's list");

            //Execute
			using(SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_GET_TODAY, parms))
			{
                while (sdr.Read())
				{
                    ClipInfo clip = new ClipInfo(
						sdr.GetInt32(0),
						FormatCode.getBreak(sdr.GetString(1)),
						sdr.GetDateTime(2),
						FormatCode.getBreak(sdr.GetString(3)),
						sdr.GetString(4),
                        sdr.GetInt32(5),
						FormatCode.getBreak(sdr.GetString(6)),
						sdr.GetString(7)
					);
					clips.Add(clip);
                }
			}
			return clips;
		}

		//分月存档数据的索引
		//
		//
		private const string SQL_SELECT_ARCHIVES = "SELECT CONVERT(char(7), postTime, 21),COUNT(CONVERT(char(7), postTime, 21)) FROM [live_Clip] GROUP BY CONVERT(char(7), postTime, 21) ORDER BY CONVERT(char(7), postTime, 21) DESC";

        public IList<ArchiveIndexInfo> GetArchives() {

            IList<ArchiveIndexInfo> Archives = new List<ArchiveIndexInfo>();

            //Execute
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_SELECT_ARCHIVES)) {
                while (sdr.Read())
				{
                    ArchiveIndexInfo AMonth = new ArchiveIndexInfo(Convert.ToDateTime(sdr.GetString(0)),sdr.GetInt32(1));
                    Archives.Add(AMonth);
                }
            }
            return Archives;
        }

	}

	public class Comment:IComment
	{
		private string tmpStr;

		private const string PARM_LogTime = "@LogTime";
		private const string PARM_Author = "@Author";
		private const string PARM_Content = "@Content";
		private const string PARM_Homepage = "@Homepage";
		private const string PARM_IP = "@IP";
		private const string SQL_ADD = "INSERT INTO [blog_Comment] VALUES(@LogTime, @Author, @Content, @Homepage, GETDATE(), @IP)";

		public void Insert(CommentInfo newComment) {

            SqlCommand cmd = new SqlCommand();

			SqlParameter parmLogTime =  new SqlParameter(PARM_LogTime, SqlDbType.DateTime);
				parmLogTime.Value = newComment.LogTime;
					cmd.Parameters.Add(parmLogTime);

			SqlParameter parmAuthor =  new SqlParameter(PARM_Author, SqlDbType.NChar);
				parmAuthor.Value = newComment.Author;
					cmd.Parameters.Add(parmAuthor);

			SqlParameter parmContent =  new SqlParameter(PARM_Content, SqlDbType.NText);
				parmContent.Value = newComment.Content;
					cmd.Parameters.Add(parmContent);

			SqlParameter parmHomepage =  new SqlParameter(PARM_Homepage, SqlDbType.NChar);
				parmHomepage.Value = newComment.Homepage;
					cmd.Parameters.Add(parmHomepage);

			SqlParameter parmIP =  new SqlParameter(PARM_IP, SqlDbType.NChar);
				parmIP.Value = newComment.IP;
					cmd.Parameters.Add(parmIP);

            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.CONN_STR)) {

                // Open the connection
                conn.Open();

                //Set up the command
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL_ADD;

                //Execute the query
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }

		}

		//
		//List Comment
		//
		private const string PARM_logTime = "@logTime";
		private const string SQL_SELECT_COMMENTS = "SELECT * FROM [blog_Comment] Where CONVERT(char(10), log_PostTime, 21) = @logTime ORDER BY [comm_PostTime] ASC";

		public IList<CommentInfo> GetCommentsByLog(DateTime logTime)
		{ 
			CommentInfo cmt = null;
            IList<CommentInfo> CommentsByLog = new List<CommentInfo>();

			SqlParameter parm = new SqlParameter(PARM_logTime, SqlDbType.DateTime);
			parm.Value = logTime;

			using(SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_SELECT_COMMENTS, parm))
			{
                while (sdr.Read())
				{
					cmt = new CommentInfo(sdr.GetInt32(0), sdr.GetDateTime(1), sdr.GetString(2), FormatCode.getBreak(sdr.GetString(3)) , sdr.GetString(4), sdr.GetDateTime(5), sdr.GetString(6));
                    CommentsByLog.Add(cmt);
				}
			}
			return CommentsByLog;
		}

		//
		//Recent Comment
		//
		private const string SQL_SELECT_COMMENT_RECENT = "SELECT TOP 10 * FROM [blog_Comment] Where [comm_Author]!='Aether' ORDER BY [comm_ID] DESC";

        public IList<CommentInfo> GetRecentComment() {

            IList<CommentInfo> RecentComment = new List<CommentInfo>();

            //Execute
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_SELECT_COMMENT_RECENT)) {
                while (sdr.Read())
				{
					tmpStr = System.Text.RegularExpressions.Regex.Replace(sdr.GetString(3),"<[^>]+>","");
					if (tmpStr.Length>34)
						tmpStr = tmpStr.Substring(0,34) + "...";
					
                    CommentInfo Comment = new CommentInfo(sdr.GetInt32(0), sdr.GetDateTime(1), sdr.GetString(2), tmpStr,sdr.GetString(4), sdr.GetDateTime(5), sdr.GetString(6));
                    RecentComment.Add(Comment);
                }
            }
            return RecentComment;
        }
	}

	public class Source:ISource
	{

		private const string PARM_id = "@id";
		private const string PARM_owner = "@owner";
		private const string PARM_type = "@type";
		private const string PARM_site = "@site";
		private const string PARM_source = "@source";
		private const string PARM_lastUpdate = "@lastUpdate";
		private const string PARM_tomezone = "@tomezone";
		private const string PARM_updateHit = "@updateHit";

		private const string SQL_ADD = "INSERT INTO [live_Source] VALUES(@owner,@type, @site, @source, CONVERT(datetime,@lastUpdate,120), @tomezone, @updateHit)";

		private const string SQL_UPDATE = "UPDATE [live_Source] SET [owner]=@owner,[type]=@type, [site]=@site,[source]=@source,[lastUpdate]=@lastUpdate,[tomezone]=@tomezone,[updateHit]=@updateHit WHERE [s_ID]=@id";

		public void Update(SourceInfo source) {

            SqlCommand cmd = new SqlCommand();

			SqlParameter parmID =  new SqlParameter(PARM_id, SqlDbType.BigInt);
				parmID.Value = source.ID;
					cmd.Parameters.Add(parmID);

			SqlParameter parmOwner =  new SqlParameter(PARM_owner, SqlDbType.NChar);
				parmOwner.Value = source.Owner;
					cmd.Parameters.Add(parmOwner);

			SqlParameter parmType =  new SqlParameter(PARM_type, SqlDbType.NChar);
				parmType.Value = source.Type;
					cmd.Parameters.Add(parmType);

			SqlParameter parmSite =  new SqlParameter(PARM_site, SqlDbType.NChar);
				parmSite.Value = source.Site;
					cmd.Parameters.Add(parmSite);

			SqlParameter parmSource =  new SqlParameter(PARM_source, SqlDbType.NChar);
				parmSource.Value = source.Source;
					cmd.Parameters.Add(parmSource);

			SqlParameter parmLastUpdate =  new SqlParameter(PARM_lastUpdate, SqlDbType.DateTime);
				parmLastUpdate.Value = source.LastUpdate;
					cmd.Parameters.Add(parmLastUpdate);

			SqlParameter parmTimeZone =  new SqlParameter(PARM_tomezone, SqlDbType.BigInt);
				parmTimeZone.Value = source.TimeZone;
					cmd.Parameters.Add(parmTimeZone);

			SqlParameter parmUpdateHit =  new SqlParameter(PARM_updateHit, SqlDbType.BigInt);
				parmUpdateHit.Value = source.UpdateHit;
					cmd.Parameters.Add(parmUpdateHit);

            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.CONN_STR)) {

                // Open the connection
                conn.Open();

                //Set up the command
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

				if(source.ID==0){
					cmd.CommandText = SQL_ADD;
				}else{
					cmd.CommandText = SQL_UPDATE;
				}

                //Execute the query
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }

		}

		//获取一个需要更新的Source源，规则是updateHit数值最小的那个，更新以后其值加1
		private const string SQL_SELECT_NEXT = "SELECT TOP 1 * FROM [live_Source] ORDER BY [updateHit] ASC";
		public SourceInfo GetOneSource()
		{ 
			SourceInfo src = null;
			//获取源
			using(SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_SELECT_NEXT))
			{
                while (sdr.Read())
				{
					src = new SourceInfo(
						sdr.GetInt32(0),
                        sdr.GetInt32(1),
						sdr.GetString(2),
						sdr.GetString(3),
						sdr.GetString(4),
						sdr.GetDateTime(5),
						sdr.GetInt32(6),
						sdr.GetInt32(7),
						sdr.GetString(8)
					);
				}
			}
			return src;
		}

	}

}

