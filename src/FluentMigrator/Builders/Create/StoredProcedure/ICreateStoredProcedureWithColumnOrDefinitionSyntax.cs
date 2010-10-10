using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator.Infrastructure;

namespace FluentMigrator.Builders.Create.StoredProcedure
{
	public interface ICreateStoredProcedureWithColumnOrDefinitionSyntax : IFluentSyntax
	{
		void Sql(string sqlStatements);
		void Script(string pathToSqlStatements);
		ICreateStoredProcedureParameterAsTypeSyntax WithParameter(string parameterName);
	}
}
