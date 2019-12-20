using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pilim_ADONET.Entities;
using Pilim_ADONET.DbConnection;


namespace Pilim_ADONET.DataMappers {
	public class PortfolioMapper : IMapper<Portfolio> {
		public int Create(Portfolio entity) {
			string query = "Insert into Portfolio (cc, nome) values (@cc, @nome)";
			SqlParameter p1 = new SqlParameter("@cc", entity.cc);
			SqlParameter p2 = new SqlParameter("@nome", entity.nome);
			return ConnectionGate.ExecuteCUD(query, new SqlParameter[] {p1,p2});
		}

		public int Delete(Portfolio entity) {
			string query = "Delete from Posições where cc=@cc and nome=@nome;" +
				"Delete from Portfolio where cc=@cc and nome=@nome";
			SqlParameter p1 = new SqlParameter("@cc", entity.cc);
			SqlParameter p2 = new SqlParameter("@nome", entity.nome);
			return ConnectionGate.ExecuteCUD(query, new SqlParameter[] { p1, p2});
		}

		public IEnumerable<Portfolio> Read(Portfolio entity) {
			throw new NotImplementedException();
		}

		public int Update(Portfolio entity) {
			throw new NotImplementedException();
		}
	}
}
