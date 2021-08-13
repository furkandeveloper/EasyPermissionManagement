﻿using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Web.Identifiers
{
    [RegisterIdentifier(PROVIDER)]
    public class UserIdentifier : IIdentifier
    {
        public const string PROVIDER = "user";
        public Task<string> GetAsync(string provider)
        {
            return Task.FromResult("4");
        }
    }
}