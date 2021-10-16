using EasyPermissionManagement.AspNetCore.Attributes;
using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Attributes;
using EasyPermissionManagement.Core.Statics;
using EasyPermissionManagement.Web.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Web.Controllers
{
    /// <summary>
    /// Identifier Permission Endpoints
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class IdentifierPermissionController : ControllerBase
    {
        private readonly IPermissionProvider permissionProvider;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="permissionProvider">
        /// Assign or remove permissions to your data.
        /// </param>
        public IdentifierPermissionController(IPermissionProvider permissionProvider)
        {
            this.permissionProvider = permissionProvider;
        }

        /// <summary>
        /// Apply Permission
        /// </summary>
        /// <param name="dto">
        /// Define Permission Request Data Transfer Object
        /// </param>
        /// <returns>
        /// Status Code : 200
        /// </returns>
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyPermissionAsync([FromBody] DefinePermissionRequestDto dto)
        {
            await permissionProvider.ApplyPermissionAsync(key: dto.PermissionKey, provider: dto.Provider, identifierKey: dto.IdentifierKey);
            return Ok("SUCCESS");
        }

        /// <summary>
        /// Get All Permissions
        /// </summary>
        /// <returns>
        /// List of Permission
        /// </returns>
        [HttpGet("permissions")]
        public IActionResult GetAllPermisionsAsync()
        {
            return Ok(PermissionValues.Permissions.Select(s => new
            {
                Key = s.Key,
                Provider = s.Provider
            }).ToList());
        }

        /// <summary>
        /// Authorize Check For User Identifier Endpoint
        /// </summary>
        /// <remarks>
        /// The authorization status of the id information coming over the route will be determined by the User Identifier method.
        /// This endpoint will check lead.read permission with User Identifier method.
        /// </remarks>
        /// <returns></returns>
        [HttpGet("users/{id}/authorize")]
        [EasyCheck("lead.read", "User")]
        public IActionResult AuthorizeCheck([FromRoute] string id)
        {
            return Ok("Authorize ✅ : " + id);
        }

        /// <summary>
        /// Fail Authorize Check For User Identifier Endpoint
        /// </summary>
        /// <remarks>
        /// The authorization status of the id information coming over the route will be determined by the User Identifier method.
        /// This endpoint will check lead.read permission with User Identifier method.
        /// </remarks>
        /// <returns></returns>
        [HttpGet("users/a3104996-a99d-4d59-a929-62de1a9b1672/fail-authorize")]
        [EasyCheck("lead.read", "User")]
        public IActionResult FailAuthorizeCheck([FromRoute] string id)
        {
            return Ok("Authorize ✅ : " + id);
        }
    }
}
