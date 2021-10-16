using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    /// <summary>
    /// This interface includes signature for Identifier objects
    /// </summary>
    public interface IIdentifier
    {
        /// <summary>
        /// Get Identifier key
        /// </summary>
        /// <returns>
        /// Task of string
        /// </returns>
        Task<string> GetAsync();
    }
}
