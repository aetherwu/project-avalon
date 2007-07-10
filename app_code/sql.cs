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

	public class Post:IPost  
	{
		private string tmpStr;
		private int i;
		private DateTime tmpDate;


		//新的Clip
		private const string PARM_Content = "@Content";
		private const string PARM_PostTime = "@PostTime";
		private const string SQL_ADD = "INSERT INTO blog_Post VALUES(@Content, CONVERT(datetime,@PostTime,120))";

		public void Insert(PostInfo newPost) {

			if (newPost.PostTime == Convert.ToDateTime("1999-1-1")) {
				DateTime dt = DateTime.Now;
				tmpDate = dt;
			} else {
				tmpDate = newPost.PostTime;
			}
			System.Web.HttpContext.Current.Trace.Write("createTime", tmpDate.ToString() );

			SqlCommand cmd = new SqlCommand();

			SqlParameter parmContent =  new SqlParameter(PARM_Content, SqlDbType.NText);
				parmContent.Value = newPost.Content;
					cmd.Parameters.Add(parmContent);

			SqlParameter parmPostTime =  new SqlParameter(PARM_PostTime, SqlDbType.DateTime);
				parmPostTime.Value = tmpDate;
					cmd.Parameters.Add(parmPostTime);

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

		//修改clip
		private const string SQL_EDIT = "UPDATE [blog_Post] SET [log_Content]=@Content WHERE [log_PostTime]=@PostTime";

		public void Update(PostInfo existdPost) {

            SqlCommand cmd = new SqlCommand();

			SqlParameter parmContent =  new SqlParameter(PARM_Content, SqlDbType.NText);
				parmContent.Value = existdPost.Content;
					cmd.Parameters.Add(parmContent);

			SqlParameter parmPostTime =  new SqlParameter(PARM_PostTime, SqlDbType.DateTime);
				parmPostTime.Value = existdPost.PostTime;
					cmd.Parameters.Add(parmPostTime);

				System.Web.HttpContext.Current.Trace.Write("logTime",existdPost.PostTime.ToString() );
				System.Web.HttpContext.Current.Trace.Write("EDIT CMD",SQL_EDIT );

            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.CONN_STR)) {

                // Open the connection
                conn.Open();

                //Set up the command
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL_EDIT;

                //Execute the query
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }

		}

		//修改clip
		private const string SQL_DELETE = "DELETE FROM [blog_Post] WHERE [log_PostTime]=@PostTime";

		public void Delete(PostInfo existdPost) {

            SqlCommand cmd = new SqlCommand();

			SqlParameter parmPostTime =  new SqlParameter(PARM_PostTime, SqlDbType.DateTime);
				parmPostTime.Value = existdPost.PostTime;
					cmd.Parameters.Add(parmPostTime);

				System.Web.HttpContext.Current.Trace.Write("PostTime",existdPost.PostTime.ToString() );
				System.Web.HttpContext.Current.Trace.Write("DELETE CMD",SQL_DELETE );

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
		private const string SQL_SELECT_PostS_Start = "SELECT CONVERT(char(10), log_PostTime, 21) AS PostTime FROM [blog_Post] ";
		private const string SQL_SELECT_PostS_Begin = "Where [log_PostTime] < @after ";
		private const string SQL_SELECT_PostS_Year = "AND YEAR(log_PostTime) = @year ";
		private const string SQL_SELECT_PostS_Month = "AND MONTH(log_PostTime) = @month ";
		private const string SQL_SELECT_PostS_Day = "AND DAY(log_PostTime) = @day ";
		private const string SQL_SELECT_PostS_End = "GROUP BY CONVERT(char(10), log_PostTime, 21) ORDER BY PostTime DESC";

		public IList<PostIndexInfo> GetDays(int year,int month,int day,int page,string keywords,bool isRSS, int limit, DateTime after) {
			
			if (limit==0)
				limit=3;
			if (after==Convert.ToDateTime("0001-1-1 0:00:00"))
			{
				DateTime dt = DateTime.Now.Date;
				after = dt;
			}

			IList<PostIndexInfo> Posts = new List<PostIndexInfo>();
			
			SqlParameter[] parms = new SqlParameter[4];
				parms[0] = new SqlParameter(PARM_year, SqlDbType.BigInt, 4);
				parms[1] = new SqlParameter(PARM_month, SqlDbType.BigInt, 2);
				parms[2] = new SqlParameter(PARM_day, SqlDbType.BigInt, 2);
				parms[3] = new SqlParameter(PARM_after, SqlDbType.DateTime);
				parms[0].Value = year;
				parms[2].Value = day;
				parms[1].Value = month;
				parms[3].Value = after;

			StringBuilder sql = new StringBuilder(SQL_SELECT_PostS_Start);
				sql.Append(SQL_SELECT_PostS_Begin);
			if (year!=0)
				sql.Append(SQL_SELECT_PostS_Year);
			if (month!=0)
				sql.Append(SQL_SELECT_PostS_Month);
			if (day!=0)
				sql.Append(SQL_SELECT_PostS_Day);

			sql.Append(SQL_SELECT_PostS_End);
            string sqlPosts = sql.ToString();

            //Execute
			i=0;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, sqlPosts, parms)) {
                while (sdr.Read())
				{
					PostIndexInfo Post = new PostIndexInfo(Convert.ToDateTime(sdr.GetString(0)));
					Posts.Add(Post);
					i++;
					if (i>=limit)
						break;
                }
            }
			return Posts;
		}

		//单日的日志内容
		//
		//带有参数的日志，通常在日志列表绑定的时候调用，输出旧新排序的数据，看上去符合正常的时间数据。
		private const string PARM_year = "@year";
		private const string PARM_month = "@month";
		private const string PARM_day = "@day";
		private const string SQL_GET_DAY = "SELECT * FROM [blog_Post] Where YEAR(log_PostTime) = @year AND MONTH(log_PostTime) = @month AND DAY(log_PostTime) = @day ORDER BY [log_ID] ASC";

		public IList<PostInfo> GetOneDay(int year,int month,int day)
		{ 
            IList<PostInfo> Posts = new List<PostInfo>();

			SqlParameter[] parms = new SqlParameter[3];
				parms[0] = new SqlParameter(PARM_year, SqlDbType.BigInt, 4);
				parms[1] = new SqlParameter(PARM_month, SqlDbType.BigInt, 2);
				parms[2] = new SqlParameter(PARM_day, SqlDbType.BigInt, 2);
				parms[0].Value = year;
				parms[1].Value = month;
				parms[2].Value = day;

            //Execute
			using(SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_GET_DAY, parms))
			{
                while (sdr.Read())
				{
                    PostInfo Post = new PostInfo(sdr.GetInt32(0), FormatCode.getBreak(sdr.GetString(1)), sdr.GetDateTime(2) );
                    Posts.Add(Post);
                }
			}
			return Posts;
		}

		//取得日志序列索引，这些索引会再次调用GetOneDay()取得并绑定每日日志。
		//
		//没有参数的GetDays，将返回今日。
		private const string SQL_SELECT_TODAY = "SELECT CONVERT(char(10), log_PostTime, 21) AS PostTime FROM [blog_Post] Where  YEAR(log_PostTime) = @year  AND MONTH(log_PostTime) = @month AND DAY(log_PostTime) = @day GROUP BY CONVERT(char(10), log_PostTime, 21) ORDER BY PostTime DESC";
		public IList<PostIndexInfo> GetDays() {
			
			IList<PostIndexInfo> Posts = new List<PostIndexInfo>();
			
			DateTime dt = DateTime.Now;
			SqlParameter[] parms = new SqlParameter[3];
				parms[0] = new SqlParameter(PARM_year, SqlDbType.BigInt, 4);
				parms[1] = new SqlParameter(PARM_month, SqlDbType.BigInt, 2);
				parms[2] = new SqlParameter(PARM_day, SqlDbType.BigInt, 2);
				parms[0].Value = dt.Year;
				parms[1].Value = dt.Month;
				parms[2].Value = dt.Day;
				System.Web.HttpContext.Current.Trace.Write("DO","GET TODAY");

            //Execute
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_SELECT_TODAY, parms)) {
                while (sdr.Read())
				{
					PostIndexInfo Post = new PostIndexInfo(Convert.ToDateTime(sdr.GetString(0)));
					Posts.Add(Post);
                }
            }
			return Posts;
		}

		//单日的日志内容
		//
		//没有参数的GetOneDay，将返回当天数据，并且按照新旧顺序排序
		private const string SQL_GET_TODAY = "SELECT * FROM [blog_Post] Where YEAR(log_PostTime) = @year AND MONTH(log_PostTime) = @month AND DAY(log_PostTime) = @day ORDER BY [log_ID] DESC";
		public IList<PostInfo> GetOneDay()
		{ 
            IList<PostInfo> Posts = new List<PostInfo>();

			DateTime dt = DateTime.Now;
			SqlParameter[] parms = new SqlParameter[3];
				parms[0] = new SqlParameter(PARM_year, SqlDbType.BigInt, 4);
				parms[1] = new SqlParameter(PARM_month, SqlDbType.BigInt, 2);
				parms[2] = new SqlParameter(PARM_day, SqlDbType.BigInt, 2);
				parms[0].Value = dt.Year;
				parms[1].Value = dt.Month;
				parms[2].Value = dt.Day;
				System.Web.HttpContext.Current.Trace.Write("DO","BIND TODAY");

            //Execute
			using(SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_GET_TODAY, parms))
			{
                while (sdr.Read())
				{
                    PostInfo Post = new PostInfo(sdr.GetInt32(0), FormatCode.getBreak(sdr.GetString(1)), sdr.GetDateTime(2) );
                    Posts.Add(Post);
                }
			}
			return Posts;
		}

		//分月存档数据的索引
		//
		//
		private const string SQL_SELECT_ARCHIVES = "SELECT CONVERT(char(7), log_PostTime, 21),COUNT(CONVERT(char(7), log_PostTime, 21)) FROM [blog_Post] GROUP BY CONVERT(char(7), log_PostTime, 21) ORDER BY CONVERT(char(7), log_PostTime, 21) DESC";

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

	public class Refer:IRefer
	{

		//
		//New Trackback
		//
		private const string PARM_Refer = "@Refer";
		private const string PARM_LogTime = "@LogTime";
		private const string SQL_REFER = "INSERT INTO [blog_Refer] VALUES( @LogTime, @Refer, GETDATE())";

		public void Insert(ReferInfo newRefer) {

            SqlCommand cmd = new SqlCommand();

			SqlParameter parmRefer =  new SqlParameter(PARM_Refer, SqlDbType.NChar);
				parmRefer.Value = newRefer.UrlRefer;
					cmd.Parameters.Add(parmRefer);

			SqlParameter parmLogTime =  new SqlParameter(PARM_LogTime, SqlDbType.DateTime);
				parmLogTime.Value = newRefer.LogTime;
					cmd.Parameters.Add(parmLogTime);

            //Open a connection
            using (SqlConnection conn = new SqlConnection(SqlHelper.CONN_STR)) {

                // Open the connection
                conn.Open();

                //Set up the command
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL_REFER;

                //Execute the query
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
		}

		//
		//List Refer By Log
		//
		private const string PARM_logTime = "@logTime";
		private const string SQL_SELECT_REFERS = "SELECT re_URL,COUNT(re_URL) AS re_Count FROM [blog_Refer] Where CONVERT(char(10), log_PostTime, 21) = @logTime GROUP BY [re_URL]";

		public IList<ReferIndexInfo> GetRefersByLog(DateTime logTime)
		{ 
			ReferIndexInfo rf = null;
            IList<ReferIndexInfo> RefersByLog = new List<ReferIndexInfo>();

			SqlParameter parm = new SqlParameter(PARM_logTime, SqlDbType.DateTime);
			parm.Value = logTime;

			using(SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.CONN_STR, CommandType.Text, SQL_SELECT_REFERS, parm))
			{
                while (sdr.Read())
				{
					rf = new ReferIndexInfo(FormatCode.getEscape(sdr.GetString(0)), sdr.GetInt32(1));
                    RefersByLog.Add(rf);
				}
			}
			return RefersByLog;
		}


	}

}

