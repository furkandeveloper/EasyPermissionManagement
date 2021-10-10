using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    public interface IPermissionProvider
    {
        Task ApplyPermissionAsync(string key, string provider, string identifierKey);

        Task RemovePermissionAsync(string key, string provider, string identifierKey);
    }
}
