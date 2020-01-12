using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtizmWeb
{
    public class WebCommon : ICommon
    {

        public string GetCurrentUsername()
        {
            if (HttpContext.Current.Session["login"] != null)
            {
                User user = HttpContext.Current.Session["login"] as User;
                return user.TCKN;
            }
            return null;
        }
    }
}