using PilimFramework.DataProvider;
using PilimFramework.DataProvider.EFModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PilimFramework {
	public class PillimMenu {

		private enum Option {
			Unknown = -1,
			Exit,
			AtualizarValoresDiários,
			AtualizarDadosFundamentais,
			CriarPortfolio,
			ApresentarPortfolio,
			InserirMercadoFinanceiro,
			RemoverMercadoFinanceiro,
			AtualizarMercadoFinanceiro,
			RemoverPortfolio
		}

		private delegate void Method();

		private Dictionary<Option, Method> __methods;

		private Array __array;

		private DataProvider.DataProvider __provider { get; set; }

		public static Credentials getCredentials() {
			Console.Clear();
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

		public PillimMenu(IConfig config) {
			__provider=new DataProvider.DataProvider(config);
			Method aux = () => {
				Console.WriteLine("Press any key to contiue.");
				Console.ReadKey();
			};
			__methods = new Dictionary<Option, Method>();
			__methods.Add(Option.Exit, () =>{});
			__methods.Add(Option.AtualizarValoresDiários, AtualizarValoresDiários+aux);
			__methods.Add(Option.AtualizarDadosFundamentais, AtualizarDadosFundamentais+aux);
			__methods.Add(Option.CriarPortfolio, CriarPortfolio+aux);
			__methods.Add(Option.ApresentarPortfolio, ApresentarPortfolio+aux);
			__methods.Add(Option.InserirMercadoFinanceiro, InserirMercadoFinanceiro+aux);
			__methods.Add(Option.RemoverMercadoFinanceiro, RemoverMercadoFinanceiro+aux);
			__methods.Add(Option.AtualizarMercadoFinanceiro, AtualizarMercadoFinanceiro+aux);
			__methods.Add(Option.RemoverPortfolio, RemoverPortfolio+aux);
			__array = __methods.Keys.ToArray();
		}

		public void Run() {
			if (__provider.NeedsCredentials())
				__provider.SetCredentials(getCredentials());
			Console.WriteLine("\nTesting Connection...");
			if (__provider.TestConnection()) {
				Console.WriteLine("Connection SUCCEFUL\nPress any key to continue");
				Console.ReadKey();
				Option userInput = Option.Unknown;
				while (userInput != Option.Exit) {
					Console.Clear();
					userInput = DisplayMenu();
					Console.Clear();
					try {
						__methods[userInput]();
					}
					catch (KeyNotFoundException ex) {
						Console.WriteLine("Option unknown. ->" + ex.Message+". Press any key to continue");
						Console.ReadKey();
					}
				}
			}
			else {
				Console.WriteLine("Connection UNSUCCEFUL\nPress any key to exit");
				Console.ReadKey();
			}
		}

		private Option DisplayMenu() {
			Option option = Option.Unknown;
			Console.Clear();
			try {
				Console.WriteLine("Pilim App Execute Procedure Menu");
				for (int i = 1; i < __array.Length; i++)
					Console.WriteLine(i + ". " + __array.GetValue(i).ToString());
				Console.WriteLine("0. Exit");
				var result = Console.ReadLine();
				option = (Option)Enum.Parse(typeof(Option), result);
			}
			catch (Exception ex) {
				Console.WriteLine("Invalid Option. ->" + ex.Message);
				Console.WriteLine("Press any key to try again.");
				Console.ReadKey();
			}

			return option;
		}

		private void AtualizarValoresDiários() {
			int aux = __provider.StPr_AtualizarValoresDiários();
			if ( aux> 0)
				Console.WriteLine("The values were updated");
			else if(aux==0)
				Console.WriteLine("There aren't Triples available");
			
		}

		private void AtualizarDadosFundamentais() {
			string isin = "";
			Console.WriteLine("Please enter the ISIN of the instrument or just press enter to update all");
			isin = Console.ReadLine();
			if (__provider.StPr_AtualizarDadosFundamentais(isin) >= 0)
				Console.WriteLine("The values were updated");
			else
				Console.WriteLine("The value were NOT updated");
		}

		private void ApresentarPortfolio() { }

		private void CriarPortfolio() {
			Portfolio portfolio = new Portfolio();
			foreach (PropertyInfo property in portfolio.GetType().GetProperties()) {
				if (!property.PropertyType.IsClass && !property.PropertyType.IsInterface || property.PropertyType.Equals(typeof(string))) {
					Console.WriteLine("Insert value for "+property.Name+" of type "+property.PropertyType.Name);
					string s = Console.ReadLine();
					if (property.PropertyType.IsValueType)
						property.SetValue(portfolio, Convert.ToInt32(s));
					else
						property.SetValue(portfolio, s);
				}
			}
			if (__provider.CreateEntity(portfolio) > 0)
				Console.WriteLine("SUCCESS");
			else
				Console.WriteLine("UNSUCCESS");
		}

		private void InserirMercadoFinanceiro() { }

		private void RemoverMercadoFinanceiro() { }

		private void AtualizarMercadoFinanceiro() { }

		private void RemoverPortfolio() { }
	}
}
