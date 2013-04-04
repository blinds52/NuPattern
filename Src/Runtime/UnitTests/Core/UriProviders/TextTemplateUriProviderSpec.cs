﻿using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.ExtensionManager;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.TeamArchitect.PowerTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using Moq;
using NuPattern.Runtime.UriProviders;

namespace NuPattern.Runtime.UnitTests.UriProviders
{
    public class TextTemplateUriProviderSpec
    {
        internal static readonly IAssertion Assert = new Assertion();

        [TestClass]
        public class GivenATemplateProvider
        {
            [TestInitialize]
            public void Initialize()
            {
                this.Templating = new Mock<ITextTemplating>();
                this.ModelBus = new Mock<IModelBus>();
                this.UriService = new Mock<IFxrUriReferenceService>();
                this.UriProvider = new TextTemplateUriProvider(this.Templating.Object, this.ModelBus.Object, new Lazy<IFxrUriReferenceService>(() => this.UriService.Object));
            }

            protected Mock<ITextTemplating> Templating { get; private set; }
            protected Mock<IModelBus> ModelBus { get; private set; }
            protected Mock<IFxrUriReferenceService> UriService { get; private set; }
            protected IFxrUriReferenceProvider<ITemplate> UriProvider { get; private set; }

            [TestMethod, TestCategory("Unit")]
            public void WhenExtensionRelativeUriCannotResolveExtension_ThenReturnsNull()
            {
                var template = this.UriProvider.ResolveUri(new Uri("t4://extension/bar/template.t4"));

                Assert.Null(template);
            }

            [TestMethod, TestCategory("Unit")]
            public void WhenExtensionRelativeUriCannotFindRelativePath_ThenReturnsNull()
            {
                this.UriService
                    .Setup(x => x.ResolveUri<IInstalledExtension>(It.IsAny<Uri>()))
                    .Returns(Mocks.Of<IInstalledExtension>().First(x => x.InstallPath == "C:\\Temp"));

                var template = this.UriProvider.ResolveUri(new Uri("t4://extension//bar/template.t4"));

                Assert.Null(template);
            }

            [DeploymentItem(@"Core\UriProviders\TemplateWithTemplatePath.t4", @"Core\TextTemplateUriProviderSpec\WhenExtensionRelativeFileExists_ThenReturnsValidTemplate")]
            [TestMethod, TestCategory("Unit")]
            public void WhenExtensionRelativeFileExists_ThenReturnsValidTemplate()
            {
                this.UriService
                    .Setup(x => x.ResolveUri<IInstalledExtension>(It.IsAny<Uri>()))
                    .Returns(Mocks.Of<IInstalledExtension>().First(x => x.InstallPath == new DirectoryInfo(@"Core\TextTemplateUriProviderSpec\WhenExtensionRelativeFileExists_ThenReturnsValidTemplate").FullName));

                var template = this.UriProvider.ResolveUri(new Uri("t4://extension/test/TemplateWithTemplatePath.t4"));

                Assert.NotNull(template);
            }
        }
    }
}