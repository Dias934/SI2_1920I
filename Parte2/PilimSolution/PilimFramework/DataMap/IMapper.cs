using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework.DataMap {
	public interface IMapper {

		public interface IMapper<T, Tid> {
			void Create(T entity);
			T Read(Tid id);
			void Update(T entity);
			void Delete(T entity);
		}
	}
}
