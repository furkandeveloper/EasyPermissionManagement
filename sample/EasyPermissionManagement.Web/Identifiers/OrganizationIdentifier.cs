using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Web.Identifiers
{
    /// <summary>
    /// Organization Identifier
    /// </summary>
    [RegisterIdentifier(PROVIDER)]
    public class OrganizationIdentifier : IIdentifier
    {        
        /// <summary>
        /// Const Provider
        /// </summary>
        public const string PROVIDER = "Organization";

        /// <summary>
        /// Get Identifier Key
        /// </summary>
        /// <returns>
        /// Task of String
        /// </returns>
        public Task<string> GetAsync()
        {
            return Task.FromResult(GetFakeOrganizationName());
        }

        /// <summary>
        /// Fake Organization Finder
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        private string GetFakeOrganizationName()
        {
            // From Database
            return "Organization 1";
        }
    }
}
