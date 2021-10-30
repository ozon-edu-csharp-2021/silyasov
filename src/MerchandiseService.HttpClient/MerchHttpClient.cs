using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpClient.Interfaces;
using MerchandiseService.HttpClient.Models;

namespace MerchandiseService.HttpClient
{
	public class MerchHttpClient : IMerchHttpClient
	{
		private readonly System.Net.Http.HttpClient _httpClient;

		public MerchHttpClient(System.Net.Http.HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<MerchModelResponse>> GetMerchAsync(int merchId, CancellationToken token)
		{
			using var response = await _httpClient.GetAsync($"v1/api/merch/getmerch/{merchId}", token);
			var body = await response.Content.ReadAsStringAsync(token);
			return JsonSerializer.Deserialize<List<MerchModelResponse>>(body);
		}
		
		public async Task<List<MerchModelResponse>> GetMerchInfoAsync(int merchId, CancellationToken token)
		{
			using var response = await _httpClient.GetAsync($"v1/api/merch/getmerchinfo/{merchId}", token);
			var body = await response.Content.ReadAsStringAsync(token);
			return JsonSerializer.Deserialize<List<MerchModelResponse>>(body);
		}
	}
}