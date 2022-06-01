using System;
using System.Text.Json.Serialization;

namespace ReactAdsAuthJWT.Data
{
    public class Ad
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
