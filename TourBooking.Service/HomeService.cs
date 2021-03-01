namespace TourBooking.Service
{
	using System;
	using System.ComponentModel;
	using System.Net;
	using RestSharp;
	using Newtonsoft.Json.Linq;

	/// <summary>
	/// Helper class
	/// </summary>
	public class HomeService
	{
		/// <summary>
		/// Checks if self-tour is allowed for a home
		/// </summary>
		/// <param name="homeId">Home ID</param>
		/// <returns><c>true</c> if allowed. Otherwise <c>false</c>.</returns>
		/// <exception cref="ArgumentException"> if param <paramref name="homeId"/> is null or empty string.</exception>
		/// <exception cref="Exception">if Home API fails</exception>
		public static bool IsSelfTourAllowed(string homeId)
		{
			if (string.IsNullOrWhiteSpace(homeId))
				throw new ArgumentException($"{nameof(homeId)} param is invalid.");

			RestClient client = new RestClient($"https://api-production.bln.hm/homes/{homeId}")
			{
				Timeout = 3000
			};
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Accept", "application/json");
			IRestResponse response = client.Execute(request);

			if (response.StatusCode != HttpStatusCode.OK)
				throw new Exception(response.ErrorMessage);

			JObject resultObj = JObject.Parse(response.Content);

			JToken listingInfoToken = resultObj["listingInfo"];
			ListingInfo listingInfo = listingInfoToken?.ToObject<ListingInfo>();
			return listingInfo?.IsSelfServeVisitsAllowed ?? false;
		}
	}
}