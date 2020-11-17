using CloudLibrary.Core.CloudEnvironment;
using CloudLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLibrary.Core.CloudProvider
{
    public interface ICloudProvider
    {
        ICloudEnvironment GetCloudEnvironment(CloudEnvironments environment);
    }

    public interface IIGSCloudProvider : ICloudProvider
    {
    }
    public interface IAWSCloudProvider : ICloudProvider
    {
    }
}
