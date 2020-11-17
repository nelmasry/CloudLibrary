using CloudLibrary.Core.CloudEnvironment;
using CloudLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLibrary.Core.CloudProvider
{
    public class AWSCloudProvider : IAWSCloudProvider
    {
        private IAWSTest _IAWSTest;
        public AWSCloudProvider(IAWSTest IAWSTest)
        {
            _IAWSTest = IAWSTest;
        }
        public ICloudEnvironment GetCloudEnvironment(CloudEnvironments environment)
        {
            switch (environment)
            {
                case CloudEnvironments.Test:
                    return _IAWSTest;
            }
            throw new Exception($"UNKNOWN Environment : {environment}");
        }
    }
}
