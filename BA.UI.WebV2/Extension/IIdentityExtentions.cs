using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Extension
{
    public static class IIdentityExtentions
    {
        public static object CustomClaimTypes { get; private set; }

        public static int GetEmployeeId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("EmployeeId");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }

        public static int GetEmployeeNumber(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("EmployeeNumber");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }

        public static int GetDepartmentId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("DepartmentId");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }

        public static int GetDivisionId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("DivisionId");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }

        public static int GetDesignationId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("DesignationId");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }

        public static string GetIpAddress(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("IPAddress");

            if (claim == null)
                return null;

            return claim.Value;
        }

        public static string GetStationName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("StationName");

            if (claim == null)
                return null;

            return claim.Value;
        }

        public static int GetStationId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("StationId");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }
    }
}
