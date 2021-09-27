using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Statics
{
    public class PermissionValue
    {
        public PermissionValue(string key, string provider, bool isDefault)
        {
            Key = key;
            Provider = provider;
            IsDefault = isDefault;
        }

        public string Key { get; }

        public string Provider { get; }
        public bool IsDefault { get; }
    }
}
