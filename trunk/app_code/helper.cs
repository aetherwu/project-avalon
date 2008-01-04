using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using Utility;
using Model;
using IDAL;

namespace SQLServerDAL
{

    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.
    /// </summary>
	public abstract class SqlHelper
	{

        //Database connection strings
		public static readonly string CONN_STR = ConnectionInfo.GetSqlServerConnectionString();

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
		/// ͨ��connection�ַ���ִ��SQL��û�в�������
        /// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters) {

            SqlCommand cmd = new SqlCommand();
			System.Web.HttpContext.Current.Trace.Write("cmdText", cmdText.ToString());

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
		/// ͨ��connection�ַ���ִ��SQL������һ������
        /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
		public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms) 
		{
			SqlCommand cmd = new SqlCommand();
			SqlConnection conn = new SqlConnection(connString);

			try
			{
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

				SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				cmd.Parameters.Clear();
				return rdr;
			}
			catch
			{
				conn.Close();
				throw;
			}
		}

		/// <summary>
		/// Ϊִ����������׼���������ݿ����ӣ�������䣬�����������ͣ�SQL����洢���̣���������ȡ��
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
		private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms) 
		{

			if (conn.State != ConnectionState.Open)
				conn.Open();

			cmd.Connection = conn;
			cmd.CommandText = cmdText;
 
			if (trans != null)
				cmd.Transaction = trans;

			cmd.CommandType = cmdType;

			if (cmdParms != null) 
			{
				foreach (SqlParameter parm in cmdParms) {
					cmd.Parameters.Add(parm);
					System.Web.HttpContext.Current.Trace.Write(parm.ToString(), parm.Value.ToString());
				}
			}
		}

        /// <summary>
		/// ��������ӻ���
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters) {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
		/// ��ȡ����
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey) {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

	}

}

