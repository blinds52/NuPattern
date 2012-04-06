﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.ExtensionManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Microsoft.VisualStudio.Patterning.Runtime.UnitTests
{
    public class InstalledToolkitInfoSpec
    {
        [TestClass]
        public class GivenNoContext
        {
            internal static readonly IAssertion Assert = new Assertion();

            private IInstalledExtension extension;
            private ISchemaReader reader;
            private ISchemaResource resource;

            [TestInitialize]
            public void InitializeContext()
            {
                this.extension = null;
                this.reader = new Mock<ISchemaReader>().Object;
                this.resource = new Mock<ISchemaResource>().Object;
            }

            [TestMethod]
            public void WhenInitializingWithANullExtension_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new InstalledToolkitInfo(this.extension, this.reader, this.resource));
            }

            [TestMethod]
            public void WhenInitializing_ThenExtensionIsSet()
            {
                var extension = new Mock<IInstalledExtension>().Object;

                var target = new InstalledToolkitInfo(extension, this.reader, this.resource);

                Assert.Same(extension, target.Extension);
            }

            [TestMethod]
            public void WhenInitializing_ThenIdIsExposed()
            {
                var extension = new Mock<IInstalledExtension>();
                extension.Setup(ext => ext.Header.Identifier).Returns("Foo");

                var target = new InstalledToolkitInfo(extension.Object, this.reader, this.resource);

                Assert.Equal("Foo", target.Id);
            }

            [TestMethod]
            public void WhenInitializing_ThenNameIsExposed()
            {
                var extension = new Mock<IInstalledExtension>();
                extension.Setup(ext => ext.Header.Name).Returns("Foo");

                var target = new InstalledToolkitInfo(extension.Object, this.reader, this.resource);

                Assert.Equal("Foo", target.Name);
            }

            [TestMethod]
            public void WhenInitializing_ThenAuthorIsExposed()
            {
                var extension = new Mock<IInstalledExtension>();
                extension.Setup(ext => ext.Header.Author).Returns("Foo");

                var target = new InstalledToolkitInfo(extension.Object, this.reader, this.resource);

                Assert.Equal("Foo", target.Author);
            }

            [TestMethod]
            public void WhenInitializing_ThenVersionIsExposed()
            {
                var extension = new Mock<IInstalledExtension>();
                extension.Setup(ext => ext.Header.Version).Returns(new Version(0, 0, 0, 1));

                var target = new InstalledToolkitInfo(extension.Object, this.reader, this.resource);

                Assert.Equal(new Version(0, 0, 0, 1), target.Version);
            }

            [TestMethod]
            public void WhenInitializing_ThenIconPathIsExposed()
            {
                var installPath = Path.GetTempPath();
                var icon = Path.GetRandomFileName();
                var iconPath = Path.Combine(installPath, icon);

                using (File.CreateText(iconPath))
                {
                }

                var extension = new Mock<IInstalledExtension>();
                extension.Setup(ext => ext.InstallPath).Returns(installPath);
                extension.Setup(ext => ext.Header.Icon).Returns(icon);

                var target = new InstalledToolkitInfo(extension.Object, this.reader, this.resource);

                File.Delete(iconPath);

                Assert.Equal(iconPath, target.ToolkitIconPath);
            }

            [TestMethod]
            public void WhenInitializingAndIconIsNull_ThenIconPathIsNull()
            {
                var extension = new Mock<IInstalledExtension>();
                extension.Setup(ext => ext.InstallPath).Returns(@"Z:\InstallDir");
                extension.Setup(ext => ext.Header.Icon).Returns((string)null);

                var target = new InstalledToolkitInfo(extension.Object, this.reader, this.resource);

                Assert.Null(target.PatternIconPath);
            }
        }

        [TestClass]
        public class GivenAnInstalledToolkitWithContents
        {
            internal static readonly IAssertion Assert = new Assertion();

            private IInstalledExtension extension;
            private InstalledToolkitInfo target;
            private ISchemaReader reader;
            private ISchemaResource resource;

            [TestInitialize]
            public void Initialize()
            {
                var mock = new Mock<IInstalledExtension>();
                mock.Setup(ext => ext.InstallPath).Returns(@"X:\");
                mock.Setup(ext => ext.Content).Returns(
                    new[]
					{ 
						Mocks.Of<IExtensionContent>().First(c => c.ContentTypeName == InstalledToolkitAdapter.CustomExtensionType && c.RelativePath == @"Foo.patterndefinition" && c.Attributes == new Dictionary<string, string> { { SchemaResource.AssemblyFileProperty, "Test.dll" } }),
						Mocks.Of<IExtensionContent>().First(c => c.ContentTypeName == "Other" && c.RelativePath == @"Documentation\Other.docx" && c.Attributes == new Dictionary<string, string> { { "IsCustomizable", bool.TrueString } }),
						Mocks.Of<IExtensionContent>().First(c => c.ContentTypeName == "Other" && c.RelativePath == @"Sample.file" && c.Attributes == new Dictionary<string, string> { { "IsCustomizable", bool.TrueString } })
					});

                this.extension = mock.Object;
                this.reader = new Mock<ISchemaReader>().Object;
                this.resource = new Mock<ISchemaResource>().Object;
                this.target = new InstalledToolkitInfo(this.extension, this.reader, this.resource);
            }

            [TestMethod]
            public void WhenGettingOtherContent_ThenProductContentIsRetrieved()
            {
                var content = this.target.GetCustomExtensions(InstalledToolkitAdapter.CustomExtensionType);

                Assert.Equal(1, content.Count());
                Assert.Equal("Foo.patterndefinition", content.First());
            }

            [TestMethod]
            public void WhenGettingOtherContentWithNullContentType_ThenThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => this.target.GetCustomExtensions(null));
            }

            [TestMethod]
            public void WhenGettingOtherContentWithEmptyContentType_ThenThrowsArgumentOutOfRangeException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => this.target.GetCustomExtensions(string.Empty));
            }

            [TestMethod]
            public void WhenGettingCustomizableExtensions_ThenGotItemsMarkedAsIsCustomizableOrInDocumentsFolder()
            {
                var contents = this.target.GetCustomizableExtensions();

                Assert.Equal(2, contents.Count());
                Assert.True(contents.Any(c => c.RelativePath.Equals(@"Documentation\Other.docx", StringComparison.OrdinalIgnoreCase)));
                Assert.True(contents.Any(c => c.RelativePath.Equals(@"Sample.file", StringComparison.OrdinalIgnoreCase)));
            }

            [TestMethod]
            [Ignore]
            public void WhenGettingToolkitSchema_ThenInitializesSchemaInstanceAndProductFactoryId()
            {
                // TODO: isolate the schema reading and extracting
                Assert.NotNull(this.target.Schema);
                Assert.Equal(this.target.Extension.Header.Identifier, this.target.Schema.Pattern.ExtensionId);
            }
        }
    }
}
