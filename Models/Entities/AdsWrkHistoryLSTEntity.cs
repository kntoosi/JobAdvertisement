using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsWrkHistoryLSTEntity
	{
		[Key]
		public short Id { get; set; }
		public string WrkHistoryTitle { get; set; }
		public bool Active { get; set; }

		public AdsWrkHistoryLSTEntity(short Id_, string WrkHistoryTitle_, bool Active_)
		{
			this.Id = Id_;
			this.WrkHistoryTitle = WrkHistoryTitle_;
			this.Active = Active_;
		}

		public AdsWrkHistoryLSTEntity()
		{
			this.Id = 0;
			this.WrkHistoryTitle = "";
			this.Active = false;
		
	}
}
}
