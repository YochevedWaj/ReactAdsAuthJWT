using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactAdsAuthJWT.Data;
using Microsoft.Extensions.Configuration;
using ReactAdsAuthJWT.Web.Models;

namespace ReactAdsAuthJWT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private string _connectionString;
        public AdsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpGet]
        [Route("getads")]
        public List<AdViewModel> GetAds()
        {
            var repo = new AdsRepository(_connectionString);
            var email = User.FindFirst("user")?.Value;
            return repo.GetAds().Select(a => {
                return new AdViewModel
                {
                    Ad = a,
                    CanDelete = a.User.Email == email,
                    UserName = $"{a.User.FirstName} {a.User.LastName}"
                };
            }).ToList();

        }

        [Authorize]
        [HttpPost]
        [Route("newad")]
        public void AddAd(Ad ad)
        {
            var accountRepo = new AccountRepository(_connectionString);
            string email = User.FindFirst("user").Value;
            var user = accountRepo.GetByEmail(email);
            ad.UserID = user.ID;
            ad.Date = DateTime.Now;
            var adsRepo = new AdsRepository(_connectionString);
            adsRepo.AddAd(ad);

        }

        [Authorize]
        [HttpGet]
        [Route("getmyads")]
        public List<Ad> GetMyAds()
        {
            string email = User.FindFirst("user").Value;
            var repo = new AdsRepository(_connectionString);
            return repo.GetMyAds(email);

        }

        [Authorize]
        [HttpPost]
        [Route("deletead")]
        public void DeleteAd(Ad ad)
        {
            var repo = new AdsRepository(_connectionString);
            string email = User.FindFirst("user").Value;
            if(!repo.IsMyAd(email, ad.ID))
            {
                return;
            }
            repo.DeleteAd(ad.ID);

        }

    }
}
