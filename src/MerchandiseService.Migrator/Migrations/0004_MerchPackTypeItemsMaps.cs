using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(4)]
	public class MerchPackTypeItemsMaps : Migration
	{
		public override void Up()
		{
			Create
				.Table("merch_pack_type_items_maps")
				.WithColumn("merch_pack_type_id").AsInt32().PrimaryKey()
				.WithColumn("merch_pack_item_type_id").AsInt32().PrimaryKey();
		}

		public override void Down()
		{
			Delete.Table("merch_pack_types");
		}
	}
}