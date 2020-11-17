using CloudLibrary.Core.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CloudLibrary.Core.CloudEnvironment
{
    public static class Shared
    {
        internal static string InfraDirectory = string.Empty;

        internal static void SetInfraDirectory(string infraDirectory)
        {
            InfraDirectory = infraDirectory;
        }
        internal static void CreateInfraDirectory(string resourceType, string fullPath, string resourceFileName)
        {
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
            var fileContent = new { RDS = resourceType.ToString() };
            string json = JsonConvert.SerializeObject(fileContent);
            File.WriteAllText($"{fullPath}\\{resourceFileName}.json", json);
        }

        internal static string GetDBServerPath(string infraPath)
        {
            return $"{infraPath}DatabaseServer/";
        }

        internal static string GetVMPath(string infraPath)
        {
            return $"{infraPath}VirtualMachine/";
        }

        internal static string GetRDSResourceFileName(CloudEnvironments environment)
        {
            return $"{environment}_RDS_{DateTime.Now.ToString("ddMMyyyyhhmmssfff")}";
        }

        internal static string GetVMResourceFileName(CloudEnvironments environment)
        {
            return $"{environment}_Server_{DateTime.Now.ToString("ddMMyyyyhhmmssfff")}";
        }

        internal static bool DeleteInfraResources(string infraDirectory, string infraPath)
        {
            string fullPath = string.Concat(infraDirectory, infraPath);
            if (Directory.Exists(fullPath))
            {
                DirectoryInfo di = new DirectoryInfo(fullPath);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                return true;
            }
            return false;
        }
    }
}
