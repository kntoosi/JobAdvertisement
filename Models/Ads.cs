using System;
using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement
{
    public class Ads
    {
		[Key]
		public int Id { get; set; }
		public short WrkCategory_Id { get; set; }
		public int PbPersonnel_Id { get; set; }
		public string JobTitle { get; set; }
		public short WrkHistory_Id { get; set; }
		public short CopTyp_Id { get; set; }
		public short WrkShift_Id { get; set; }
		public short? WrkPlace_Id { get; set; }
		public short Gender_Id { get; set; }
		public short Salary_Id { get; set; }
		public bool DutyStatus { get; set; }
		public byte AgeFrom { get; set; }
		public byte AgeTo { get; set; }
		public string Description { get; set; }
		public bool PhysicalDisability { get; set; }
		public int ExpirationDateSh { get; set; }
		public DateTime ExpirationTimeM { get; set; }
		public int DocDate { get; set; }
		public string DocTime { get; set; }
		public DateTime LogDateTime { get; set; }
		public int? PbPersonnel_Id2 { get; set; }
		public int? ConfirmDate { get; set; }
		public string ConfirmTime { get; set; }
		public string ConfirmDesc { get; set; }
		public short AdsStateLST_Id { get; set; }
		public bool Active { get; set; }
		public short AdsJobPositionLST_Id { get; set; }

		public Ads(int Id_, short WrkCategory_Id_, int PbPersonnel_Id_, string JobTitle_, short WrkHistory_Id_, short CopTyp_Id_, short WrkShift_Id_, short WrkPlace_Id_, short Gender_Id_, short Salary_Id_, bool DutyStatus_, byte AgeFrom_, byte AgeTo_, string Description_, bool PhysicalDisability_, int ExpirationDateSh_, DateTime ExpirationTimeM_, int DocDate_, string DocTime_, DateTime LogDateTime_, int PbPersonnel_Id2_, int ConfirmDate_, string ConfirmTime_, string ConfirmDesc_, short AdsStateLST_Id_, bool Active_, short AdsJobPositionLST_Id_)
		{
			this.Id = Id_;
			this.WrkCategory_Id = WrkCategory_Id_;
			this.PbPersonnel_Id = PbPersonnel_Id_;
			this.JobTitle = JobTitle_;
			this.WrkHistory_Id = WrkHistory_Id_;
			this.CopTyp_Id = CopTyp_Id_;
			this.WrkShift_Id = WrkShift_Id_;
			this.WrkPlace_Id = WrkPlace_Id_;
			this.Gender_Id = Gender_Id_;
			this.Salary_Id = Salary_Id_;
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
			this.ConfirmDate = ConfirmDate_;
			this.ConfirmTime = ConfirmTime_;
			this.ConfirmDesc = ConfirmDesc_;
			this.AdsStateLST_Id = AdsStateLST_Id_;
			this.Active = Active_;
			this.AdsJobPositionLST_Id = AdsJobPositionLST_Id_;
		}
		public Ads()
		{
			this.Id = 0;
			this.WrkCategory_Id = 0;
			this.PbPersonnel_Id = 0;
			this.JobTitle = "";
			this.WrkHistory_Id = 0;
			this.CopTyp_Id = 0;
			this.WrkShift_Id = 0;
			this.WrkPlace_Id = null;
			this.Gender_Id = 0;
			this.Salary_Id = 0;
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
			this.ConfirmDate = null;
			this.ConfirmTime = "";
			this.ConfirmDesc = "";
			this.AdsStateLST_Id = 0;
			this.Active = false;
			this.AdsJobPositionLST_Id = 0;
		}
	}
}
