namespace EasyPermissionManagement.Core.Abstractions
{
    /// <summary>
    /// Permission Defination Context
    /// </summary>
    public interface IPermissionDefinationContext
    {
        /// <summary>
        /// Define Permission
        /// </summary>
        /// <param name="key">
        /// Key of Permission
        /// </param>
        /// <param name="provider">
        /// Identifier Method
        /// </param>
        void DefinePermission(string key, string provider);
    }
}
