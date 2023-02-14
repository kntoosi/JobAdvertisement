using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.Models
{
    public class CvForeignLangLST
    {
		[Key]
		public short Id { get; set; }
        public string LangTitle { get; set; }
        public bool Active { get; set; }
		public CvForeignLangLST(short Id_, string LangTitle_, bool Active_)
		{
			this.Id = Id_;
			this.LangTitle = LangTitle_;
			this.Active = Active_;
		}
		public CvForeignLangLST()
		{
			this.Id = 0;
			this.LangTitle = "";
			this.Active = false;
		}

	}
}
