using System.ComponentModel;

namespace CrouseServiceAdvertisement.DTO
{
    public class AdsSearchEntity
    {
        [DefaultValue(-1)]
        public int id { get; set; }
        [DefaultValue(-1)]
        public int Fromdate { get; set; }
        [DefaultValue(-1)]
        public int Todate { get; set; }
        [DefaultValue(-1)]
        public int WorkCategoryId { get; set; }
        [DefaultValue("")]
        public string JobTitle { get; set; }
    }
}
