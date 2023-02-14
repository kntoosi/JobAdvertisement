using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class CvRatingLevelLST
    {
		[Key]
		public short Id { get; set; }
        public string LevelTitle { get; set; }
        public bool Active { get; set; }
		public CvRatingLevelLST(short Id_, string LevelTitle_, bool Active_)
		{
			this.Id = Id_;
			this.LevelTitle = LevelTitle_;
			this.Active = Active_;
		}
		public CvRatingLevelLST()
		{
			this.Id = 0;
			this.LevelTitle = "";
			this.Active = false;
		}
	}
}
