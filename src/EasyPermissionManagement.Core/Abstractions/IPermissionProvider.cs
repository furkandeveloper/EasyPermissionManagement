using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    /// <summary>
    /// Assign or remove permissions to your data.
    /// </summary>
    public interface IPermissionProvider
    {
        /// <summary>
        /// Apply Permission
        /// </summary>
        /// <param name="key">
        /// Key of Permission
        /// </param>
        /// <param name="provider">
        /// Identifier Method
        /// </param>
        /// <param name="identifierKey">
        /// The value to be identified.
        /// </param>
        Task ApplyPermissionAsync(string key, string provider, string identifierKey);

        /// <summary>
        /// Remove Permission
        /// </summary>
        /// <param name="key">
        /// Key of Permission
        /// </param>
        /// <param name="provider">
        /// Identifier Method
        /// </param>
        /// <param name="identifierKey">
        /// The value to be identified.
        /// </param>
        Task RemovePermissionAsync(string key, string provider, string identifierKey);
    }
}
