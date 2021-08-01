using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Statics
{
    public class PermissionValue
    {
        public PermissionValue(string key, string provider)
        {
            Key = key;
            Provider = provider;
        }

        public string Key { get; }

        public string Provider { get; }
    }
}
