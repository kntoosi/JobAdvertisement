using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
	public class CvDiplomaSTFieldDTO
	{
		[Key]
		public short Id { get; set; }
		public string FieldTitle { get; set; }
		public bool Active { get; set; }

		public CvDiplomaSTFieldDTO(short Id_, string FieldTitle_, bool Active_)
		{
			this.Id = Id_;
			this.FieldTitle = FieldTitle_;
			this.Active = Active_;
		}
		public CvDiplomaSTFieldDTO()
		{
			this.Id = 0;
			this.FieldTitle = "";
			this.Active = false;
		}
	}
}
