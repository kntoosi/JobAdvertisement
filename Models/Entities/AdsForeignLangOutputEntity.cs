using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsForeignLangOutputEntity
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
		/// کد زبان خارجی
		/// </summary>
		public short CvForeignLangLST_Id { get; set; }
		/// <summary>
		/// عنوان زبان خارجی
		/// </summary>
		public string LangTitle { get; set; }
		/// <summary>
		/// کد سطح زبان 
		/// </summary>
		public short CvRatingLevelLST_Id { get; set; }
		/// <summary>
		/// عنوان سطح زبان 
		/// </summary>
		public string LevelTitle { get; set; }

		public AdsForeignLangOutputEntity(int Id_, int AdsMaster_Id_, short CvForeignLangLST_Id_,string LangTitle_, short CvRatingLevelLST_Id_, string LevelTitle_)
		{
			this.Id = Id_;
			this.AdsMaster_Id = AdsMaster_Id_;
			this.CvForeignLangLST_Id = CvForeignLangLST_Id_;
			this.LangTitle = LangTitle_;
			this.CvRatingLevelLST_Id = CvRatingLevelLST_Id_;
			this.LevelTitle = LevelTitle_;
		}
		public AdsForeignLangOutputEntity()
		{
			this.Id = 0;
			this.AdsMaster_Id = 0;
			this.CvForeignLangLST_Id = 0;
			this.LangTitle = "";
			this.CvRatingLevelLST_Id = 0;
			this.LevelTitle = "";
		}
	}
}

