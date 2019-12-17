using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilim_ADONET {
	public class Credentials {
		//local
		//user=LSG4
		//password=lsg41819
		//private readonly string __DATASOURCE = "Data Source=localhost";
		//private readonly string __DATABASE = "Database=TL51N_3";

		//remote
		private readonly string __DATASOURCE = "Data Source=10.62.73.95";
		private readonly string __DATABASE = "Database=TL51N_3";

		public string Username {
			get;
			private set;
		}
		public string Password {
			get;
			private set;
		}
		public Credentials(string username, string password) {
			Username = username;
			Password = password;
		}

		public string GetCredentials() {
			return @__DATASOURCE + ";" + __DATABASE + ";User ID=" + Username + ";Password=" + Password;
		}
	}
}
