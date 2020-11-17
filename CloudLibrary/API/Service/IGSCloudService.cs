using CloudLibrary.Core.CloudProvider;
using CloudLibrary.Core.Enum;
using CloudLibrary.API.Model;
using System;
using CloudLibrary.Core.CloudEnvironment;

namespace CloudLibrary.API.Service
{
    public class IGSCloudService
    {
        ICloudProviderFactory _cloudProviderFactory;
        static CloudProvider Provider = CloudProvider.IGS;
        public IGSCloudService(ICloudProviderFactory cloudProviderFactory,string cloudInfraPath)
        {
            if (string.IsNullOrEmpty(cloudInfraPath))
                throw new Exception("Cloud Infra path required");
            _cloudProviderFactory = cloudProviderFactory;
            Shared.SetInfraDirectory(cloudInfraPath);
        }
        
        public string CreateVirtualMachine(VirtualMachine virtualMachine,CloudEnvironments environment)
        {
            var isValid = ValidateVirtualMachine(virtualMachine);
            if (!string.IsNullOrEmpty(isValid))
                return isValid;
            
            ICloudProvider cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(Provider);
            var cloudManager = cloudProvider.GetCloudEnvironment(environment);
            var created = cloudManager.CreateVirtualMachine(virtualMachine.Type);
            return created ? $"{environment}-{virtualMachine.Type} Virtual machine created successfully" : "Virtual machine creation failed";
        }
        public string CreateDatabaseServer(DatabaseServer databaseServer, CloudEnvironments environment)
        {
            var isValid = ValidateDatabaseServer(databaseServer);
            if (!string.IsNullOrEmpty(isValid))
                return isValid;
            ICloudProvider cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(Provider);
            var cloudManager = cloudProvider.GetCloudEnvironment(environment);
            var created = cloudManager.CreateDatabaseServer(databaseServer.Type);

            return created ? $"{environment}-{databaseServer.Type} Database server created successfully" : "Database server creation failed";
        }

        public string DeleteInfrastructure(CloudEnvironments infrastructureName)
        {
            ICloudProvider cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(Provider);
            var cloudManager = cloudProvider.GetCloudEnvironment(infrastructureName);
            var deleted = cloudManager.DeleteInfrastructure();

            return deleted ? $"{infrastructureName} deleted successfully" : $"{infrastructureName} deletion failed";
        }

        private string ValidateVirtualMachine(VirtualMachine virtualMachine)
        {
            if (virtualMachine.Type == 0)
                return ValidationMessages.VirtualMachineTypeMissing;
            return string.Empty;
        }
        private string ValidateDatabaseServer(DatabaseServer databaseServer)
        {
            if (databaseServer.Type == 0)
                return ValidationMessages.DatabaseServerMissing;
            return string.Empty;
        }
    }
}
