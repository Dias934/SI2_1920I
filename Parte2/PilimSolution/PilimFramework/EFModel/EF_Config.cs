using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Transactions;
using PilimFramework.DataProvider;

namespace PilimFramework.DataProvider.EFModel {
	public class EF_Config : IConfig {
		private readonly TL51N_3Entities __dbContext;
		private readonly Dictionary<Type, object> __dictionary;
		public EF_Config() {
			__dbContext = new TL51N_3Entities();
			__dictionary = new Dictionary<Type, object>();
			__dictionary.Add(typeof(MerFin), __dbContext.MerFin);
			__dictionary.Add(typeof(Portfolio), __dbContext.Portfolio);
		}

		public int Create(IEntity entity) {
			__dictionary[entity.GetType()].GetType().GetMethod("Add").Invoke(__dictionary[entity.GetType()], new IEntity[] { entity });
			return __dbContext.SaveChanges();
		}

		public int Delete(IEntity entity) {
			__dictionary[entity.GetType()].GetType().GetMethod("Remove").Invoke(__dictionary[entity.GetType()], new IEntity[] { entity });
			return __dbContext.SaveChanges();
		}

		public IEnumerable Read(IEntity entity) {
			throw new NotImplementedException();
		}

		public IEnumerable StPr_ApresentarPortfolio(Portfolio portfolio) {
			return __dbContext.fListaPortfolio(portfolio.cc, portfolio.nome);
		}

		public int StPr_AtualizarDadosFundamentais(string isin) {
			return __dbContext.p_actualizaDadosInstrumentos(isin);
		}

		public int StPr_AtualizarValoresDiários() {
			return __dbContext.p_actualizaValorDiario();
		}

		public bool TestConnection() {
			using (SqlConnection con = new SqlConnection(__dbContext.Database.Connection.ConnectionString)) {
				try {
					con.Open();
					con.Close();
				}
				catch {
					return false;
				}
			}
			return true;
		}

		public int Update(IEntity entity) {
			__dictionary[entity.GetType()].GetType().GetMethod("Attach").Invoke(__dictionary[entity.GetType()], new IEntity[] { entity });
			__dbContext.Entry(entity).State = EntityState.Modified;
			return __dbContext.SaveChanges();
		}
	}
}
