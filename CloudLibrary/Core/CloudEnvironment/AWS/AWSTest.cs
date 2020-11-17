using CloudLibrary.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLibrary.Core.CloudEnvironment.AWS
{
    public class AWSTest : IAWSTest
    {
        public bool CreateDatabaseServer(DatabaseServerTypes databaseServerType)
        {
            throw new NotImplementedException();
        }

        public bool CreateVirtualMachine(VirtualMachineTypes virtualMachineType)
        {
            throw new NotImplementedException();
        }
        public bool DeleteInfrastructure()
        {
            throw new NotImplementedException();
        }
    }
}
