using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsWrkPlaceLSTEntity
    {
		[Key]
		public short Id { get; set; }
		public string PlaceTitle { get; set; }
		public bool Active { get; set; }

		public AdsWrkPlaceLSTEntity(short Id_, string PlaceTitle_, bool Active_)
		{
			this.Id = Id_;
			this.PlaceTitle = PlaceTitle_;
			this.Active = Active_;
		}
		public AdsWrkPlaceLSTEntity()
		{
			this.Id = 0;
			this.PlaceTitle = "";
			this.Active = false;
		}
	}
}
