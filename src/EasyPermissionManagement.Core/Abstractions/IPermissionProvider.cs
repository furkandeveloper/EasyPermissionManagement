using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Abstractions
{
    public interface IPermissionProvider
    {
        Task ApplyPermissionAsync(string key, string identifierKey);
    }
}
