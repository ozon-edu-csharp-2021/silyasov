using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(1)]
	public class MerchPackStatusesTable : Migration
	{
		public override void Up()
		{
			Create
				.Table("merch_pack_statuses")
				.WithColumn("merch_pack_status_id").AsInt32().PrimaryKey()
				.WithColumn("name").AsString().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("merch_pack_statuses");
		}
	}
}