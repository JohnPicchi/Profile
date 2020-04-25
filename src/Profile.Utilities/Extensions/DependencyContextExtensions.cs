using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Profile.Utilities.Extensions
{
  public static class DependencyContextExtensions
  {
    public static IEnumerable<Assembly> GetReferencingAssemblies(this DependencyContext context, string name)
    {
      return context.RuntimeLibraries
        .Where(l => l.Name == name || l.Dependencies.Any(d => d.Name.StartsWith(name)))
        .Select(l => Assembly.Load(new AssemblyName(l.Name)))
        .ToList();
    }
  }
}
