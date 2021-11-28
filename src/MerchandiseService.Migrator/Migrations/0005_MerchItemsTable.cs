using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(5)]
	public class MerchItems : Migration
	{
		public override void Up()
		{
			Create
				.Table("merch_items")
				.WithColumn("id").AsInt32().PrimaryKey()
				.WithColumn("merch_item_type_id").AsInt32().NotNullable()
				.WithColumn("sku").AsInt32().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("merch_items");
		}
	}
}