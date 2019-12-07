using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework.DataProvider.ADONET_Model {
	public class ConnectionGate {
		private static SqlCommand command = new SqlCommand();
		private static SqlTransaction transaction = null;

		public static bool TestConnection() {
			try {
				OpenConnection();
				CloseConnection();
			}
			catch {
				return false;
			}
			return true;
		}

		public static int ExecuteStoredProcedure(string commandText,params SqlParameter[] parameters) {
			int ret = 0;
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = commandText;
			if(!(parameters is null))
				foreach (SqlParameter parameter in parameters)
					command.Parameters.Add(parameter);
			try {
				OpenConnection();
				command.Transaction= command.Connection.BeginTransaction();
				ret=command.ExecuteNonQuery();
				command.Transaction.Commit();
				CloseConnection();
				command.Parameters.Clear();
			}
			catch(Exception ex) {
				Console.WriteLine(ex.Message);
				command.Transaction.Rollback();
				CloseConnection();
				command.Parameters.Clear();
				ret = -1;
			}
			return ret;
		}

		public static IEnumerable ExecuteStoredProcedureLazy(string commandText, params SqlParameter[] parameters) {
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = commandText;
			foreach (SqlParameter parameter in parameters)
			command.Parameters.Add(parameter);
			OpenConnection();
			transaction = command.Connection.BeginTransaction();
			SqlDataReader reader = command.ExecuteReader();
			IEnumerator enumerator = reader.GetEnumerator();
			while (enumerator.MoveNext()) 
				yield return enumerator.Current;
			transaction.Commit();
			CloseConnection();
			command.Parameters.Clear();
		}

		public static void SetConnection(string ConnectionString) {
			command.Connection = new SqlConnection(ConnectionString);
		}

		public static void OpenConnection() {
			command.Connection.Open();
		}

		public static void CloseConnection() {
			command.Connection.Close();
		}
	}
}
