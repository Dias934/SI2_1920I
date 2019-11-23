using System;
using System.Collections.Generic;
using PilimFramework.DBConnection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilimFramework.Model;

namespace PilimFramework.Menu {
	public class Main : Menu {
		private enum Option {
			Unknown = -1,
			Exit,
			Insert,
			Update,
			Remove,
			Execute
		}
		private System.Collections.Generic.Dictionary<Option, Method> __dbMethods;
		private static Main __instance;
		private Main() {
			__dbMethods = new Dictionary<Option, Method>();
			__dbMethods.Add(Option.Exit,Exit);
			__dbMethods.Add(Option.Insert, Insert);
			__dbMethods.Add(Option.Update, Update);
			__dbMethods.Add(Option.Remove, Remove);
			__dbMethods.Add(Option.Execute, Execute);
		}

		public static Main Instance {
			get {
				if (__instance == null) 
					__instance = new Main();
				return __instance;
			}
			private set { }
		}

		private Option DisplayMenu() {
			Option option = Option.Unknown;
			try {
				Console.WriteLine("Pilim App Main Menu");
				Console.WriteLine("1. Insert Menu");
				Console.WriteLine("2. Update Menu");
				Console.WriteLine("3. Remove Menu");
				Console.WriteLine("4. Execute Procedure Menu");
				Console.WriteLine("0. Exit");
				var result = Console.ReadLine();
				option = (Option)Enum.Parse(typeof(Option), result);
			}
			catch (ArgumentException ex) {
				Console.WriteLine("Invalid Option. ->"+ex.Message);
			}

			return option;

		}	

		private void Insert() {
			Console.WriteLine("Insert Data Menu");
		}

		private void Update() {
			Console.WriteLine("Update Data Menu");
		}

		private void Remove() {
			Console.WriteLine("Remove Data Menu");
		}

		private void Execute() {
			ExecuteProcedure.Instance.Run();
		}

		private Option TestConnection() {
			Console.WriteLine("Testing Connection...");
			if (SqlGate.TestConnection(ConnectionString) == SqlGate.Return_Status.Successful) {
				Console.WriteLine("Connection Successful");
				return Option.Unknown;
			}
			Console.WriteLine("Connection not Successful");
			return Option.Exit;
		}

		public override void Run() {
			Console.WriteLine();
			Option userInput = TestConnection();
			Console.ReadKey();
			entities = new TL51N_3Entities();
			while (userInput != Option.Exit) {
				Console.Clear();
				userInput = DisplayMenu();
				Console.Clear();
				try {
					__dbMethods[userInput]();
				}
				catch (KeyNotFoundException ex) {
					Console.WriteLine("Option unknown. ->"+ex.Message);
				}
			}
		}
	}
}
