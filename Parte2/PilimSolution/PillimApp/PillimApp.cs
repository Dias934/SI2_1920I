using PilimFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PillimApp {
	static class PillimApp {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Menus.Menu m = new Menus.Menu();
			m.Run();
			/*TL51N_3Entities tL = new TL51N_3Entities();
			tL.fListaPortfolio(123,"");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			PillimAppLoginForm f =new PillimAppLoginForm();
			Application.Run(f);*/
		}
	}
}
