using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pilim_ADONET.DbConnection;
using Pilim_ADONET.Entities;

namespace Pilim_ADONET.DataMappers {
	public class MerFinMapper : IMapper<MerFin> {
		public int Create(MerFin entity) {
			string query = "Insert into MerFin (cod_un, descrição, nome) values (@cod_un, @descrição, @nome)";
			SqlParameter p1 = new SqlParameter("@cod_un", entity.cod_un);
			SqlParameter p2 = new SqlParameter("@nome", entity.nome);
			SqlParameter p3 = new SqlParameter("@descrição", entity.descrição);
			return ConnectionGate.ExecuteCUD(query, new SqlParameter[] { p1, p2, p3});
		}

		public int Delete(MerFin entity) {
			string query = "Delete from RegDiaMerFin where cod_un=@cod_un;"+
						   "Delete from MerFin where cod_un=@cod_un";
			SqlParameter p = new SqlParameter("@cod_un", entity.cod_un);
			return ConnectionGate.ExecuteCUD(query, new SqlParameter[] { p });
		}

		public MerFin Read(MerFin entity) {
			throw new NotImplementedException();
		}

		public int Update(MerFin entity) {
			string query = "Update MerFin set";
			SqlParameter[] sqlParameters = new SqlParameter[3];
			int idx = 0;
			sqlParameters[idx++]=new SqlParameter("@cod_un", entity.cod_un);
			if (entity.nome != null) {
				sqlParameters[idx++] = new SqlParameter("@nome", entity.nome);
				query += " nome=@nome";
			}
			if (entity.descrição != null) {
				sqlParameters[idx++] = new SqlParameter("@descrição", entity.descrição);
				if (entity.nome != null)
					query += ",";
				query += " descrição=@descrição";
			}
			query+= " where cod_un = @cod_un";
			return ConnectionGate.ExecuteCUD(query, sqlParameters);
		}
	}
}
