using CloudLibrary.API;
using CloudLibrary.Core.CloudEnvironment;
using CloudLibrary.Core.CloudProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CloudLibrary.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void TestGetAbstractCloudProvider()
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();
            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();
            var cloudProvider =_cloudProviderFactory.GetAbstractCloudProvider(Core.Enum.CloudProvider.IGS);
            
            Assert.IsNotNull(cloudProvider);
            Assert.IsInstanceOfType(cloudProvider,typeof (IIGSCloudProvider));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Unknown Provider : 0")]
        public void TestGetAbstractCloudProvider_UnknownProvider()
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();
            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();
            _cloudProviderFactory.GetAbstractCloudProvider(0);
        }

        [TestMethod]
        public void TestGetCloudEnvironment()
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();
            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();
            var _cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(Core.Enum.CloudProvider.IGS);
            var _cloudManager = _cloudProvider.GetCloudEnvironment(Core.Enum.CloudEnvironments.UAT);
            Assert.IsNotNull(_cloudManager);
            Assert.IsInstanceOfType(_cloudManager, typeof(IIGSUAT));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Unknown Environment : 0")]
        public void TestGetCloudEnvironment_UnknownEnvironment()
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();
            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();
            var _cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(0);
            _cloudProvider.GetCloudEnvironment(0);
        }

        [TestMethod]
        public void TestCreateVirtualMachine()
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();
            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();
            var _cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(Core.Enum.CloudProvider.IGS);
            var _cloudManager = _cloudProvider.GetCloudEnvironment(Core.Enum.CloudEnvironments.UAT);
            var created = _cloudManager.CreateVirtualMachine(Core.Enum.VirtualMachineTypes.Windows);
            Assert.IsTrue(created);
        }

        [TestMethod]
        public void TestCreateVirtualMachine_NotValidType()
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();
            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();
            var _cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(Core.Enum.CloudProvider.IGS);
            var _cloudManager = _cloudProvider.GetCloudEnvironment(Core.Enum.CloudEnvironments.UAT);
            var created = _cloudManager.CreateVirtualMachine(0);
            Assert.IsFalse(created);
        }

        [TestMethod]
        public void TestCreateDatabaseServer()
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();
            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();
            var _cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(Core.Enum.CloudProvider.IGS);
            var _cloudManager = _cloudProvider.GetCloudEnvironment(Core.Enum.CloudEnvironments.UAT);
            var created = _cloudManager.CreateDatabaseServer(Core.Enum.DatabaseServerTypes.SQL);
            Assert.IsTrue(created);
        }

        [TestMethod]
        public void TestCreateDatabaseServer_NotValidType()
        {
            var serviceProvider = new ServiceCollection()
            .AddCloudLibraryDI()
            .BuildServiceProvider();
            var _cloudProviderFactory = serviceProvider.GetService<ICloudProviderFactory>();
            var _cloudProvider = _cloudProviderFactory.GetAbstractCloudProvider(Core.Enum.CloudProvider.IGS);
            var _cloudManager = _cloudProvider.GetCloudEnvironment(Core.Enum.CloudEnvironments.UAT);
            var created = _cloudManager.CreateDatabaseServer(0);
            Assert.IsFalse(created);
        }
    }
}
