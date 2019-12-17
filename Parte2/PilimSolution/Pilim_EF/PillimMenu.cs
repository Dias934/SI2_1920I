using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Pilim_EF {
	public class PilimMenu {

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
		private PilimEntities dbContext;
		private Array __array;

		public PilimMenu() {
			dbContext = new PilimEntities();
			Method aux = () => {
				Console.WriteLine("Press any key to continue.");
				Console.ReadKey();
			};
			__methods = new Dictionary<Option, Method>();
			__methods.Add(Option.Exit, () => { });
			__methods.Add(Option.AtualizarValoresDiários, AtualizarValoresDiários + aux);
			__methods.Add(Option.AtualizarDadosFundamentais, AtualizarDadosFundamentais + aux);
			__methods.Add(Option.CriarPortfolio, CriarPortfolio + aux);
			__methods.Add(Option.ApresentarPortfolio, ApresentarPortfolio + aux);
			__methods.Add(Option.InserirMercadoFinanceiro, InserirMercadoFinanceiro + aux);
			__methods.Add(Option.RemoverMercadoFinanceiro, RemoverMercadoFinanceiro + aux);
			__methods.Add(Option.AtualizarMercadoFinanceiro, AtualizarMercadoFinanceiro + aux);
			__methods.Add(Option.RemoverPortfolio, RemoverPortfolio + aux);
			__array = __methods.Keys.ToArray();
		}

		public void Run() {
			Console.WriteLine("Testing Connection...");
			bool flag = true;
			try {
				using (SqlConnection con = new SqlConnection(dbContext.Database.Connection.ConnectionString)) {
					con.Open();
					con.Close();
				}
			}
			catch {
				flag = false;
			}
			if (flag) {
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
						Console.WriteLine("Option unknown. ->" + ex.Message + ". Press any key to continue");
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
			int aux = dbContext.p_actualizaValorDiario();
			if (aux > 0)
				Console.WriteLine("The values were updated");
			else if (aux == 0)
				Console.WriteLine("There aren't Triples available");

		}

		private void AtualizarDadosFundamentais() {
			string isin = "";
			Console.WriteLine("Please enter the ISIN of the instrument or just press enter to update all");
			isin = Console.ReadLine();
			if (dbContext.p_actualizaDadosInstrumentos(isin) >= 0)
				Console.WriteLine("The values were updated");
			else
				Console.WriteLine("The value were NOT updated");
		}

		private void ApresentarPortfolio() {
			Console.WriteLine("Insert cc of Client");
			int cc = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Insert name of Portfolio");
			string nome = Console.ReadLine();
			IEnumerable query = from posições in dbContext.Posições
								where posições.cc == cc && posições.nome.Equals(nome)
								select posições;
			Console.Clear();
			PrintHeader<Posições>();
			foreach (Posições posições in query) {
				PrintResults<Posições>(posições);
			}
		}

		private void CriarPortfolio() {
			Portfolio portfolio = dbContext.Portfolio.Create();
			Console.WriteLine("Insert cc of Client");
			portfolio.cc = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Insert name of Portfolio");
			portfolio.nome = Console.ReadLine();
			dbContext.Portfolio.Add(portfolio);
			if (dbContext.SaveChanges() > 0)
				Console.WriteLine("SUCCESS");
			else
				Console.WriteLine("UNSUCCESS");
		}

		private void InserirMercadoFinanceiro() {
			MerFin merFin = dbContext.MerFin.Create();
			Console.WriteLine("Insert Unique Code of Mercado Financeiro");
			merFin.cod_un = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Insert Name of Mercado Financeiro");
			merFin.nome = Console.ReadLine();
			Console.WriteLine("Insert Description of Mercado Financeiro");
			merFin.descrição = Console.ReadLine();
			dbContext.MerFin.Add(merFin);
			if (dbContext.SaveChanges() > 0)
				Console.WriteLine("SUCCESS");
			else
				Console.WriteLine("UNSUCCESS");
		}

		private void RemoverMercadoFinanceiro() {
			Console.WriteLine("Insert Unique Code of Mercado Financeiro to REMOVE");
			int cod = Int32.Parse(Console.ReadLine());
			IEnumerable regs=from mer in dbContext.RegDiaMerFin
								where mer.cod_un == cod
								select mer;
			foreach(RegDiaMerFin reg in regs)
				dbContext.RegDiaMerFin.Remove(reg);				
			MerFin merFin = (from mer in dbContext.MerFin
							 where mer.cod_un == cod
							 select mer).FirstOrDefault();
			if (merFin != null) {
				dbContext.MerFin.Remove(merFin);
				if (dbContext.SaveChanges() > 0)
					Console.WriteLine("SUCCESS");
				else
					Console.WriteLine("UNSUCCESS");
			}
			else
				Console.WriteLine("No elements to be removed");
		}

		private void AtualizarMercadoFinanceiro() {
			Console.WriteLine("Insert Unique Code of Mercado Financeiro to Update");
			int cod = Int32.Parse(Console.ReadLine());
			MerFin merFin = (from mer in dbContext.MerFin
							 where mer.cod_un == cod
							 select mer).FirstOrDefault();
			if (merFin != null) {
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
				if (dbContext.SaveChanges() > 0)
					Console.WriteLine("SUCCESS");
				else
					Console.WriteLine("UNSUCCESS");
			}
			else
				Console.WriteLine("Invalid Unique Code");
		}

		private void RemoverPortfolio() {
			Console.WriteLine("Insert the cc of Client's Portfolio you want to REMOVE");
			int cc = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Insert the name Portfolio you want to REMOVE");
			string nome = Console.ReadLine();
			IEnumerable posições = from pos in dbContext.Posições
								 where pos.cc == cc && pos.nome.Equals(nome)
								 select pos;
			foreach (Posições pos in posições)
				dbContext.Posições.Remove(pos);
			Portfolio portfolio = (from port in dbContext.Portfolio
								   where port.cc == cc && port.nome.Equals(nome)
								   select port).FirstOrDefault();
			if (portfolio != null) {
				dbContext.Portfolio.Remove(portfolio);
				if (dbContext.SaveChanges() > 0)
					Console.WriteLine("SUCCESS");
				else
					Console.WriteLine("UNSUCCESS");
			}
			else
				Console.WriteLine("The Portfolio doesn't exist");
		}

		private void PrintHeader<T>() {
			Console.Clear();
			PropertyInfo[] props = typeof(T).GetProperties();
			foreach (PropertyInfo p in props) {
				if (p.PropertyType.IsValueType || p.PropertyType.Equals(typeof(string))) {
					Console.Write("{0,-25}", p.Name);
				}
			}
			Console.WriteLine();
		}

		private void PrintResults<T>(IEntity target) {
			PropertyInfo[] props = typeof(T).GetProperties();
			foreach (PropertyInfo p in props) {
				if (p.PropertyType.IsValueType || p.PropertyType.Equals(typeof(string))) {
					Console.Write("{0,-25}", p.GetValue(target));
				}
			}
			Console.WriteLine();
		}
	}
}
