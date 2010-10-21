using FluentMigrator.Infrastructure;

namespace FluentMigrator.Builders.Create.ForeignKey
{
	public interface ICreateForeignKeyCascadeSyntax : IFluentSyntax
	{
		ICreateForeignKeyCascadeSyntax OnDelete(ForeignKeyAction action);
		ICreateForeignKeyCascadeSyntax OnUpdate(ForeignKeyAction action);
	}
}