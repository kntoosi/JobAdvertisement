using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsWrkBenefitLSTEntity
    {
		[Key]
		public short Id { get; set; }
		public string BenefitTitle { get; set; }
		public bool Active { get; set; }

		public AdsWrkBenefitLSTEntity(short Id_, string BenefitTitle_, bool Active_)
		{
			this.Id = Id_;
			this.BenefitTitle = BenefitTitle_;
			this.Active = Active_;
		}
		public AdsWrkBenefitLSTEntity()
		{
			this.Id = 0;
			this.BenefitTitle = "";
			this.Active = false;
		}
	}
}
