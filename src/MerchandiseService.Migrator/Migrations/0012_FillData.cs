using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(12)]
	public class FillData : ForwardOnlyMigration
	{
		public override void Up()
		{
			Execute.Sql(@"
                INSERT INTO merch_pack_type_items_maps (merch_pack_type_id, merch_pack_item_type_id)
                VALUES 
                    (1, 2),
                    (2, 2),
                    (2, 5),
                    (3, 3),
                    (3, 4),
                    (4, 2),
                    (4, 3),
                    (4, 4),
                    (5, 1),
                    (5, 5),
                    (5, 6)
                ON CONFLICT DO NOTHING");
			
			Execute.Sql(@"
                INSERT INTO merch_items (merch_item_id, name, merch_item_type_id, sku)
                VALUES 
                    (1, 'Black cup', 2, 111111),
                    (2, '10% discount Tehnosila', 5, 222222),
                    (3, 'Green socks', 1, 333333),
                    (4, 'White notebook', 3, 444444),
                    (5, 'Blue pen',4, 112332),
                    (6, 'Gold watch',6, 666666)
                ON CONFLICT DO NOTHING");

			Execute.Sql(@"
                INSERT INTO merch_packs (merch_pack_id, name, merch_pack_type_id, merch_pack_status_id)
                VALUES 
                    (1, 'Starter Packk', 2, 1)
                ON CONFLICT DO NOTHING");
			
			Execute.Sql(@"
                INSERT INTO merch_packs_items_maps (merch_pack_id, merch_item_id, quantity)
                VALUES 
                    (1, 1, 2),
                    (1, 2, 1)
                ON CONFLICT DO NOTHING");
			
			/*
			 * new Employee(
				1,
				"Иван",
				"Волков",
				Sex.Male, 
				ClothingSize.XL,
				new HireDate(DateTime.Now))
				
				Create
				.Table("employees")
				.WithColumn("id").AsInt32().PrimaryKey()
				.WithColumn("first_name").AsString().NotNullable()
				.WithColumn("last_name").AsString().NotNullable()
				.WithColumn("sex").AsInt32().NotNullable()
				.WithColumn("clothing_size_id").AsInt32().NotNullable()
				.WithColumn("hire_date").AsDate().NotNullable();
			 */
			Execute.Sql(@"
                INSERT INTO employees (id, first_name, last_name,sex , clothing_size_id, hire_date)
                VALUES 
                    (1, 'Иван', 'Волков', 0, 5, '01.06.2020')
                ON CONFLICT DO NOTHING");
		}
	}
}