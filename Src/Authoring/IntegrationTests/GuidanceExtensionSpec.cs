﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VSSDK.Tools.VsIdeTesting;
using NuPattern.Authoring.PatternToolkit;
using NuPattern.Runtime.Guidance;

namespace NuPattern.Authoring.IntegrationTests
{
    [TestClass]
    public class GuidanceExtensionSpec
    {
        internal static readonly IAssertion Assert = new Assertion();
        private IGuidanceManager featureManager;

        [TestInitialize]
        public void InitializeContext()
        {
            this.featureManager = (IGuidanceManager)VsIdeTestHostContext.ServiceProvider.GetService(typeof(IGuidanceManager));
        }

        [HostType("VS IDE")]
        [TestMethod, TestCategory("Integration")]
        public void ThenGuidanceExtensionIsInstalled()
        {
            var registrations = this.featureManager.InstalledGuidanceExtensions;
            var feature = registrations.FirstOrDefault(registration => registration.ExtensionId == AuthoringToolkitInfo.VsixIdentifier);

            Assert.NotNull(feature);
        }
    }
}
