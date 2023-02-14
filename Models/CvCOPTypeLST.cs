using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class CvCOPTypeLST
	{
		[Key]
		public short Id { get; set; }
		public string CoTitle { get; set; }
		public bool Active { get; set; }

		public CvCOPTypeLST(short Id_, string CoTitle_, bool Active_)
		{
			this.Id = Id_;
			this.CoTitle = CoTitle_;
			this.Active = Active_;
		}
		public CvCOPTypeLST()
		{
			this.Id = 0;
			this.CoTitle = "";
			this.Active = false;
		}
	}
}
