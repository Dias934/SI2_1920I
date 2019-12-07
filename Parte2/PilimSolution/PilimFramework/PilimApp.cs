using System;
using PilimFramework.DataProvider;
using PilimFramework.DataProvider.ADONET_Model;
using PilimFramework.DataProvider.EFModel;
using System.Collections.Generic;
using System.Linq;

namespace PilimFramework {
	public class PilimApp {

		private enum Option {
			Unknown=-1,
			Exit,
			ADONET,
			EF
		}

		private static IDictionary<Option, Configuration> __d;

		private delegate IConfig Configuration();

		public static IConfig getConfiguration() {
			Option option = Option.Unknown;
			var aux = __d.Keys.ToArray();
			while (option <Option.Exit || option>Option.EF) {
				Console.Clear();
				try {
					Console.WriteLine("Select a Configuration");
					for (int i = 1; i < aux.Length; i++)
						Console.WriteLine(i + ". " + aux[i].ToString());
					Console.WriteLine("0. Exit");
					var result = Console.ReadLine();
					option = (Option)Enum.Parse(typeof(Option), result);
				}
				catch (Exception ex) {
					Console.WriteLine("Invalid Option. ->" + ex.Message);
					Console.WriteLine("Press any key to try again.");
					Console.ReadKey();
				}
			}
			return __d[option].Invoke();
		}

		private static void Setup() {
			__d = new Dictionary<Option, Configuration>();
			__d.Add(Option.Exit,()=>null);
			__d.Add(Option.ADONET,()=>new ADONET_Config() );
			__d.Add(Option.EF, ()=> new EF_Config());
		}

		public static void Main(string[] args) {
			Setup();
			IConfig config = getConfiguration();
			if (config != null) 
				new PillimMenu(config).Run();
		}
	}
}
