using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Profile.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Infrastructure.DependencyInjection
{
  public static class ServiceCollectionExtensions
  {
    public static void AddAssemblyServices(this IServiceCollection services, string name)
    {
      var types = DependencyContext.Default.GetReferencingAssemblies(name)
        .SelectMany(a => a.GetTypes())
        .Where(t => !t.IsAbstract && t.IsClass && t.IsSealed)
        .Where(t => t.GetInterfaces().Any(i => i.Name == nameof(IServiceConfiguration)));

      foreach(var type in types)
        (Activator.CreateInstance(type) as IServiceConfiguration).Configure(services);
    }
  }
}
