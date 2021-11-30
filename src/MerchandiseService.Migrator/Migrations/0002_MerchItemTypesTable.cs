using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(2)]
	public class MerchItemTypesTable : Migration
	{
		public override void Up()
		{
			Create
				.Table("merch_item_types")
				.WithColumn("merch_item_type_id").AsInt32().PrimaryKey()
				.WithColumn("name").AsString().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("merch_item_types");
		}
	}
}