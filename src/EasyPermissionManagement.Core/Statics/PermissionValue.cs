using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Statics
{
    /// <summary>
    /// Permission
    /// </summary>
    public class PermissionValue
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="key">
        /// Key of Permission
        /// </param>
        /// <param name="provider">
        /// Identifier Method
        /// </param>
        public PermissionValue(string key, string provider)
        {
            Key = key;
            Provider = provider;
        }

        /// <summary>
        /// Key of Permission
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Identifier Method
        /// </summary>
        public string Provider { get; }
    }
}
