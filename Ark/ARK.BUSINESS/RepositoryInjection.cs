using ARK.CORE.Common;
using ARK.CORE.Data;
using ARK.DATA.Patterns;
using ARK.RADIUS.Patterns;
using ARK.SERVICES.Service;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ARK.BUSINESS
{
    public class RepositoryInjection
    {
        public static void Register(IServiceCollection services)
        {
            RegisterBusinesses(services);
            RegisterServices(services);            
            //RegisterRepositories(services);
        }

        //private static void RegisterRepositories(IServiceCollection services)
        //{
        //    var repositoryTypes = TypeHelper.GetInstancesOfImplementingTypesOnly<IRepository>()
        //      .Where(x => !x.ContainsGenericParameters).ToList();

        //    foreach (var interface1 in repositoryTypes.Where(x => x.Name.EndsWith("Repository") && x.IsInterface))
        //    {
        //        var asd = new string(interface1.Name.Skip(1).ToArray());
        //        var matchingImplementationType =
        //          repositoryTypes.SingleOrDefault(x => x.Name == asd);
        //        if (matchingImplementationType != null) services.AddTransient(interface1, matchingImplementationType);
        //    }
        //}

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(RadiusRepository<>));

            var serviceTypes = TypeHelper.GetInstancesOfImplementingTypesOnly<IService>()
              .Where(x => !x.ContainsGenericParameters).ToList();

            foreach (var interface1 in serviceTypes.Where(x => x.Name.EndsWith("Service") && x.IsInterface))
            {
                var matchingImplementationType =
                  serviceTypes.SingleOrDefault(x => x.Name == new string(interface1.Name.Skip(1).ToArray()));
                if (matchingImplementationType != null) services.AddTransient(interface1, matchingImplementationType);
            }
        }

        private static void RegisterBusinesses(IServiceCollection services)
        {
            var businessesTypes = TypeHelper.GetInstancesOfImplementingTypesOnly<IBusiness>()
              .Where(x => !x.ContainsGenericParameters).ToList();

            foreach (var interface1 in businessesTypes.Where(x => x.Name.EndsWith("Business") && x.IsInterface))
            {
                var matchingImplementationType =
                  businessesTypes.SingleOrDefault(x => x.Name == new string(interface1.Name.Skip(1).ToArray()));
                if (matchingImplementationType != null) services.AddTransient(interface1, matchingImplementationType);
            }
        }
    }
}
