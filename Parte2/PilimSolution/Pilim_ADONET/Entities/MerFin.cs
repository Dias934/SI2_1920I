using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilim_ADONET.Entities {
	public class MerFin:IEntity {
		public int cod_un { get; set; }
		public string descrição { get; set; }
		public string nome { get; set; }
	}
}
