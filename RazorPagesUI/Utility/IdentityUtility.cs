using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RazorPagesUI.Utility
{
    public static class IdentityUtility
    {
        /// <summary>
        /// Returns the user Id of the current user.
        /// </summary>
        /// <param name="claimsIdentity">ClaimsItentity passed in by the client.</param>
        /// <returns>user id as a string.</returns>
        public static string GetUserId(ClaimsIdentity claimsIdentity)
        {
            return claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
