using CloudLibrary.Core.Enum;
using System;
using System.Collections.Generic;

namespace CloudLibrary.Core.CloudEnvironment.IGS
{
    public class IGSProduction : IIGSProduction
    {
        static string InfraPath = $"/{Enum.CloudProvider.IGS}/{CloudEnvironments.Production}/";
        static string VMPath = Shared.GetVMPath(InfraPath);
        static string DBServerPath = Shared.GetDBServerPath(InfraPath);
        static CloudEnvironments Environment = CloudEnvironments.Production;
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
                        Console.WriteLine("Create IGS Prod SQL RDS");
                        created = true;
                        break;
                    case DatabaseServerTypes.MySQL:
                        Console.WriteLine("Create IGS Prod MYSQL RDS");
                        created = true;
                        break;
                }
                if (created)
                    Shared.CreateInfraDirectory(databaseServerType.ToString(), fullPath, resourceFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Creating IGS Prod Database server failed due to {ex.Message}");
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
                        Console.WriteLine("Create IGS Prod Linux VM");
                        created = true;
                        break;
                    case VirtualMachineTypes.Windows:
                        Console.WriteLine("Create IGS Prod Windows VM");
                        created = true;
                        break;
                }
                if (created)
                    Shared.CreateInfraDirectory(virtualMachineType.ToString(), fullPath, resourceFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Creating IGS Prod virtual machine failed due to {ex.Message}");
            }
            return created;
        }
        public bool DeleteInfrastructure()
        {
            Console.WriteLine("Deleting IGS Prod infra");
            return Shared.DeleteInfraResources(Shared.InfraDirectory, InfraPath);
        }
    }
}
