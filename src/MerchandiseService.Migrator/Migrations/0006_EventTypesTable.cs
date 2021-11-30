using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(6)]
	public class EventTypesTable : Migration
	{
		public override void Up()
		{
			Create
				.Table("event_types")
				.WithColumn("event_type_id").AsInt32().PrimaryKey()
				.WithColumn("name").AsString().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("event_types");
		}
	}
}