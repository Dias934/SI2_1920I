using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework {
	public class App {
		private enum Option {
			Unknown = -1,
			Exit,
			/*ListStudent,
			ListCourse,
			RegisterStudent,
			EnrolStudent*/
		}
		private static App __instance;
		private App() {
			__dbMethods = new Dictionary<Option, DBMethod>();
			/*__dbMethods.Add(Option.ListStudent, ListStudent);
			__dbMethods.Add(Option.ListCourse, ListCourse);
			__dbMethods.Add(Option.RegisterStudent, RegisterStudent);
			__dbMethods.Add(Option.EnrolStudent, EnrolStudent);*/

		}
		public static App Instance {
			get {
				if (__instance == null)
					__instance = new App();
				return __instance;
			}
			private set { }
		}

		private Option DisplayMenu() {
			Option option = Option.Unknown;
			try {
				Console.WriteLine("Course management");
				Console.WriteLine();
				/*Console.WriteLine("1. List students");
				Console.WriteLine("2. List courses");
				Console.WriteLine("3. Register student");
				Console.WriteLine("4. Enrol student");*/
				Console.WriteLine("0. Exit");
				var result = Console.ReadLine();
				option = (Option)Enum.Parse(typeof(Option), result);
			}
			catch (ArgumentException ex) {
				Console.WriteLine("Invalid Option. ->"+ex.Message);
			}

			return option;

		}
		/*private void Login() {
			using (SqlConnection con = new SqlConnection(ConnectionString)) {
				con.Open();
			}

		}*/
		private delegate void DBMethod();
		private System.Collections.Generic.Dictionary<Option, DBMethod> __dbMethods;
		public string ConnectionString {
			get;
			set;
		}

		public void Run() {
			//Login();
			Option userInput = Option.Unknown;
			do {
				Console.Clear();
				userInput = DisplayMenu();
				Console.Clear();
				try {
					__dbMethods[userInput]();
					Console.ReadKey();
				}
				catch (KeyNotFoundException ex) {
					Console.WriteLine("Option not valid. ->"+ex.Message);
				}

			} while (userInput != Option.Exit);
		}
	}
}
