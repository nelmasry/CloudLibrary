using CloudLibrary.Core.Enum;
using System;

namespace CloudLibrary.API.Model
{
    public class DatabaseServer
    {
        public DatabaseServerTypes Type { get; set; }
        
        public string Name { get; set; }
    }
}
