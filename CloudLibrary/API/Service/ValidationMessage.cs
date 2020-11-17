using System;
using System.Collections.Generic;
using System.Text;

namespace CloudLibrary.API.Service
{
    public static class ValidationMessages
    {
        public static readonly string ProviderMissing = "Provider can not be empty";
        public static readonly string EnvironmentMissing = "Environment can not be empty";
        public static readonly string ResourcesMissing = "Infra Resources can not be empty";
        public static readonly string VirtualMachineTypeMissing = "Virtual machine type can not be empty";
        public static readonly string DatabaseServerMissing = "Database server type can not be empty";
    }
}
