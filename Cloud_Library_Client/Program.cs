using CloudLibrary.Core.CloudProvider;
using CloudLibrary.Core.Enum;
using CloudLibrary.API;
using CloudLibrary.API.Model;
using CloudLibrary.API.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Cloud_Library_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();

            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();

            IGSCloudService _IGSCloudService = new IGSCloudService(_cloudProviderFactory, @"D:\CloudInfra");
            
            
            // Create Test environment (Window & Linux VMs, SQL & MySQL RDS)
            var created = _IGSCloudService.CreateVirtualMachine(new VirtualMachine() { Type = VirtualMachineTypes.Linux },
                CloudEnvironments.Test);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateVirtualMachine(new VirtualMachine() { Type = VirtualMachineTypes.Windows },
                CloudEnvironments.Test);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateDatabaseServer(new DatabaseServer() { Type = DatabaseServerTypes.MySQL },
                CloudEnvironments.Test);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateDatabaseServer(new DatabaseServer() { Type = DatabaseServerTypes.SQL },
                CloudEnvironments.Test);
            Console.WriteLine(created);

            // Create UAT environment (2 Window VMs, SQL & MySQL RDS)
            created = _IGSCloudService.CreateVirtualMachine(new VirtualMachine() { Type = VirtualMachineTypes.Windows },
                CloudEnvironments.UAT);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateVirtualMachine(new VirtualMachine() { Type = VirtualMachineTypes.Windows },
                CloudEnvironments.UAT);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateDatabaseServer(new DatabaseServer() { Type = DatabaseServerTypes.MySQL },
                CloudEnvironments.UAT);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateDatabaseServer(new DatabaseServer() { Type = DatabaseServerTypes.SQL },
                CloudEnvironments.UAT);
            Console.WriteLine(created);

            // Create Prod environment (3 Window VMs, 3 SQL RDS)
            created = _IGSCloudService.CreateVirtualMachine(new VirtualMachine() { Type = VirtualMachineTypes.Windows },
                CloudEnvironments.Production);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateVirtualMachine(new VirtualMachine() { Type = VirtualMachineTypes.Windows },
                CloudEnvironments.Production);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateVirtualMachine(new VirtualMachine() { Type = VirtualMachineTypes.Windows },
                CloudEnvironments.Production);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateDatabaseServer(new DatabaseServer() { Type = DatabaseServerTypes.SQL },
                CloudEnvironments.Production);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateDatabaseServer(new DatabaseServer() { Type = DatabaseServerTypes.SQL },
                CloudEnvironments.Production);
            Console.WriteLine(created);
            created = _IGSCloudService.CreateDatabaseServer(new DatabaseServer() { Type = DatabaseServerTypes.SQL },
                CloudEnvironments.Production);
            Console.WriteLine(created);

            Thread.Sleep(5000);
            created = _IGSCloudService.DeleteInfrastructure(CloudEnvironments.Test);
            Console.WriteLine(created);
            Thread.Sleep(5000);
            created = _IGSCloudService.DeleteInfrastructure(CloudEnvironments.UAT);
            Console.WriteLine(created);


            Console.ReadLine();
        }
    }
}
