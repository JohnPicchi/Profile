using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.Infrastructure.DependencyInjection
{
  public interface IServiceConfiguration
  {
    void Configure(IServiceCollection services);
  }
}
