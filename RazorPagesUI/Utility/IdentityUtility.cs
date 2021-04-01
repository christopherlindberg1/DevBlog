using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RazorPagesUI.Utility
{
    public static class IdentityUtility
    {
        public static string GetUserId(ClaimsIdentity claimsIdentity)
        {
            return claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
