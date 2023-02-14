using System.ComponentModel.DataAnnotations;

namespace CrouseServiceAdvertisement.DTO
{
    public class AuthData
    {
        
        public bool Result { get; set; }
        [MaxLength(22)]
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Errors { get; set; }
    }
}
