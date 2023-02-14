using CrouseServiceAdvertisement.Models;
using System.Collections.Generic;

namespace CrouseServiceAdvertisement.DTO
{
    public class AdsMasterDetailsInputEntity
    {
        public AdsInputEntity adsInput { get; set; }
        public List<AdsEducationInputEntity> listAdsEducationInput { get; set; }
        public List<AdsForeignLangInputEntity> listForeignLangInput { get; set; }
        public List<AdsSkillsInputEntity> listAdsSkillsInput { get; set; }
        public List<AdsWrkBenefitInputEntity> listAdsWrkBenefitInput { get; set; }
    }
}
