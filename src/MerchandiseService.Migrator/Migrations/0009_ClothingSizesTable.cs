using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(9)]
	public class ClothingSizesTable : Migration
	{
		public override void Up()
		{
			Create
				.Table("clothing_sizes")
				.WithColumn("id").AsInt32().PrimaryKey()
				.WithColumn("name").AsString().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("clothing_sizes");
		}
	}
}