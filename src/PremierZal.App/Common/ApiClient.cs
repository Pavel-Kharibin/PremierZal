using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PremierZal.Common.Models;

namespace PremierZal.App.Common
{
    public static class ApiClient
    {
        private static HttpClient GetClient()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(Config.BaseUrl)};
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public static async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            var response = await GetClient().GetAsync("api/sessions");
            response.EnsureSuccessStatusCode();

            var seasons = await response.Content.ReadAsAsync<IEnumerable<Session>>();

            return seasons;
        }

        public static async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var response = await GetClient().GetAsync("api/orders");
            response.EnsureSuccessStatusCode();

            var orders = await response.Content.ReadAsAsync<IEnumerable<Order>>();

            return orders;
        }

        public static async Task<Order> AddOrderAsync(Order order)
        {
            var response = await GetClient().PostAsJsonAsync("api/orders", order);
            response.EnsureSuccessStatusCode();

            order = await response.Content.ReadAsAsync<Order>();

            return order;
        }
    }
}