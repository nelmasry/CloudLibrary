using CloudLibrary.Core.Enum;
using System;
using System.Collections.Generic;

namespace CloudLibrary.Core.CloudEnvironment
{
    public interface ICloudEnvironment
    {
        /// <summary>
        /// Create Virtual machine in current infra
        /// </summary>
        /// <param name="virtualMachineType"></param>
        /// <returns></returns>
        bool CreateVirtualMachine(VirtualMachineTypes virtualMachineType);
        /// <summary>
        /// Create Database server in current infra
        /// </summary>
        /// <param name="databaseServerType"></param>
        /// <returns></returns>
        bool CreateDatabaseServer(DatabaseServerTypes databaseServerType);
        /// <summary>
        /// Delete Infrastructure by environment
        /// </summary>
        /// <param name="environmentName"></param>
        /// <returns></returns>
        bool DeleteInfrastructure();
    }
    // IGS
    public interface IIGSTest : ICloudEnvironment
    {
    }
    public interface IIGSUAT : ICloudEnvironment
    {
    }
    public interface IIGSProduction : ICloudEnvironment
    {
    }
    // AWS
    public interface IAWSTest : ICloudEnvironment
    {
    }
}
