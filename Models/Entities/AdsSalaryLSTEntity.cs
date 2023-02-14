using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsSalaryLSTEntity
    {
		[Key]
		/// <summary>
		/// شناسه 
		/// </summary>
		public short Id { get; set; }
		/// <summary>
		/// عنوان حقوق 
		/// </summary>
		public string SalaryTitle { get; set; }

		/// <summary>
		/// وضعیت 
		/// </summary>
		public bool Active { get; set; }

		public AdsSalaryLSTEntity(short Id_, string SalaryTitle_, bool Active_)
		{
			this.Id = Id_;
			this.SalaryTitle = SalaryTitle_;
			this.Active = Active_;
		}
		public AdsSalaryLSTEntity()
		{
			this.Id = 0;
			this.SalaryTitle = "";
			this.Active = false;
		}
	}
}
