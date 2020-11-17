using CloudLibrary.Core.Enum;
using System;

namespace CloudLibrary.API.Model
{
    public class VirtualMachine
    {
        /// <summary>
        /// Linux, Windows....etc
        /// </summary>
        public VirtualMachineTypes Type { get; set; }
    }
}
