using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework.Menu {
	public class Update : Menu {

		private enum Option {
			Unknown = -1,
			Exit,
			Instrumento
		}
		private System.Collections.Generic.Dictionary<Option, Method> __methods;
		private static Update __instance;
		private Update() {
			__methods = new Dictionary<Option, Method>();
			__methods.Add(Option.Exit, Exit);
			//__methods.Add(Option.ActualizaValorDiario, Update);
		}

		public static Update Instance {
			get {
				if (__instance == null)
					__instance = new Update();
				return __instance;
			}
			private set { }
		}

		private void Instrumento() {

		}

		private Option DisplayMenu() {
			Option option = Option.Unknown;
			try {
				Console.WriteLine("Pilim App Update Menu");
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
					Console.ReadKey();
				}
				catch (KeyNotFoundException ex) {
					Console.WriteLine("Option unknown. ->" + ex.Message);
				}
			}
		}
	}
}
