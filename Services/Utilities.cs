using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Services
{
    public class Utilities : IUtilities
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Utilities(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // currentUser = _userIdentity.GetLoggedInUser();
        }

        public  string GetCustomerIP(string requestid)
        {
            //string CustomerIPs = string.Empty;
            //string[] CustomerIP1;
            //string CustomerIP = string.Empty;
            string CustomerIP = string.Empty;
           
            //first try to get IP address from the forwarded header
            if (_httpContextAccessor.HttpContext.Request.Headers != null)
            {
                //the X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a client
                //connecting to a web server through an HTTP proxy or load balancer

                var forwardedHeader = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
                if (!StringValues.IsNullOrEmpty(forwardedHeader))
                    CustomerIP = forwardedHeader.FirstOrDefault();
            }

            //if this header not exists try get connection remote IP address
            if (string.IsNullOrEmpty(CustomerIP) && _httpContextAccessor.HttpContext.Connection.RemoteIpAddress != null)
                CustomerIP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            

            return CustomerIP;
        }

        public string RandomGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
