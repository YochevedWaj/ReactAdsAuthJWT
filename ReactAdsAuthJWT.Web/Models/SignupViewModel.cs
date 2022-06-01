using ReactAdsAuthJWT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAdsAuthJWT.Web.Models
{
    public class SignupViewModel : User
    {
        public string Password { get; set; }
    }
}
