using EasyPermissionManagement.AspNetCore.Attributes;
using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Attributes;
using EasyPermissionManagement.Core.Statics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentifierPermissionController : ControllerBase
    {
        private readonly IPermissionProvider permissionProvider;

        public IdentifierPermissionController(IPermissionProvider permissionProvider)
        {
            this.permissionProvider = permissionProvider;
        }

        [HttpGet("apply")]
        public async Task<IActionResult> ApplyPermissionAsync([FromQuery] string permissionKey, 
            [FromQuery]string provider, [FromQuery]string identifierKey)
        {
            await permissionProvider.ApplyPermissionAsync(key: permissionKey, provider: provider, identifierKey: identifierKey);
            return Ok("SUCCESS");
        }

        [HttpGet("permissions")]
        public async Task<IActionResult> GetAllPermisionsAsync()
        {
            return Ok(PermissionValues.Permissions.Select(s=> new
            {
                Key = s.Key,
                Provider = s.Provider
            }).ToList());
        }

        [HttpGet("authorize")]
        [EasyCheck("lead.create","User")]
        public async Task<IActionResult> AuthorizeCheckAsync()
        {
            return Ok("Authorize");
        }
    }
}
