using FluentMigrator;

namespace MerchandiseService.Migrator.Migrations
{
	[Migration(11)]
	public class FillDictionaries : ForwardOnlyMigration
	{
		public override void Up()
		{
			Execute.Sql(@"
                INSERT INTO clothing_sizes (clothing_size_id, name)
                VALUES 
                    (1, 'XS'),
                    (2, 'S'),
                    (3, 'M'),
                    (4, 'L'),
                    (5, 'XL'),
                    (6, 'XXL')
                ON CONFLICT DO NOTHING");

			Execute.Sql(@"
                INSERT INTO merch_pack_types (merch_pack_type_id, name)
                VALUES 
                    (1,  'Welcome Pack'),
                    (2,  'Starter Pack'),
                    (3,  'Conference Listener Pack'),
                    (4,  'Conference Speaker Pack'),
                    (5,  'Veteran Pack')
                ON CONFLICT DO NOTHING");
			
			Execute.Sql(@"
                INSERT INTO merch_pack_statuses (merch_pack_status_id, name)
                VALUES 
                    (1,  'Requested'),
                    (2,  'Not In Stock'),
                    (3,  'Received')
                ON CONFLICT DO NOTHING
            ");
			
			Execute.Sql(@"
                INSERT INTO merch_item_types (merch_item_type_id, name)
                VALUES 
                    (1,  'Socks'),
                    (2,  'Cup'),
                    (3,  'Notebook'),
                    (4,  'Pen'),
                    (5,  'Coupon'),
                    (6,  'Watch')
                ON CONFLICT DO NOTHING
            ");
		}
	}
}