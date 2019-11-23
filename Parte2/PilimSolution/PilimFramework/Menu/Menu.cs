using System;
using PilimFramework.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework.Menu {
	public abstract class Menu {

		protected delegate void Method();

		protected static TL51N_3Entities entities { get; set; }

		public static string ConnectionString {
			get;
			set;
		}

		protected void Exit() {
			Console.WriteLine("Exiting...");
		}

		public abstract void Run();
	}
}
