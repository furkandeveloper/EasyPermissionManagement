using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Attributes
{
    /// <summary>
    /// Registeriation Attribute for Identifier objects
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RegisterIdentifierAttribute : Attribute
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="provider">
        /// Check Provider For Example; Organization, User etc.
        /// </param>
        public RegisterIdentifierAttribute(string provider)
        {
            Provider = provider;
        }

        /// <summary>
        /// Identifier Method
        /// </summary>
        public string Provider { get; }
    }
}
