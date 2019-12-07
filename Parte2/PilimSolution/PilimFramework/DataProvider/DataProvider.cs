using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilimFramework.DataProvider.ADONET_Model;

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
			throw new NotImplementedException();
		}

		public IEntity ReadEntity(IEntity o) {
			throw new NotImplementedException();
		}

		public int DeleteEntity(IEntity o) {
			throw new NotImplementedException();
		}
		
		public int StPr_AtualizarValoresDiários() {
			return __config.StPr_AtualizarValoresDiários();
		}

		public int StPr_AtualizarDadosFundamentais(string isin) {
			return __config.StPr_AtualizarDadosFundamentais(isin);
			throw new NotImplementedException();
		}

		public int StPr_ApresentarPortfolio() {
			throw new NotImplementedException();
		}
	}
}
