using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework.DataProvider.ADONET_Model.ADONET_DataMappers {
	public interface IMapper<T> {

		int Create(T entity);
		T Read(T entity);
		int Update(T entity);
		int Delete(T entity);
	}
}
