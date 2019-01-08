using SportsStore.WebUI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SportsStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string userName, string password)
        {
            //bool result = Membership.ValidateUser(userName, password);
#pragma warning disable CS0618 // Type or member is obsolete
            bool result = FormsAuthentication.Authenticate(userName, password);
#pragma warning restore CS0618 // Type or member is obsolete
            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName, false);
            }

            return result;
        }
    }
}