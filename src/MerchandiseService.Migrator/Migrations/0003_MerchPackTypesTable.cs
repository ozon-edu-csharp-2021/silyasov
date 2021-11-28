using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(3)]
	public class MerchPackTypesTable : Migration
	{
		public override void Up()
		{
			Create
				.Table("merch_pack_types")
				.WithColumn("merch_pack_type_id").AsInt32().PrimaryKey()
				.WithColumn("name").AsString().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("merch_pack_types");
		}
	}
}