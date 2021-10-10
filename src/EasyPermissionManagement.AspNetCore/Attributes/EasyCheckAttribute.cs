﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EasyPermissionManagement.Core.Extensions;
using EasyPermissionManagement.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EasyPermissionManagement.AspNetCore.Attributes
{
    public class EasyCheckAttribute : ActionFilterAttribute
    {
        public EasyCheckAttribute(string key, string provider)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));
            }

            if (string.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentException($"'{nameof(provider)}' cannot be null or whitespace.", nameof(provider));
            }

            Key = key;
            Provider = provider;
        }

        public string Key { get; }
        public string Provider { get; }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceProvider = context.HttpContext.RequestServices.GetService<IServiceProvider>();
            var provider = serviceProvider.FindIdentifier(this.Provider);
            string identifierKey = await provider.GetAsync(this.Provider);
            var permissionChecker = context.HttpContext.RequestServices.GetService<IPermissionChecker>();
            bool isCheck = await permissionChecker.CheckAsync(permissionKey: this.Key, provider: this.Provider, identifierKey: identifierKey);
            if (!isCheck)
            {
                context.Result = new ObjectResult(context.ModelState)
                {
                    Value = $"{this.Key} Permission Required!!",
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
            await base.OnActionExecutionAsync(context, next);
        }
    }
}
