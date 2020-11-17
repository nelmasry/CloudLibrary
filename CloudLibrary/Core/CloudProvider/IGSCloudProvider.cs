using CloudLibrary.Core.CloudEnvironment;
using CloudLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLibrary.Core.CloudProvider
{
    public class IGSCloudProvider : IIGSCloudProvider
    {
        private IIGSTest _IIGSTest;
        private IIGSUAT _IIGSUAT;
        private IIGSProduction _IIGSProduction;
        public IGSCloudProvider(IIGSTest IIGSTest, IIGSUAT IIGSUAT, IIGSProduction IIGSProduction)
        {
            _IIGSTest = IIGSTest;
            _IIGSUAT = IIGSUAT;
            _IIGSProduction = IIGSProduction;
        }
        public ICloudEnvironment GetCloudEnvironment(CloudEnvironments environment)
        {
            switch (environment)
            {
                case CloudEnvironments.Test:
                    return _IIGSTest;
                case CloudEnvironments.UAT:
                    return _IIGSUAT;
                case CloudEnvironments.Production:
                    return _IIGSProduction;
            }
            throw new Exception($"Unknown Environment : {environment}");
        }
    }
}
