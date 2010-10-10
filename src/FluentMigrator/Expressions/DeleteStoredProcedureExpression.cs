using System;
using System.Collections.Generic;
using FluentMigrator.Infrastructure;

namespace FluentMigrator.Expressions
{
	public class DeleteStoredProcedureExpression : MigrationExpressionBase
	{
		public virtual string Name { get; set; }

		public override void CollectValidationErrors(ICollection<string> errors)
		{
			if (String.IsNullOrEmpty(Name))
				errors.Add(ErrorMessages.StoredProcedureNameCanNotBeNullOrEmpty);
		}

		public override void ExecuteWith(IMigrationProcessor processor)
		{
			processor.Process(this);
		}

		public override string ToString()
		{
			return base.ToString() + Name;
		}
	}
}