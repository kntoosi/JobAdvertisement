using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsSkills
	{
		[Key]
		public int Id { get; set; }
		public int AdsMaster_Id { get; set; }
		public string SkillTitle { get; set; }
		public short CvRatingLevelLST_Id { get; set; }

		public AdsSkills(int Id_, int AdsMaster_Id_, string SkillTitle_, short CvRatingLevelLST_Id_)
		{
			this.Id = Id_;
			this.AdsMaster_Id = AdsMaster_Id_;
			this.SkillTitle = SkillTitle_;
			this.CvRatingLevelLST_Id = CvRatingLevelLST_Id_;
		}
		public AdsSkills()
		{
			this.Id = 0;
			this.AdsMaster_Id = 0;
			this.SkillTitle = "";
			this.CvRatingLevelLST_Id = 0;
		}
	}
}
