using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Core.Domain;
using TourBooking.Core.Models;
using TourBooking.Core.Services.Interfaces;

namespace TourBooking.Core.Services
{
    public class HomeService : IHomeService
    {
        private System.Net.Http.HttpClient client;
        private readonly IRepository<Home> homeRepository;

        public HomeService(IRepository<Home> homeRepository)
        {
            this.client = new HttpClient();
            this.homeRepository = homeRepository;
        }

        public async Task<bool> IsSelfTourAllowed(string homeId)
        {
            if (string.IsNullOrWhiteSpace(homeId))
                throw new ArgumentException($"{nameof(homeId)} param is invalid.");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync($"https://api-production.bln.hm/homes/{homeId}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            JObject resultObj = JObject.Parse(responseBody);

            JToken listingInfoToken = resultObj["listingInfo"];
            ListingInfo listingInfo = listingInfoToken?.ToObject<ListingInfo>();
            return listingInfo?.IsSelfServeVisitsAllowed ?? false;
        }

        public async Task<IEnumerable<Home>> GetAll()
        {
            var rvalue = new List<Home>();
            var homes = await this.homeRepository.GetAll();

            foreach(var item in homes)
            {
                if(await this.IsSelfTourAllowed(item.BussinesId))
                {
                    rvalue.Add(item);
                }
            }

            return rvalue;
        }
    }
}
