﻿using System;
using System.Text;
using FluentMigrator.Model;

namespace FluentMigrator.Runner.Generators
{
	class SqlServerColumn : ColumnBase
	{
		public SqlServerColumn(ITypeMap typeMap) : base(typeMap, new ConstantFormatter())
		{
		}

		protected override string FormatIdentity(ColumnDefinition column)
		{
			return column.IsIdentity ? "IDENTITY(1,1)" : string.Empty;
		}

		protected override string FormatPrimaryKey(ColumnDefinition column)
		{
			return column.IsPrimaryKey ? "PRIMARY KEY CLUSTERED" : string.Empty;
		}
	}
}
