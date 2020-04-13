using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUtilities
    {
         string GetCustomerIP(string requestId);
         string RandomGuid();
    }
}
