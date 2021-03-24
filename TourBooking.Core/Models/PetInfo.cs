namespace TourBooking.Core.Models
{
	public class PetInfo
	{
		public bool AnyPets { get; set; }
		public bool NoPets { get; set; }
		public object[] RestrictedBreeds { get; set; }
		public string FeeOption { get; set; }
		public int FeeAmount { get; set; }
		public bool IsPetFriendly { get; set; }
	}
}