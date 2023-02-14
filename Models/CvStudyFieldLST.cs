using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class CvStudyFieldLST
    {
		[Key]
		public int Id { get; set; }
        public string FieldTitle { get; set; }
        public bool Active { get; set; }
		public CvStudyFieldLST(short Id_, string FieldTitle_, bool Active_)
		{
			this.Id = Id_;
			this.FieldTitle = FieldTitle_;
			this.Active = Active_;
		}
		public CvStudyFieldLST()
		{
			this.Id = 0;
			this.FieldTitle = "";
			this.Active = false;
		}
	}
}
