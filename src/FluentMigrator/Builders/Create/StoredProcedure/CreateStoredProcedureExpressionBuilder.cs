using System;
using FluentMigrator.Expressions;
using FluentMigrator.Model;

namespace FluentMigrator.Builders.Create.StoredProcedure
{
	public class CreateStoredProcedureExpressionBuilder : ExpressionBuilderWithColumnTypesBase<CreateStoredProcedureExpression, 
		ICreateStoredProcedureParameterOptionOrWithParameterOrDefinitionSyntax>, 
		ICreateStoredProcedureRootSyntax, 
		ICreateStoredProcedureParameterAsTypeSyntax,
		ICreateStoredProcedureParameterOptionOrWithParameterOrDefinitionSyntax
	{		private ColumnDefinition _currentParameter;

		public CreateStoredProcedureExpressionBuilder(CreateStoredProcedureExpression expression) : base(expression)
		{
		}

		public void Sql(string sqlStatements)
		{
			Expression.SqlStatements = sqlStatements;
		}

		public void Script(string pathToSqlStatements)
		{
			Expression.SqlScript = pathToSqlStatements;
		}

		public ICreateStoredProcedureWithColumnOrDefinitionSyntax Comment(string comment)
		{
			Expression.Comment = comment;
			return this;
		}

		public ICreateStoredProcedureParameterAsTypeSyntax WithParameter(string parameterName)
		{
			_currentParameter = new ColumnDefinition() {Name = parameterName};
			Expression.Parameters.Add(_currentParameter);
			return this;	
		}

		public ICreateStoredProcedureWithColumnOrDefinitionSyntax WithDefaultValue(object value)
		{
			_currentParameter.DefaultValue = value;
			return this;
		}

		protected override ColumnDefinition GetColumnForType()
		{
			return _currentParameter;
		}
	}
}
