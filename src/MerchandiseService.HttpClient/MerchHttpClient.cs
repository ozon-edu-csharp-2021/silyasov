using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpClient.Exceptions;
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

		public async Task<int> GetMerchAsync(int merchId, CancellationToken token)
		{
			using var response = await _httpClient.GetAsync($"v1/api/merch/{merchId}", token);
			if (!response.IsSuccessStatusCode)
				throw new ResponseException();
			
			var body = await response.Content.ReadAsStringAsync(token);
			return JsonSerializer.Deserialize<int>(body);
		}
		
		public async Task<string> GetMerchInfoAsync(int merchId, CancellationToken token)
		{
			using var response = await _httpClient.GetAsync($"v1/api/merch/{merchId}/info", token);
			if (!response.IsSuccessStatusCode)
				throw new ResponseException();
			
			var body = await response.Content.ReadAsStringAsync(token);
			return JsonSerializer.Deserialize<string>(body);
		}
	}
}