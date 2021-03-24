namespace TourBooking.Core.Models
{
	public class ListingInfo
	{
		public PetInfo PetInfo { get; set; }
		public bool IsDemoUnit { get; set; }
		public bool IsAvailableForRent { get; set; }
		public bool IsSelfServeVisitsAllowed { get; set; }
		public bool IsOpenHouseAllowed { get; set; }
	}
}