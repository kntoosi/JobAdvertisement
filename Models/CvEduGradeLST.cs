using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class CvEduGradeLST
    {
		[Key]
		public short Id { get; set; }
        public string GradeTitle { get; set; }
        public bool Active { get; set; }
		public CvEduGradeLST(short Id_, string GradeTitle_, bool Active_)
		{
			this.Id = Id_;
			this.GradeTitle = GradeTitle_;
			this.Active = Active_;
		}
		public CvEduGradeLST()
		{
			this.Id = 0;
			this.GradeTitle = "";
			this.Active = false;
		}
	}
}
