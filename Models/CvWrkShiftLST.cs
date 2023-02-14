using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class CvWrkShiftLST
	{
		[Key]
		public short Id { get; set; }
		public string ShiftTitle { get; set; }
		public bool Active { get; set; }

		public CvWrkShiftLST(short Id_, string ShiftTitle_, bool Active_)
		{
			this.Id = Id_;
			this.ShiftTitle = ShiftTitle_;
			this.Active = Active_;
		}
		public CvWrkShiftLST()
		{
			this.Id = 0;
			this.ShiftTitle = "";
			this.Active = false;
		}
	}
}
