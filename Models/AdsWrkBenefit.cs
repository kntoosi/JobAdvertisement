using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsWrkBenefit
    {
		[Key]
		public int Id { get; set; }
		public int AdsMaster_Id { get; set; }
		public short AdsWrkBenefit_Id { get; set; }

		public AdsWrkBenefit(int Id_, int AdsMaster_Id_, short AdsWrkBenefit_Id_)
		{
			this.Id = Id_;
			this.AdsMaster_Id = AdsMaster_Id_;
			this.AdsWrkBenefit_Id = AdsWrkBenefit_Id_;
		}
		public AdsWrkBenefit()
		{
			this.Id = 0;
			this.AdsMaster_Id = 0;
			this.AdsWrkBenefit_Id = 0;
		}
	}
}
