using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilim_ADONET.DataMappers {
	public interface IMapper<T> {

		int Create(T entity);
		IEnumerable<T> Read(T entity);
		int Update(T entity);
		int Delete(T entity);
	}
}
