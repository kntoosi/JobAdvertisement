using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsEducation
    {
		[Key]
		public int Id { get; set; }
		public int AdsMaster_Id { get; set; }
		public short CVEduGradeLST_Id { get; set; }
		public int CvStudyFieldLST_Id { get; set; }

		public AdsEducation(int Id_, int AdsMaster_Id_, short CVEduGradeLST_Id_, int CvStudyFieldLST_Id_)
		{
			this.Id = Id_;
			this.AdsMaster_Id = AdsMaster_Id_;
			this.CVEduGradeLST_Id = CVEduGradeLST_Id_;
			this.CvStudyFieldLST_Id = CvStudyFieldLST_Id_;
		}
		public AdsEducation()
		{
			this.Id = 0;
			this.AdsMaster_Id = 0;
			this.CVEduGradeLST_Id = 0;
			this.CvStudyFieldLST_Id = 0;
		}
	}
}
