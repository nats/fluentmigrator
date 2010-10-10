using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMigrator.Builders.Create.StoredProcedure
{
	public interface ICreateStoredProcedureRootSyntax : ICreateStoredProcedureWithColumnOrDefinitionSyntax
	{
		ICreateStoredProcedureWithColumnOrDefinitionSyntax Comment(string comment);
		ICreateStoredProcedureParameterAsTypeSyntax WithParameter(string parameterNameName);
	}
}
