using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using PilimFramework.DataProvider;

namespace PilimFramework.DataProvider.EFModel {
	public class EF_Config : IConfig {
		public int Create(IEntity entity) {
			throw new NotImplementedException();
		}

		public int Delete(IEntity entity) {
			throw new NotImplementedException();
		}

		public IEnumerable Read(IEntity entity) {
			throw new NotImplementedException();
		}

		public IEnumerable StPr_ApresentarPortfolio(Portfolio portfolio) {
			throw new NotImplementedException();
		}

		public int StPr_AtualizarDadosFundamentais(string isin) {
			throw new NotImplementedException();
		}

		public int StPr_AtualizarValoresDiários() {
			throw new NotImplementedException();
		}

		public bool TestConnection() {
			throw new NotImplementedException();
		}

		public int Update(IEntity entity) {
			throw new NotImplementedException();
		}
	}
}
