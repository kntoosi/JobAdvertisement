using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsForeignLang
    {
		[Key]
		public int Id { get; set; }
		public int AdsMaster_Id { get; set; }
		public short CvForeignLangLST_Id { get; set; }
		public short CvRatingLevelLST_Id { get; set; }

		public AdsForeignLang(int Id_, int AdsMaster_Id_, short CvForeignLangLST_Id_, short CvRatingLevelLST_Id_)
		{
			this.Id = Id_;
			this.AdsMaster_Id = AdsMaster_Id_;
			this.CvForeignLangLST_Id = CvForeignLangLST_Id_;
			this.CvRatingLevelLST_Id = CvRatingLevelLST_Id_;
		}
		public AdsForeignLang()
		{
			this.Id = 0;
			this.AdsMaster_Id = 0;
			this.CvForeignLangLST_Id = 0;
			this.CvRatingLevelLST_Id = 0;
		}
	}
}

