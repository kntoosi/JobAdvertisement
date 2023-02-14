using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsSuggestedJobLSTEntity
    {
		[Key]
		/// <summary>
		/// شناسه 
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// عنوان شعل 
		/// </summary>
		public string JobTitle { get; set; }
		/// <summary>
		/// وضعیت 
		/// </summary>
		public bool Active { get; set; }

		public AdsSuggestedJobLSTEntity(int Id_, string JobTitle_, bool Active_)
		{
			this.Id = Id_;
			this.JobTitle = JobTitle_;
			this.Active = Active_;
		}
		public AdsSuggestedJobLSTEntity()
		{
			this.Id = 0;
			this.JobTitle = "";
			this.Active = false;
		}
	}
}
