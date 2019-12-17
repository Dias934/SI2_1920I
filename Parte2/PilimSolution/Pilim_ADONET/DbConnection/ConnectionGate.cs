using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilim_ADONET.DbConnection {
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
			command.Transaction = command.Connection.BeginTransaction();
			SqlDataReader reader = command.ExecuteReader();
			IEnumerator enumerator = reader.GetEnumerator();
			while (enumerator.MoveNext()) 
				yield return enumerator.Current;
			command.Transaction.Commit();
			CloseConnection();
			command.Parameters.Clear();
		}

		public static IEnumerable ExecuteReadLazy(string commandText, params SqlParameter[] parameters) {
			command.CommandType = CommandType.Text;
			command.CommandText = commandText;
			foreach (SqlParameter parameter in parameters)
				command.Parameters.Add(parameter);
			OpenConnection();
			command.Transaction = command.Connection.BeginTransaction();
			SqlDataReader reader = command.ExecuteReader();
			IEnumerator enumerator = reader.GetEnumerator();
			while (enumerator.MoveNext())
				yield return enumerator.Current;
			reader.Close();
			command.Transaction.Commit();
			CloseConnection();
			command.Parameters.Clear();
		}

		public static int ExecuteCUD(string commandText, params SqlParameter[] parameters) {
			int ret = 0;
			command.CommandType = CommandType.Text;
			command.CommandText = commandText;
			if (!(parameters is null))
				foreach (SqlParameter parameter in parameters)
					if(parameter!=null)
						command.Parameters.Add(parameter);
			try {
				OpenConnection();
				command.Transaction = command.Connection.BeginTransaction();
				ret = command.ExecuteNonQuery();
				command.Transaction.Commit();
				CloseConnection();
				command.Parameters.Clear();
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				if(command.Transaction!=null)
				command.Transaction.Rollback();
				CloseConnection();
				command.Parameters.Clear();
				ret = -1;
			}
			return ret;
		}
		
		public static void SetConnection(string ConnectionString) {
			command.Connection = new SqlConnection(ConnectionString);
		}

		public static void OpenConnection() {
			command.Connection.Open();
		}

		public static void BeginTransaction() {
			command.Transaction = command.Connection.BeginTransaction();
		}

		public static void Commit() {
			command.Transaction.Commit();
		}

		public static void Rollback() {
			command.Transaction.Rollback();
		}

		public static void CloseConnection() {
			command.Connection.Close();
		}
	}
}
