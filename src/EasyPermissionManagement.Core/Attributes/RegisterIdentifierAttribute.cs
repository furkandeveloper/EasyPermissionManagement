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
        public RegisterIdentifierAttribute(string provider)
        {
            Provider = provider;
        }

        public string Provider { get; }
    }
}
