using System;
using PilimFramework.DBConnection;
using PilimFramework.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework.Menu {
	public class ExecuteProcedure : Menu {

		private enum Option {
			Unknown = -1,
			Exit,
			ActualizaValorDiario
		}
		private System.Collections.Generic.Dictionary<Option, Method> __methods;
		private static ExecuteProcedure __instance;
		private ExecuteProcedure() {
			__methods = new Dictionary<Option, Method>();
			__methods.Add(Option.Exit, Exit);
			__methods.Add(Option.ActualizaValorDiario, ActualizaValorDiario);
		}

		public static ExecuteProcedure Instance {
			get {
				if (__instance == null)
					__instance = new ExecuteProcedure();
				return __instance;
			}
			private set { }
		}

		private void ActualizaValorDiario() {
			SqlBatchCommand command = new SqlBatchCommand("p_actualizaValorDiario", System.Data.CommandType.StoredProcedure);
			SqlGate.ExecuteProcedure(ConnectionString, command);
		}

		private Option DisplayMenu() {
			Option option = Option.Unknown;
			try {
				Console.WriteLine("Pilim App Execute Procedure Menu");
				var aux = __methods.Keys.ToArray();
				for (int i = 1; i < aux.Length; i++)
					Console.WriteLine(i+". "+aux[i].ToString());
				Console.WriteLine("0. Exit");
				var result = Console.ReadLine();
				option = (Option)Enum.Parse(typeof(Option), result);
			}
			catch (ArgumentException ex) {
				Console.WriteLine("Invalid Option. ->" + ex.Message);
			}
			return option;

		}

		public override void Run() {
			Option userInput = Option.Unknown;
			while (userInput != Option.Exit) {
				Console.Clear();
				userInput = DisplayMenu();
				Console.Clear();
				try {
					__methods[userInput]();
					Console.ReadKey();
				}
				catch (KeyNotFoundException ex) {
					Console.WriteLine("Option unknown. ->" + ex.Message);
				}
			}
		}
	}
}
