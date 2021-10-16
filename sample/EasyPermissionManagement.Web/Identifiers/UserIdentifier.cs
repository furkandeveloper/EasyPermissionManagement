using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Web.Identifiers
{
    /// <summary>
    /// User Identifier Method
    /// </summary>
    [RegisterIdentifier(PROVIDER)]
    public class UserIdentifier : IIdentifier
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpContextAccessor">
        /// Provides access to the current Microsoft.AspNetCore.Http.IHttpContextAccessor.HttpContext,
        /// if one is available.
        /// </param>
        public UserIdentifier(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Provider name
        /// </summary>
        public const string PROVIDER = "User";
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Find Identifier Key
        /// </summary>
        /// <returns>
        /// Task of String
        /// </returns>
        public Task<string> GetAsync()
        {
            string id = httpContextAccessor.HttpContext.Request.RouteValues["id"]?.ToString();
            return Task.FromResult(id);
        }
    }
}
