using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsSkillsOutputEntity
    {
		[Key]
		/// <summary>
		/// شناسه 
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// کد جدول اصلی آگهی 
		/// </summary>
		public int AdsMaster_Id { get; set; }
		/// <summary>
		/// عنوان مهارت مورد نیاز 
		/// </summary>
		public string SkillTitle { get; set; }
		/// <summary>
		/// کد سطح مهارت موردنیاز  
		/// </summary>
		public short CvRatingLevelLST_Id { get; set; }
		/// <summary>
		/// عنوان سطح مهارت موردنیاز  
		/// </summary>
		public string LevelTitle { get; set; }

		public AdsSkillsOutputEntity(int Id_, int AdsMaster_Id_, string SkillTitle_, short CvRatingLevelLST_Id_, string LevelTitle_)
		{
			this.Id = Id_;
			this.AdsMaster_Id = AdsMaster_Id_;
			this.SkillTitle = SkillTitle_;
			this.CvRatingLevelLST_Id = CvRatingLevelLST_Id_;
			this.LevelTitle = LevelTitle_;
		}
		public AdsSkillsOutputEntity()
		{
			this.Id = 0;
			this.AdsMaster_Id = 0;
			this.SkillTitle = "";
			this.CvRatingLevelLST_Id = 0;
			this.LevelTitle = "";
		}
	}
}
