using FluentMigrator.Expressions;
using NUnit.Framework;
using NUnit.Should;

namespace FluentMigrator.Tests.Unit.Expressions
{
	[TestFixture]
	public class DeleteStoredProcedureExpressionTests
	{
		[Test]
		public void ToStringIsDescriptive()
		{
			new DeleteStoredProcedureExpression
			{
				Name = "MyProc"
			}.ToString().ShouldBe("DeleteStoredProcedure MyProc");
		}
	}
}
