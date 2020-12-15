using SpaceX.Models;
using SpaceX.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SpaceX.Services.Services
{
    /// <summary>
    /// A service class which contains methods for extracting data from SpaceX API
    /// </summary>
    public class DataService : IDataService
    {
        private const string getAllLaunchesUrl = "https://api.spacexdata.com/v3/launches";

        public async Task<List<LaunchPlan>> GetLaunchList(int page, int limit)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(getAllLaunchesUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(1.00);

            var offset = (page - 1) * limit;

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"?limit={limit}&offset={offset}");

            response.EnsureSuccessStatusCode();

            var launchList = Newtonsoft.Json.JsonConvert
                .DeserializeObject<List<LaunchPlan>>(response.Content.ReadAsStringAsync().Result);

            return launchList;
        }

        public async Task<LaunchPlan> GetLaunchPlan(string flightNumber)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(getAllLaunchesUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(1.00);


            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"?flight_number={flightNumber}");

            response.EnsureSuccessStatusCode();

            var launchList = Newtonsoft.Json.JsonConvert
                .DeserializeObject<List<LaunchPlan>>(response.Content.ReadAsStringAsync().Result);

            return launchList.FirstOrDefault();
        }
    }
}