using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Services
{
	public interface IStockService
	{
		public Task<List<StockItem>> GetAll(CancellationToken token);
	}
	
	public class StockService : IStockService
	{
		private readonly List<StockItem> _stockItems = new List<StockItem>()
		{
			new StockItem(1, "Mask", 20),
			new StockItem(1, "Mask", 20),
			new StockItem(1, "Mask", 20)
		};
		public Task<List<StockItem>> GetAll(CancellationToken token) => Task.FromResult(_stockItems);
	}

	public class StockItem
	{
		public StockItem(long itemId, string itemName, int quantity)
		{
			_itemId = itemId;
			_itemName = itemName;
			_quantity = quantity;
		}
		private long _itemId;
		private string _itemName;
		private int _quantity;
	}

}