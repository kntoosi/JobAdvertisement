using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
	public class AdsWrkBenefitOutputEntity
	{
		[Key]
		public int Id { get; set; }
		public int AdsMaster_Id { get; set; }
		public short AdsWrkBenefit_Id { get; set; }
		public string BenefitTitle { get; set; }

		public AdsWrkBenefitOutputEntity(int Id_, int AdsMaster_Id_, short AdsWrkBenefit_Id_, string BenefitTitle_)
		{
			this.Id = Id_;
			this.AdsMaster_Id = AdsMaster_Id_;
			this.AdsWrkBenefit_Id = AdsWrkBenefit_Id_;
			this.BenefitTitle = BenefitTitle_;
		}
		public AdsWrkBenefitOutputEntity()
		{
			this.Id = 0;
			this.AdsMaster_Id = 0;
			this.AdsWrkBenefit_Id = 0;
			this.BenefitTitle = "";
		}
	}
}
