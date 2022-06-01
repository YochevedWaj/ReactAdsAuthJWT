using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactAdsAuthJWT.Data
{
    public class AdsRepository
    {
        private string _connectionString { get; set; }
        public AdsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Ad> GetAds()
        {
            using var ctx = new AdsDataContext(_connectionString);
            return ctx.Ads.Include(a => a.User).OrderByDescending(a => a.Date).ToList();
        }
        public void AddAd(Ad ad)
        {
            using var ctx = new AdsDataContext(_connectionString);
            ctx.Ads.Add(ad);
            ctx.SaveChanges();
        }

        public void DeleteAd(int id)
        {
            using var ctx = new AdsDataContext(_connectionString);
            ctx.Database.ExecuteSqlInterpolated($"DELETE FROM Ads WHERE ID = {id}");
        }

        public User GetByEmail(string email)
        {
            using var ctx = new AdsDataContext(_connectionString);
            return ctx.Users.Include(u => u.Ads).FirstOrDefault(u => u.Email == email);
        }

        public List<Ad> GetMyAds(string email)
        {
            using var ctx = new AdsDataContext(_connectionString);
            return ctx.Ads.Include(a => a.User).Where(a => a.User.Email == email).ToList();
        }

        public bool IsMyAd(string email, int id)
        {
            return GetMyAds(email).Any(a => a.ID == id);
        }
    }
}
