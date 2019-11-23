﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilimFramework.Menu {
	public class SqlBatchCommand {
		public string MainQuery { get; }

		public CommandType CommandType { get; }

		public IDictionary<string, IDictionary<object, SqlDbType>> ParamInfo { get; set; }

		public SqlBatchCommand(string mainQuery, CommandType commandType) {
			this.CommandType = commandType;
			this.MainQuery = mainQuery;
		}
	}
}
