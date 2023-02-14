using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.DTO
{
    public class AdsWrkBenefitInputEntity
	{
		[Key]
		//public int Id { get; set; }
		//public int AdsMaster_Id { get; set; }
		public short AdsWrkBenefit_Id { get; set; }

		//public AdsWrkBenefitInputEntity(int Id_, int AdsMaster_Id_, short AdsWrkBenefit_Id_)
		public AdsWrkBenefitInputEntity( short AdsWrkBenefit_Id_)
		{
			//this.Id = Id_;
			//this.AdsMaster_Id = AdsMaster_Id_;
			this.AdsWrkBenefit_Id = AdsWrkBenefit_Id_;
		}
		public AdsWrkBenefitInputEntity()
		{
			//this.Id = 0;
			//this.AdsMaster_Id = 0;
			this.AdsWrkBenefit_Id = 0;
		}
	}
}
