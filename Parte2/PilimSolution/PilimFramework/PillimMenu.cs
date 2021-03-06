﻿using PilimFramework.DataProvider;
using PilimFramework.DataProvider.EFModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

		private void ApresentarPortfolio() {
			Portfolio portfolio = new Portfolio();
			Console.WriteLine("Insert cc of Client");
			portfolio.cc = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Insert name of Portfolio");
			portfolio.nome = Console.ReadLine();
			IEnumerable res=__provider.StPr_ApresentarPortfolio(portfolio);
			PrintResults(res.GetEnumerator());
		}

		private void CriarPortfolio() {
			Portfolio portfolio = new Portfolio();
			Console.WriteLine("Insert cc of Client");
			portfolio.cc = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Insert name of Portfolio");
			portfolio.nome = Console.ReadLine();
			if (__provider.CreateEntity(portfolio) > 0)
				Console.WriteLine("SUCCESS");
			else
				Console.WriteLine("UNSUCCESS");
		}

		private void InserirMercadoFinanceiro() {
			MerFin merFin = new MerFin();
			Console.WriteLine("Insert Unique Code of Mercado Financeiro");
			merFin.cod_un = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Insert Name of Mercado Financeiro");
			merFin.nome = Console.ReadLine();
			Console.WriteLine("Insert Description of Mercado Financeiro");
			merFin.descrição = Console.ReadLine();
			if (__provider.CreateEntity(merFin) > 0)
				Console.WriteLine("SUCCESS");
			else
				Console.WriteLine("UNSUCCESS");
		}

		private void RemoverMercadoFinanceiro() {
			MerFin merFin = new MerFin();
			Console.WriteLine("Insert Unique Code of Mercado Financeiro to REMOVE");
			merFin.cod_un = Int32.Parse(Console.ReadLine());
			if (__provider.DeleteEntity(merFin) > 0)
				Console.WriteLine("SUCCESS");
			else
				Console.WriteLine("UNSUCCESS");
		}

		private void AtualizarMercadoFinanceiro() {
			MerFin merFin = new MerFin();
			Console.WriteLine("Insert Unique Code of Mercado Financeiro to Update");
			merFin.cod_un = Int32.Parse(Console.ReadLine());
			string src = "";
			Console.WriteLine("Do you want to update the name of Mercado Financeiro?(Y/N)");
			src = Console.ReadLine();
			if (src.ToUpper().Contains("Y")) { 
				Console.WriteLine("Insert the new name");
				merFin.nome = Console.ReadLine();
			}
			Console.WriteLine("Do you want to update the description of Mercado Financeiro?(Y/N)");
			src = Console.ReadLine();
			if (src.ToUpper().Contains("Y")) {
				Console.WriteLine("Insert the new description");
				merFin.descrição = Console.ReadLine();
			}
			if (__provider.UpdateEntity(merFin) > 0)
				Console.WriteLine("SUCCESS");
			else
				Console.WriteLine("UNSUCCESS");
		}

		private void RemoverPortfolio() {
			Portfolio portfolio = new Portfolio();
			Console.WriteLine("Insert the cc of Client's Portfolio you want to REMOVE");
			portfolio.cc = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Insert the name Portfolio you want to REMOVE");
			portfolio.nome = Console.ReadLine();
			if (__provider.DeleteEntity(portfolio) > 0)
				Console.WriteLine("SUCCESS");
			else
				Console.WriteLine("UNSUCCESS");
		}

		private void PrintResults(IEnumerator results) {
			Console.Clear();
			if (results.MoveNext()) {
				IDataRecord aux = (IDataRecord)results.Current;
				for (int i = 0; i < aux.FieldCount; i++) {
					Console.Write("{0,-25}", aux.GetName(i));
				}
				Console.WriteLine();
				do {
					aux = (IDataRecord)results.Current;
					for (int i = 0; i < aux.FieldCount; i++) {
						Console.Write("{0,-25}", aux.GetValue(i));
					}
					Console.WriteLine();
				} while (results.MoveNext());
			}
		}
	}
}
