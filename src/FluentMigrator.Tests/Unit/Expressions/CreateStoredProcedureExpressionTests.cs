using FluentMigrator.Expressions;
using NUnit.Framework;
using NUnit.Should;

namespace FluentMigrator.Tests.Unit.Expressions
{
	[TestFixture]
	public class CreateStoredProcedureExpressionTests
	{
		[Test]
		public void ToStringIsDescriptive()
		{
			new CreateStoredProcedureExpression
			{
				Name = "MyProc"
			}.ToString().ShouldBe("CreateStoredProcedure MyProc");
		}
	}
}
