using System;
using PilimFramework.Menu;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilimFramework.Model;

namespace PilimFramework {
	public class PilimApp {
			
		public static Credentials getCredentials() {
			Console.Write("Enter your username: ");
			string username = Console.ReadLine();
			string password = "";
			Console.Write("Enter your password: ");

			ConsoleKeyInfo key;

			do {
				key = Console.ReadKey(true);

				// Backspace Should Not Work
				if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter) {
					password += key.KeyChar;
					Console.Write("*");
				}
				else {
					if (key.Key == ConsoleKey.Backspace && password.Length > 0) {
						password = password.Substring(0, (password.Length - 1));
						Console.Write("\b \b");
					}
				}
			}
			while (key.Key != ConsoleKey.Enter);

			return new Credentials(username, password);
		}


		public static void Main(string[] args) {
			Credentials cr = getCredentials();
			Menu.Menu.ConnectionString = @"Data Source=10.62.73.95;Database=TL51N_3;User ID=" + cr.Username + ";Password=" + cr.Password + "; Pooling=true; max pool size=10";
			Menu.Main.Instance.Run();
		}
	}
}
