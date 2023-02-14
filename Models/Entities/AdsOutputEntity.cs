using System;
using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
	public class AdsOutputEntity
	{
		[Key]
		/// <summary>
		/// شناسه 
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// کد دسته بندی شغلی 
		/// </summary>
		public short WrkCategory_Id { get; set; }
		/// <summary>
		/// عنوان دسته بندی شغلی 
		/// </summary>
		public string WrkCategory_Title { get; set; }
		/// <summary>
		/// کد پرسنلی ایجاد کننده آگهی 
		/// </summary>
		public int PbPersonnel_Id { get; set; }
		/// <summary>
		/// نام ایجاد کننده آگهی 
		/// </summary>
		public string PbPersonnel_FirstName{ get; set; }
		/// <summary>
		/// نام خانوادگی ایجاد کننده آگهی 
		/// </summary>
		public string PbPersonnel_LastName{ get; set; }
		/// <summary>
		/// عنوان شغلی 
		/// </summary>
		public string JobTitle { get; set; }
		/// <summary>
		/// شناسه سابقه کاری  
		/// </summary>
		public short WrkHistory_Id { get; set; }
		/// <summary>
		/// عنوان سابقه کاری  
		/// </summary>
		public string WrkHistory_Title { get; set; }
		/// <summary>
		/// کد نوع همکاری 
		/// </summary>
		public short CopTyp_Id { get; set; }
		/// <summary>
		/// عنوان نوع همکاری 
		/// </summary>
		public string CopTyp_Title { get; set; }
		/// <summary>
		/// کد شیفت کاری 
		/// </summary>
		public short WrkShift_Id { get; set; }
		/// <summary>
		/// عنوان شیفت کاری 
		/// </summary>
		public string WrkShift_Title { get; set; }
		/// <summary>
		/// کد محل کار 
		/// </summary>
		public short? WrkPlace_Id { get; set; }
		/// <summary>
		/// عنوان محل کار 
		/// </summary>
		public string WrkPlace_Title { get; set; }
		/// <summary>
		/// کد جنسیت 
		/// </summary>
		public short Gender_Id { get; set; }
		/// <summary>
		/// عنوان جنسیت 
		/// </summary>
		public string Gender_Title { get; set; }
		/// <summary>
		/// کد حقوق پیشنهادی 
		/// </summary>
		public short Salary_Id { get; set; }
		/// <summary>
		/// حقوق پیشنهادی 
		/// </summary>
		public string Salary_Title { get; set; }
		/// <summary>
		/// وضعیت نظام وظیفه 
		/// </summary>
		public bool DutyStatus { get; set; }
		/// <summary>
		/// استخدام از سن 
		/// </summary>
		public byte AgeFrom { get; set; }
		/// <summary>
		/// استخدام تا سن 
		/// </summary>
		public byte AgeTo { get; set; }
		/// <summary>
		/// توضیحات شغل 
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// امکان استخدام فرد معلول 
		/// </summary>
		public bool PhysicalDisability { get; set; }
		/// <summary>
		/// تاریخ شمسی انقضای آگهی 
		/// </summary>
		public int ExpirationDateSh { get; set; }
		/// <summary>
		/// زمان و تاریخ میلادی انقضای آگهی 
		/// </summary>
		public DateTime ExpirationTimeM { get; set; }
		/// <summary>
		/// تاریخ شمسی ایجاد آگهی 
		/// </summary>
		public int DocDate { get; set; }
		/// <summary>
		/// ساعت ایجاد آگهی 
		/// </summary>
		public string DocTime { get; set; }
		/// <summary>
		/// لاگ کامل تاریخ 
		/// </summary>
		public DateTime LogDateTime { get; set; }
		/// <summary>
		/// کد پرسنلی فرد تایید کننده آگهی 
		/// </summary>
		public int? PbPersonnel_Id2 { get; set; }
		/// <summary>
		/// نام پرسنلی فرد تایید کننده آگهی 
		/// </summary>
		public string PbPersonnel_FirstName2 { get; set; }
		/// <summary>
		/// نام خانوادگی پرسنلی فرد تایید کننده آگهی 
		/// </summary>
		public string PbPersonnel_LastName2 { get; set; }
		/// <summary>
		/// تاریخ شمسی تایید آگهی 
		/// </summary>
		public int? ConfirmDate { get; set; }
		/// <summary>
		/// ساعت تایید آگهی 
		/// </summary>
		public string ConfirmTime { get; set; }
		/// <summary>
		/// توضیحات تایید آگهی 
		/// </summary>
		public string ConfirmDesc { get; set; }
		/// <summary>
		/// کد وضعیت تایید آگهی 
		/// </summary>
		public short AdsStateLST_Id { get; set; }
		/// <summary>
		/// عنوان وضعیت تایید آگهی 
		/// </summary>
		public string AdsStateLST_Title { get; set; }
		/// <summary>
		/// وضعیت 
		/// </summary>
		public bool Active { get; set; }
		/// <summary>
		/// کد جدول رده شغلی 
		/// </summary>
		public short AdsJobPositionLST_Id { get; set; }
		/// <summary>
		/// عنوان جدول رده شغلی 
		/// </summary>
		public string AdsJobPositionLST_Title { get; set; }
	

		public AdsOutputEntity(int Id_, short WrkCategory_Id_, string WrkCategory_Title_, int PbPersonnel_Id_, string PbPersonnel_FirstName_, string PbPersonnel_LastName_, string JobTitle_, short WrkHistory_Id_, string WrkHistory_Title_, short CopTyp_Id_, string CopTyp_Title_, short WrkShift_Id_, string WrkShift_Title_, short WrkPlace_Id_, string WrkPlace_Title_, short Gender_Id_, string Gender_Title_, short Salary_Id_, string Salary_Title_, bool DutyStatus_, byte AgeFrom_, byte AgeTo_, string Description_, bool PhysicalDisability_, int ExpirationDateSh_, DateTime ExpirationTimeM_, int DocDate_, string DocTime_, DateTime LogDateTime_, int PbPersonnel_Id2_, string PbPersonnel_FirstName2_, string PbPersonnel_LastName2_, int ConfirmDate_, string ConfirmTime_, string ConfirmDesc_, short AdsStateLST_Id_, string AdsStateLST_Title_, bool Active_, short AdsJobPositionLST_Id_, string AdsJobPositionLST_Title_)
		{
			this.Id = Id_;
			this.WrkCategory_Id = WrkCategory_Id_;
			this.WrkCategory_Title = WrkCategory_Title_;
			this.PbPersonnel_Id = PbPersonnel_Id_;
			this.PbPersonnel_FirstName = PbPersonnel_FirstName_;
			this.PbPersonnel_LastName = PbPersonnel_LastName_;
			this.JobTitle = JobTitle_;
			this.WrkHistory_Id = WrkHistory_Id_;
			this.WrkHistory_Title = WrkHistory_Title_;
			this.CopTyp_Id = CopTyp_Id_;
			this.CopTyp_Title = CopTyp_Title_;
			this.WrkShift_Id = WrkShift_Id_;
			this.WrkShift_Title = WrkShift_Title_;
			this.WrkPlace_Id = WrkPlace_Id_;
			this.WrkPlace_Title = WrkPlace_Title_;
			this.Gender_Id = Gender_Id_;
			this.Gender_Title = Gender_Title_;
			this.Salary_Id = Salary_Id_;
			this.Salary_Title = Salary_Title_;
			this.DutyStatus = DutyStatus_;
			this.AgeFrom = AgeFrom_;
			this.AgeTo = AgeTo_;
			this.Description = Description_;
			this.PhysicalDisability = PhysicalDisability_;
			this.ExpirationDateSh = ExpirationDateSh_;
			this.ExpirationTimeM = ExpirationTimeM_;
			this.DocDate = DocDate_;
			this.DocTime = DocTime_;
			this.LogDateTime = LogDateTime_;
			this.PbPersonnel_Id2 = PbPersonnel_Id2_;
			this.PbPersonnel_FirstName2 = PbPersonnel_FirstName2_;
			this.PbPersonnel_LastName2 = PbPersonnel_LastName2;
			this.ConfirmDate = ConfirmDate_;
			this.ConfirmTime = ConfirmTime_;
			this.ConfirmDesc = ConfirmDesc_;
			this.AdsStateLST_Id = AdsStateLST_Id_;
			this.AdsStateLST_Title = AdsStateLST_Title_;
			this.Active = Active_;
			this.AdsJobPositionLST_Id = AdsJobPositionLST_Id_;
			this.AdsJobPositionLST_Title = AdsJobPositionLST_Title_;
		}
		public AdsOutputEntity()
		{
			this.Id = 0;
			this.WrkCategory_Id = 0;
			this.WrkCategory_Title = "";
			this.PbPersonnel_Id = 0;
			this.PbPersonnel_FirstName = "";
			this.PbPersonnel_LastName = "";
			this.JobTitle = "";
			this.WrkHistory_Id = 0;
			this.WrkHistory_Title = "";
			this.CopTyp_Id = 0;
			this.CopTyp_Title = "";
			this.WrkShift_Id = 0;
			this.WrkShift_Title = "";
			this.WrkPlace_Id = null;
			this.WrkPlace_Title = "";
			this.Gender_Id = 0;
			this.Gender_Title = "";
			this.Salary_Id = 0;
			this.Salary_Title = "";
			this.DutyStatus = false;
			this.AgeFrom = 0;
			this.AgeTo = 0;
			this.Description = "";
			this.PhysicalDisability = false;
			this.ExpirationDateSh = 0;
			this.ExpirationTimeM = DateTime.MinValue;
			this.DocDate = 0;
			this.DocTime = "";
			this.LogDateTime = DateTime.MinValue;
			this.PbPersonnel_Id2 = null;
			this.PbPersonnel_FirstName2 = "";
			this.PbPersonnel_LastName2 = "";
			this.ConfirmDate = null;
			this.ConfirmTime = "";
			this.ConfirmDesc = "";
			this.AdsStateLST_Id = 0;
			this.AdsStateLST_Title = "";
			this.Active = false;
			this.AdsJobPositionLST_Id  = 0;
			this.AdsJobPositionLST_Title  = "";
		}
	}
}
