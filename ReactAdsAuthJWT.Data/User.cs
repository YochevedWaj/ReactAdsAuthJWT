using System.Collections.Generic;

namespace ReactAdsAuthJWT.Data
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<Ad> Ads { get; set; }
    }
}
