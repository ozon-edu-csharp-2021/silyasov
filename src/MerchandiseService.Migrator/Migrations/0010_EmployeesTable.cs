using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(10)]
	public class EmployeesTable : Migration 
	{
		public override void Up()
		{
			Create
				.Table("employees")
				.WithColumn("id").AsInt32().PrimaryKey()
				.WithColumn("first_name").AsString().NotNullable()
				.WithColumn("last_name").AsString().NotNullable()
				.WithColumn("sex").AsInt32().NotNullable()
				.WithColumn("clothing_size").AsInt32().NotNullable()
				.WithColumn("hire_date").AsDate().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("employees");
		}
	}
}