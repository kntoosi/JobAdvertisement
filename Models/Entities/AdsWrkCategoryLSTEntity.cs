using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsWrkCategoryLSTEntity
    {
		[Key]
		public short Id { get; set; }
		public string CategoryTitle { get; set; }
		public bool Active { get; set; }

		public AdsWrkCategoryLSTEntity(short Id_, string CategoryTitle_, bool Active_)
		{
			this.Id = Id_;
			this.CategoryTitle = CategoryTitle_;
			this.Active = Active_;
		}
		public AdsWrkCategoryLSTEntity()
		{
			this.Id = 0;
			this.CategoryTitle = "";
			this.Active = false;
		}
	}
}
