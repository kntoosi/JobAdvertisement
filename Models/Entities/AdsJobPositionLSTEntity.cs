using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsJobPositionLSTEntity
    {
		[Key]
		/// <summary>
		/// شناسه 
		/// </summary>
		public short Id { get; set; }
		/// <summary>
		/// عنوان موقعیت شغلی 
		/// </summary>
		public string PositionTitle { get; set; }
		/// <summary>
		/// وضعیت 
		/// </summary>
		public bool Active { get; set; }

		public AdsJobPositionLSTEntity(short Id_, string PositionTitle_, bool Active_)
		{
			this.Id = Id_;
			this.PositionTitle = PositionTitle_;
			this.Active = Active_;
		}
		public AdsJobPositionLSTEntity()
		{
			this.Id = 0;
			this.PositionTitle = "";
			this.Active = false;
		}
	}
}
