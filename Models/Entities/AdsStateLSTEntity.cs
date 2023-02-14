using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsStateLSTEntity
    {
		[Key]
		/// <summary>
		/// شناسه 
		/// </summary>
		public short Id { get; set; }
		/// <summary>
		/// عنوان وضعیت آگهی 
		/// </summary>
		public string AdsStateTitle { get; set; }
		/// <summary>
		/// وضعیت 
		/// </summary>
		public bool Active { get; set; }

		public AdsStateLSTEntity(short Id_, string AdsStateTitle_, bool Active_)
		{
			this.Id = Id_;
			this.AdsStateTitle = AdsStateTitle_;
			this.Active = Active_;
		}
		public AdsStateLSTEntity()
		{
			this.Id = 0;
			this.AdsStateTitle = "";
			this.Active = false;

		}
	}
}
