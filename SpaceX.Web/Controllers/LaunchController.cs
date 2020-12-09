using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SpaceX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceX.Web.Controllers
{
    public class LaunchController : Controller
    {
        private readonly string getAllLaunchesUrl = "https://api.spacexdata.com/v3/launches";

        public async Task<ICollection<LaunchPlanModel>> GetAll()
        {
            var client = new RestClient($"{getAllLaunchesUrl}");
            var request = new RestRequest($"{getAllLaunchesUrl}", Method.GET);

            IRestResponse response = client.Execute(request);

            var launchList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LaunchPlanModel>>(response.Content);

            return launchList;
        }
    }
}