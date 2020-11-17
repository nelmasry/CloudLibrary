using CloudLibrary.Core.CloudEnvironment;
using CloudLibrary.Core.CloudEnvironment.AWS;
using CloudLibrary.Core.CloudEnvironment.IGS;
using CloudLibrary.Core.CloudProvider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLibrary.API
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCloudLibraryDI(this IServiceCollection services)
        {
            services.AddScoped<ICloudProviderFactory, CloudProviderFactory>();
            services.AddScoped<IIGSCloudProvider, IGSCloudProvider>();
            services.AddScoped<IAWSCloudProvider, AWSCloudProvider>();
            services.AddScoped<IIGSTest, IGSTest>();
            services.AddScoped<IIGSUAT, IGSUAT>();
            services.AddScoped<IIGSProduction, IGSProduction>();
            services.AddScoped<IAWSTest, AWSTest>();
            
            return services;
        }
    }
}
