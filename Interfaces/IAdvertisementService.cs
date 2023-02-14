using CrouseServiceAdvertisement.DTO;
using CrouseServiceAdvertisement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrouseServiceAdvertisement.Services
{
    public interface IAdvertisementService
    {
        //public Task<List<AdsOutputEntity>> GetAds(AdsSearchEntity adsSearchEntity);
        public List<AdsOutputEntity> GetAds(AdsSearchEntity adsSearchEntity, int role, int PrsNo);
        public List<AdsMasterDetailsOutputEntity> GetNotExpiredAds(AdsSearchEntity adsSearchEntity);
        public List<AdsOutputEntity> GetConfirmedAds(AdsSearchEntity adsSearchEntity);
        public AdsMasterDetailsOutputEntity GetAdsDetails(int AdsID, int role, int PrsNo);
        public AdsMasterDetailsOutputEntity GetAdsDetailsWithoutAuth(int AdsID);
        public int AddAds(AdsMasterDetailsInputEntity adsMasterDetails, int PrsNo);
        public int EditAds(AdsMasterDetailsEditEntity adsMasterDetailsEditEntity, int PrsNo);
        public int ConfirmAds(AdsConfirmInputEntity adsConfirmInputEntity, int PrsNo);
    }
}
