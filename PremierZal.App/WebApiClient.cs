using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PremierZal.Common.Models;

namespace PremierZal.App
{
    public class WebApiClient
    {
        private readonly HttpClient _httpClient;

        public WebApiClient(string url)
        {
            _httpClient = new HttpClient {BaseAddress = new Uri(url)};
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Session>> GetSeasonsAsync()
        {
            var response = await _httpClient.GetAsync("api/sessions");
            response.EnsureSuccessStatusCode();

            var seasons = await response.Content.ReadAsAsync<IEnumerable<Session>>();

            return seasons;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var response = await _httpClient.GetAsync("api/orders");
            response.EnsureSuccessStatusCode();

            var orders = await response.Content.ReadAsAsync<IEnumerable<Order>>();

            return orders;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            var response = await _httpClient.PostAsJsonAsync("api/orders", order);
            response.EnsureSuccessStatusCode();

            order = await response.Content.ReadAsAsync<Order>();

            return order;
        }
    }
}