using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilimFramework.DataProvider.ADONET_Model;
using PilimFramework.DataProvider.EFModel;

namespace PilimFramework.DataProvider {
	public class DataProvider {
		
		private IConfig __config { get; set; }

		public DataProvider(IConfig config) {
			__config = config;
		}

		public bool TestConnection() {
			return __config.TestConnection();
		}

		public bool NeedsCredentials() {
			return __config.GetType().Equals(typeof(ADONET_Config));
		}

		public void SetCredentials(Credentials credentials) {
			((ADONET_Config)__config).credentials = credentials;
		}
	
		public int CreateEntity(IEntity o) {
			return __config.Create(o);
		}

		public int UpdateEntity(IEntity o) {
			return __config.Update(o);
		}

		public IEnumerable ReadEntity(IEntity o) {
			return __config.Read(o);
		}

		public int DeleteEntity(IEntity o) {
			return __config.Delete(o);
		}
		
		public int StPr_AtualizarValoresDiários() {
			return __config.StPr_AtualizarValoresDiários();
		}

		public int StPr_AtualizarDadosFundamentais(string isin) {
			return __config.StPr_AtualizarDadosFundamentais(isin);
		}

		public IEnumerable StPr_ApresentarPortfolio(Portfolio portfolio) {
			return __config.StPr_ApresentarPortfolio(portfolio);
		}
	}
}
