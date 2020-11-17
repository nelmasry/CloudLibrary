using CloudLibrary.Core.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace CloudLibrary.API.Model
{
    public class CloudInfraModel
    {
        public string Name
        {
            get
            {
                return Environment.ToString(); 
            }
        }
        /// <summary>
        /// Cloud Provider Ex. AWS,Azure
        /// </summary>
        public CloudProvider Provider { get; set; }
        /// <summary>
        /// Infrastructure Environment Ex. UAT,Prod
        /// </summary>
        public CloudEnvironments Environment { get; set; }
        /// <summary>
        /// List of virtual machines in infra
        /// </summary>
        public List<VirtualMachine> VirtualMachines { get; set; }
        /// <summary>
        /// List of Database servers in infra
        /// </summary>
        public List<DatabaseServer> DatabaseServers { get; set; }
    }
}
