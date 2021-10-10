namespace EasyPermissionManagement.Core.Abstractions
{
    public interface IPermissionDefinationContext
    {
        void DefinePermission(string key, string provider, bool isDefault = false);
    }
}
