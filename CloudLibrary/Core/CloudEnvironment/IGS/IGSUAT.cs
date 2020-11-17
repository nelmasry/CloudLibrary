using CloudLibrary.Core.Enum;
using System;
using System.Collections.Generic;

namespace CloudLibrary.Core.CloudEnvironment.IGS
{
    public class IGSUAT : IIGSUAT
    {
        static string InfraPath = $"/{Enum.CloudProvider.IGS}/{CloudEnvironments.UAT}/";
        static string VMPath = Shared.GetVMPath(InfraPath);
        static string DBServerPath = Shared.GetDBServerPath(InfraPath);
        static CloudEnvironments Environment = CloudEnvironments.UAT;
        public bool CreateDatabaseServer(DatabaseServerTypes databaseServerType)
        {
            bool created = false;
            try
            {
                string fullPath = string.Concat(Shared.InfraDirectory, DBServerPath);
                string resourceFileName = Shared.GetRDSResourceFileName(Environment);
                switch (databaseServerType)
                {
                    case DatabaseServerTypes.SQL:
                        Console.WriteLine("Create IGS UAT SQL RDS");
                        created = true;
                        break;
                    case DatabaseServerTypes.MySQL:
                        Console.WriteLine("Create IGS UAT MYSQL RDS");
                        created = true;
                        break;
                }
                if (created)
                    Shared.CreateInfraDirectory(databaseServerType.ToString(), fullPath, resourceFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Creating IGS UAT Database server failed due to {ex.Message}");
            }
            return created;
        }

        public bool CreateVirtualMachine(VirtualMachineTypes virtualMachineType)
        {
            bool created = false;
            try
            {
                string fullPath = string.Concat(Shared.InfraDirectory, VMPath);
                string resourceFileName = Shared.GetVMResourceFileName(Environment);
                switch (virtualMachineType)
                {
                    case VirtualMachineTypes.Linux:
                        Console.WriteLine("Create IGS UAT Linux VM");
                        created = true;
                        break;
                    case VirtualMachineTypes.Windows:
                        Console.WriteLine("Create IGS UAT Windows VM");
                        created = true;
                        break;
                }
                if (created)
                    Shared.CreateInfraDirectory(virtualMachineType.ToString(), fullPath, resourceFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Creating IGS UAT virtual machine failed due to {ex.Message}");
            }
            return created;
        }
        public bool DeleteInfrastructure()
        {
            Console.WriteLine("Delete IGS UAT infra");
            return Shared.DeleteInfraResources(Shared.InfraDirectory, InfraPath);
        }
    }
}
