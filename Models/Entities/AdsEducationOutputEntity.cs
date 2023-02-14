using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsEducationOutputEntity
    {
		[Key]
		/// <summary>
		/// شناسه
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// کد آگهی شغلی
		/// </summary>
		public int AdsMaster_Id { get; set; }
		/// <summary>
		/// کد مقطع تحصیلی
		/// </summary>
		public short CVEduGradeLST_Id { get; set; }
		/// <summary>
		/// عنوان مقطع تحصیلی
		/// </summary>
		public string GradeTitle { get; set; }
		/// <summary>
		/// کد رشته تحصیلی
		/// </summary>
		public int CvStudyFieldLST_Id { get; set; }
		/// <summary>
		/// عنوان رشته تحصیلی
		/// </summary>
		public string FieldTitle { get; set; }

		public AdsEducationOutputEntity(int Id_, int AdsMaster_Id_, short CVEduGradeLST_Id_,string GradeTitle_, int CvStudyFieldLST_Id_, string FieldTitle_)
		{
			this.Id = Id_;
			this.AdsMaster_Id = AdsMaster_Id_;
			this.CVEduGradeLST_Id = CVEduGradeLST_Id_;
			this.GradeTitle = GradeTitle_;
			this.CvStudyFieldLST_Id = CvStudyFieldLST_Id_;
			this.FieldTitle = FieldTitle_;
		}
		public AdsEducationOutputEntity()
		{
			this.Id = 0;
			this.AdsMaster_Id = 0;
			this.CVEduGradeLST_Id = 0;
			this.GradeTitle = "";
			this.CvStudyFieldLST_Id = 0;
			this.FieldTitle = "";
		}
	}
}
