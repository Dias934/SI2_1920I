using System;
using PilimFramework.Menu;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework.DBConnection {
	public class SqlGate {

		private static SqlCommand __cmd = new SqlCommand();

		public enum Return_Status {
			Successful = 0,
			Not_Successful
		}

		public static Return_Status TestConnection(string connectionString) {
			Return_Status ret = Return_Status.Successful;
			try {
				using (SqlConnection con = new SqlConnection(connectionString)) {
					con.Open();
					ConnectionState state = con.State;
					if (state == ConnectionState.Broken || state == ConnectionState.Closed)
						ret = Return_Status.Not_Successful;
					con.Close();
				}
			}
			catch { ret = Return_Status.Not_Successful; }
			return ret;
		}

		public static Return_Status ExecuteProcedure(string connectionString, SqlBatchCommand command) {
			Return_Status ret = Return_Status.Successful;
			using (__cmd.Connection = new SqlConnection(connectionString)) {
				__cmd.Connection.Open();
				__cmd.Transaction = __cmd.Connection.BeginTransaction();
				try {
					__cmd.CommandType = command.CommandType;
					__cmd.CommandText = command.MainQuery;
					for(int i = 0; i < command.ParamInfo.Count; i++) {
						__cmd.Parameters.AddWithValue((string)command.ParamInfo[i][0], command.ParamInfo[i][1]);
					}
					SqlDataReader reader=  __cmd.ExecuteReader();
					reader.Close();
					__cmd.Transaction.Commit();
					__cmd.Parameters.Clear();
				}
				catch (SqlException ex) {
					Console.WriteLine(ex.Message);
					__cmd.Transaction.Rollback();
					__cmd.Parameters.Clear();
					ret = Return_Status.Not_Successful;
				}
				__cmd.Connection.Close();
			}
			return ret;
		}

	}
}
