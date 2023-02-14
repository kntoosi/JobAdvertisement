namespace CrouseServiceAdvertisement.DTO
{
    public class AdsMasterDetailsEditEntity
    {
        public int Id { get; set; }
        public AdsMasterDetailsInputEntity adsMasterDetailsInputEntity { get; set; }
        public AdsMasterDetailsEditEntity(int Id_, AdsMasterDetailsInputEntity adsMasterDetailsInputEntity_)
        {
            this.Id = Id_;
            this.adsMasterDetailsInputEntity = adsMasterDetailsInputEntity_;

        }
        public AdsMasterDetailsEditEntity()
        {
            this.Id = 0;
            this.adsMasterDetailsInputEntity = new AdsMasterDetailsInputEntity();

        }
    }
}
