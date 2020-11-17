using CloudLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLibrary.Core.CloudProvider
{
    public interface ICloudProviderFactory
    {
        ICloudProvider GetAbstractCloudProvider(Enum.CloudProvider provider);
    }
    public class CloudProviderFactory : ICloudProviderFactory
    {
        private IIGSCloudProvider _IGSCloudProvider;
        private IAWSCloudProvider _AWSCloudProvider;
        public CloudProviderFactory(IIGSCloudProvider IGSCloudProvider,
                                IAWSCloudProvider AWSCloudProvider)
        {
            _IGSCloudProvider = IGSCloudProvider;
            _AWSCloudProvider = AWSCloudProvider;
        }

        public ICloudProvider GetAbstractCloudProvider(Enum.CloudProvider provider)
        {
            switch (provider)
            {
                case Enum.CloudProvider.IGS:
                    return _IGSCloudProvider;
                case Enum.CloudProvider.AWS:
                    return _AWSCloudProvider;
            }
            throw new KeyNotFoundException($"Unknown Provider : {provider}");
        }
    }
}
