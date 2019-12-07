using System.Collections;
using System.Collections.Generic;

namespace PilimFramework.DataProvider {
	public interface IConfig {

		bool TestConnection();

		int StPr_AtualizarValoresDiários();

		int StPr_AtualizarDadosFundamentais(string isin);

		IEnumerable StPr_ApresentarPortfolio();

		int Create(IEntity entity);
		IEnumerable Read(IEntity entity);
		int Update(IEntity entity);
		int Delete(IEntity entity);
	}
}
