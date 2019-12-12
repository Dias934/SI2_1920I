using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PilimFramework.DataProvider.ADONET_Model.ADONET_DataMappers;
using PilimFramework.DataProvider;
using System.Collections;
using PilimFramework.DataProvider.EFModel;

namespace PilimFramework.DataProvider.ADONET_Model {
	public class ADONET_Config : IConfig {
		//user=LSG4
		//password=lsg41819
		//private readonly string __DATASOURCE = "Data Source=localhost";
		//private readonly string __DATABASE = "Database=TL51N_3";
		private readonly string __DATASOURCE = "Data Source=10.62.73.95";
		private readonly string __DATABASE = "Database=TL51N_3";

		private Credentials _credentials;

		public Credentials credentials {
			get { return _credentials; }
			set{
				_credentials = value;
				ConnectionGate.SetConnection( @__DATASOURCE + ";" + __DATABASE + ";User ID=" + credentials.Username + ";Password=" + credentials.Password);
			} 
		}

		private Dictionary<Type,object> __dictionary;
		public ADONET_Config() {
			__dictionary = new Dictionary<Type, object>();
			__dictionary.Add(typeof(Portfolio),new PortfolioMapper());
			__dictionary.Add(typeof(MerFin),new MerFinMapper());
		}

		public bool TestConnection() {
			return ConnectionGate.TestConnection();
		}

		public int StPr_AtualizarValoresDiários() {
			return ConnectionGate.ExecuteStoredProcedure("p_actualizaValorDiario",null);
		}

		public int StPr_AtualizarDadosFundamentais(string isin) {
			return ConnectionGate.ExecuteStoredProcedure("p_actualizaDadosInstrumentos",new SqlParameter []{new SqlParameter("@isinT",isin) });
		}

		public IEnumerable StPr_ApresentarPortfolio(Portfolio portfolio) {
			return ConnectionGate.ExecuteReadLazy("Select * from fListaPortfolio(@ccT,@nomeT)", new SqlParameter[] { new SqlParameter("@ccT", portfolio.cc), new SqlParameter("@nomeT", portfolio.nome) });
		}

		public int Create(IEntity entity) {
			return (int)__dictionary[entity.GetType()].GetType().GetMethod("Create").Invoke(__dictionary[entity.GetType()],new object[] {entity });
		}

		public IEnumerable Read(IEntity entity) {
			return (IEnumerable)__dictionary[entity.GetType()].GetType().GetMethod("Read").Invoke(__dictionary[entity.GetType()], new object[] { entity });
		}

		public int Update(IEntity entity) {
			return (int)__dictionary[entity.GetType()].GetType().GetMethod("Update").Invoke(__dictionary[entity.GetType()], new object[] { entity });
		}

		public int Delete(IEntity entity) {
			return (int)__dictionary[entity.GetType()].GetType().GetMethod("Delete").Invoke(__dictionary[entity.GetType()], new object[] { entity });
		}
	}
}
