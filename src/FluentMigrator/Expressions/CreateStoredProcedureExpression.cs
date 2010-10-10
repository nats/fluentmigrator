using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator.Infrastructure;
using FluentMigrator.Model;

namespace FluentMigrator.Expressions
{
	public class CreateStoredProcedureExpression : MigrationExpressionBase
	{
		public string Name { get; set; }
		public string SqlStatements { get; set; }
		public string Comment { get; set; }
		public IList<ColumnDefinition> Parameters { get; set; }

		public CreateStoredProcedureExpression()
		{
			Parameters = new List<ColumnDefinition>();
		}

		public override void CollectValidationErrors(ICollection<string> errors)
		{
			if (String.IsNullOrEmpty(Name))
				errors.Add(ErrorMessages.StoredProcedureNameCanNotBeNullOrEmpty);

			if (String.IsNullOrEmpty(SqlStatements))
				errors.Add(ErrorMessages.StoredProcedureDefinitionCanNotBeNullOrEmpty);

			foreach (var parameter in Parameters)
				parameter.CollectValidationErrors(errors);
		}

		public override void ExecuteWith(IMigrationProcessor processor)
		{
			processor.Process(this);
		}

		public override IMigrationExpression Reverse()
		{
			return new DeleteStoredProcedureExpression { Name = Name };
		}

		public override string ToString()
		{
			return base.ToString() + Name;
		}

	}
}
