using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrouseServiceAdvertisement.Models
{
    public class AdsMasterDetailsOutputEntity
    {
        /// <summary>
        /// آگهی 
        /// </summary>
        public AdsOutputEntity AdsOutputEntity { get; set; }
        /// <summary>
        /// تحصیلات مورد نیاز شغل آگهی شده 
        /// </summary>
        public List<AdsEducationOutputEntity> listAdsEducationOutput { get; set; }
        /// <summary>
        /// زبان های خارجی مورد نیاز شغل آگهی شده 
        /// </summary>
        public List<AdsForeignLangOutputEntity> listForeignLangOutput { get; set; }
        /// <summary>
        /// مهارت های مورد نیاز شغل آگهی شده 
        /// </summary>
        public List<AdsSkillsOutputEntity> listAdsSkillsOutput { get; set; }
        /// <summary>
        /// مزایای شغل آگهی شده 
        /// </summary>
        public List<AdsWrkBenefitOutputEntity> listAdsWrkBenefitOutput { get; set; }
    }
}
