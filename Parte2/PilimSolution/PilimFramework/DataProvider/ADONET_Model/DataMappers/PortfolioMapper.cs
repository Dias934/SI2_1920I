using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilimFramework.DataProvider.EFModel;
using PilimFramework.DataProvider.ADONET_Model;

namespace PilimFramework.DataProvider.ADONET_Model.ADONET_DataMappers {
	public class PortfolioMapper : IMapper<Portfolio> {
		public int Create(Portfolio entity) {
			string query = "Insert into Portfolio (cc, nome) values (@cc, @nome)";
			SqlParameter p1 = new SqlParameter("@cc", entity.cc);
			SqlParameter p2 = new SqlParameter("@nome", entity.nome);
			return ConnectionGate.ExecuteCUD(query, new SqlParameter[] {p1,p2});
		}

		public int Delete(Portfolio entity) {
			string query = "Delete from Posições where cc=@cc1 and nome=@nome1;" +
				"Delete from Portfolio where cc=@cc2 and nome=@nome2";
			SqlParameter p1 = new SqlParameter("@cc1", entity.cc);
			SqlParameter p2 = new SqlParameter("@nome1", entity.nome);
			SqlParameter p3 = new SqlParameter("@cc2", entity.cc);
			SqlParameter p4 = new SqlParameter("@nome2", entity.nome);
			return ConnectionGate.ExecuteCUD(query, new SqlParameter[] { p1, p2,p3,p4 });
		}

		public Portfolio Read(Portfolio entity) {
			throw new NotImplementedException();
		}

		public int Update(Portfolio entity) {
			throw new NotImplementedException();
		}
	}
}
