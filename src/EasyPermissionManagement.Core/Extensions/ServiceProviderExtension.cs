using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.Core.Extensions
{
    /// <summary>
    /// Service Provider Extension
    /// </summary>
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// Find Identifier by provider
        /// </summary>
        /// <param name="serviceProvider">
        ///  Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </param>
        /// <param name="provider">
        /// Identifier provider
        /// </param>
        /// <returns>
        /// IIdentifier object
        /// </returns>
        public static IIdentifier FindIdentifier(this IServiceProvider serviceProvider, string provider)
        {
            if (string.IsNullOrEmpty(provider))
            {
                throw new ArgumentException($"'{nameof(provider)}' cannot be null or empty.", nameof(provider));
            }

            var type = typeof(IIdentifier);

            var service = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .Where(c => c.GetCustomAttribute<RegisterIdentifierAttribute>().Provider == provider)
                .FirstOrDefault();

            if (service is null)
                throw new NotImplementedException("Service not implemented exception. Service : " + provider);

            var ctors = service.GetConstructors().FirstOrDefault();
            var parameters = ctors.GetParameters();
            List<object> ctorServices = new List<object>();
            foreach (var parameter in parameters)
            {
                var findedService = serviceProvider.GetService(parameter.ParameterType);
                ctorServices.Add(findedService);
            }

            var activator = (IIdentifier)Activator.CreateInstance(service, args: ctorServices.ToArray());
            return activator;
        }
    }
}
