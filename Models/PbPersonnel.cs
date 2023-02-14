using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
public class PbPersonnel
		{
			[Key]
			public int Id { get; set; }
			public int PersonnelCode { get; set; }
			public bool Active { get; set; }
			public bool Blocked { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string FatherName { get; set; }
			public byte Gender { get; set; }
			public int DateOfBirth { get; set; }
			public int StartWorkDate { get; set; }
			public string NationalCode { get; set; }
			public string BirthCertificateCode { get; set; }
			public string HomeAddress { get; set; }
			public string PostalCode { get; set; }
			public string EmailAddress { get; set; }
			public string MobileNo { get; set; }
			public string InternalPhoneNo { get; set; }
			public byte EmploymentStatus { get; set; }
			public byte PbPlant_Id { get; set; }
			public int Manager_PbOrgan_Id { get; set; }
			public int PbOrgan_Id { get; set; }
			public int PbJob_Id { get; set; }
			public byte RankCode { get; set; }
			public int PbPosition_Id { get; set; }
			public byte PbShift_Id { get; set; }
			public int ManagerPersonnelCode { get; set; }
			public string EducationDegree { get; set; }
			public string BranchOfStudy { get; set; }
			public string Branch { get; set; }
			public string UniversityName { get; set; }
			public double GPA { get; set; }

			public PbPersonnel(int Id_, int PersonnelCode_, bool Active_, bool Blocked_, string FirstName_, string LastName_, string FatherName_, byte Gender_, int DateOfBirth_, int StartWorkDate_, string NationalCode_, string BirthCertificateCode_, string HomeAddress_, string PostalCode_, string EmailAddress_, string MobileNo_, string InternalPhoneNo_, byte EmploymentStatus_, byte PbPlant_Id_, int Manager_PbOrgan_Id_, int PbOrgan_Id_, int PbJob_Id_, byte RankCode_, int PbPosition_Id_, byte PbShift_Id_, int ManagerPersonnelCode_, string EducationDegree_, string BranchOfStudy_, string Branch_, string UniversityName_, double GPA_)
			{
				this.Id = Id_;
				this.PersonnelCode = PersonnelCode_;
				this.Active = Active_;
				this.Blocked = Blocked_;
				this.FirstName = FirstName_;
				this.LastName = LastName_;
				this.FatherName = FatherName_;
				this.Gender = Gender_;
				this.DateOfBirth = DateOfBirth_;
				this.StartWorkDate = StartWorkDate_;
				this.NationalCode = NationalCode_;
				this.BirthCertificateCode = BirthCertificateCode_;
				this.HomeAddress = HomeAddress_;
				this.PostalCode = PostalCode_;
				this.EmailAddress = EmailAddress_;
				this.MobileNo = MobileNo_;
				this.InternalPhoneNo = InternalPhoneNo_;
				this.EmploymentStatus = EmploymentStatus_;
				this.PbPlant_Id = PbPlant_Id_;
				this.Manager_PbOrgan_Id = Manager_PbOrgan_Id_;
				this.PbOrgan_Id = PbOrgan_Id_;
				this.PbJob_Id = PbJob_Id_;
				this.RankCode = RankCode_;
				this.PbPosition_Id = PbPosition_Id_;
				this.PbShift_Id = PbShift_Id_;
				this.ManagerPersonnelCode = ManagerPersonnelCode_;
				this.EducationDegree = EducationDegree_;
				this.BranchOfStudy = BranchOfStudy_;
				this.Branch = Branch_;
				this.UniversityName = UniversityName_;
				this.GPA = GPA_;
			}
		public PbPersonnel()
		{
			this.Id = 0;
			this.PersonnelCode = 0;
			this.Active = false;
			this.Blocked = false;
			this.FirstName = "";
			this.LastName = "";
			this.FatherName = "";
			this.Gender = 0;
			this.DateOfBirth = 0;
			this.StartWorkDate = 0;
			this.NationalCode = "";
			this.BirthCertificateCode = "";
			this.HomeAddress = "";
			this.PostalCode = "";
			this.EmailAddress = "";
			this.MobileNo = "";
			this.InternalPhoneNo = "";
			this.EmploymentStatus = 0;
			this.PbPlant_Id = 0;
			this.Manager_PbOrgan_Id = 0;
			this.PbOrgan_Id = 0;
			this.PbJob_Id = 0;
			this.RankCode = 0;
			this.PbPosition_Id = 0;
			this.PbShift_Id = 0;
			this.ManagerPersonnelCode = 0;
			this.EducationDegree = "";
			this.BranchOfStudy = "";
			this.Branch = "";
			this.UniversityName = "";
			this.GPA = 0;
		}
	}
	
}
