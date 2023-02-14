using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsGenderLSTEntity
    {
		[Key]
		/// <summary>
		/// شناسه 
		/// </summary>
		public short Id { get; set; }
		/// <summary>
		/// عنوان نوع جنسیت 
		/// </summary>
		public string genderTitle { get; set; }
		/// <summary>
		/// وضعیت 
		/// </summary>
		public bool Active { get; set; }

		public AdsGenderLSTEntity(short Id_, string genderTitle_, bool Active_)
		{
			this.Id = Id_;
			this.genderTitle = genderTitle_;
			this.Active = Active_;
		}
		public AdsGenderLSTEntity()
		{
			this.Id = 0;
			this.genderTitle = "";
			this.Active = false;
		}

	}
}
