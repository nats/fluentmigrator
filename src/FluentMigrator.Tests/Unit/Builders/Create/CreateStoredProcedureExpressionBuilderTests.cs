using System.Data;
using FluentMigrator.Builders.Create.StoredProcedure;
using FluentMigrator.Expressions;
using NUnit.Framework;
using NUnit.Should;

namespace FluentMigrator.Tests.Unit.Builders.Create
{
	[TestFixture]
	public class CreateStoredProcedureExpressionBuilderTests
	{
		private CreateStoredProcedureExpression expression;
		private ICreateStoredProcedureRootSyntax builder;
		private readonly string COMMENT = @"-- Comment";
		private readonly string SQLSTATEMENTS = "SELECT * FROM Table";

		[SetUp]
		public void SetUp()
		{
			expression = new CreateStoredProcedureExpression();
			builder = new CreateStoredProcedureExpressionBuilder(expression);
		}

		[Test]
		public void BasicSqlUsage()
		{
			builder.Sql(SQLSTATEMENTS);

			expression.SqlStatements.ShouldBe(SQLSTATEMENTS);
		}

		[Test]
		public void BasicScriptUsage()
		{
			builder.Script(@"C:\MyScript.sql");

			expression.SqlScript.ShouldBe(@"C:\MyScript.sql");
		}

		[Test]
		public void Comment()
		{
			builder.Comment(COMMENT);

			expression.Comment.ShouldBe(COMMENT);
		}

		[Test]
		public void CommentWithStatements()
		{
			builder.Comment(COMMENT).Sql(SQLSTATEMENTS);

			expression.SqlStatements.ShouldBe(SQLSTATEMENTS);
			expression.Comment.ShouldBe(COMMENT);
		}

		[Test]
		public void Parameter()
		{
			builder.WithParameter("Test");

			expression.Parameters[0].Name.ShouldBe("Test");
		}

		[Test]
		public void ParameterType()
		{
			builder.WithParameter("Test").AsInt32();

			expression.Parameters[0].Type.ShouldBe(DbType.Int32);
		}

		[Test]
		public void ParameterDefaultValue()
		{
			builder.WithParameter("Test").AsInt32().WithDefaultValue(0);

			expression.Parameters[0].DefaultValue.ToString().ShouldBe("0");
		}

		[Test]
		public void MultipleParameters()
		{
			builder.WithParameter("Test").AsInt32().WithDefaultValue(0)
				.WithParameter("Test2").AsString(4096);

			expression.Parameters[1].Name.ShouldBe("Test2");
			expression.Parameters[1].Type.ShouldBe(DbType.String);
			expression.Parameters[1].Size.ShouldBe(4096);
		}

		[Test]
		public void CompleteUsage()
		{
			builder.Comment(COMMENT)
				.WithParameter("Test").AsInt32().WithDefaultValue(0)
				.WithParameter("Test2").AsString(4096)
				.Sql(SQLSTATEMENTS);

			expression.Comment.ShouldBe(COMMENT);
			expression.Parameters.Count.ShouldBe(2);

			expression.Parameters[0].Name.ShouldBe("Test");
			expression.Parameters[0].Type.ShouldBe(DbType.Int32);
			expression.Parameters[0].DefaultValue.ToString().ShouldBe("0");

			expression.Parameters[1].Name.ShouldBe("Test2");
			expression.Parameters[1].Type.ShouldBe(DbType.String);
			expression.Parameters[1].Size.ShouldBe(4096);

			expression.SqlStatements.ShouldBe(SQLSTATEMENTS);
		}
	}
}
