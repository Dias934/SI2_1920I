using PilimFramework.DBConnection;
using PilimFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PilimFramework.DBConnection.SqlGate;

namespace PilimFramework.Menu {
	public class Insert : Menu {
		private enum Option {
			Unknown = -1,
			Exit,
			InserirPortefolio
		}
		private System.Collections.Generic.Dictionary<Option, Method> __methods;
		private static Insert __instance;
		private Insert() {
			__methods = new Dictionary<Option, Method>();
			__methods.Add(Option.Exit, Exit);
			__methods.Add(Option.InserirPortefolio, InserirPortefolio);
		}

		public static Insert Instance {
			get {
				if (__instance == null)
					__instance = new Insert();
				return __instance;
			}
			private set { }
		}

		private void InserirPortefolio() {
			
			Return_Status ret=Return_Status.Successful;
			Console.Write("The insert was ");
			if (ret == Return_Status.Not_Successful)
				Console.Write("not ");
			Console.WriteLine("successfuly executed.");
		}

		private Option DisplayMenu() {
			Option option = Option.Unknown;
			try {
				Console.WriteLine("Pilim App Execute Procedure Menu");
				var aux = __methods.Keys.ToArray();
				for (int i = 1; i < aux.Length; i++)
					Console.WriteLine(i + ". " + aux[i].ToString());
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
					if (userInput != Option.Exit)
						Console.ReadKey();
				}
				catch (KeyNotFoundException ex) {
					Console.WriteLine("Option unknown. ->" + ex.Message);
				}
			}
		}
	}
}
