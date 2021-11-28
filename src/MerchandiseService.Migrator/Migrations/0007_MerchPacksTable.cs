using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(7)]
	public class MerchPacksTable : Migration
	{
		public override void Up()
		{
			Create
				.Table("merch_packs")
				.WithColumn("merch_pack_id").AsInt32().PrimaryKey()
				.WithColumn("name").AsString().NotNullable()
				.WithColumn("merch_pack_type_id").AsString().NotNullable()
				.WithColumn("merch_pack_status_id").AsString().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("merch_packs");
		}
	}
}