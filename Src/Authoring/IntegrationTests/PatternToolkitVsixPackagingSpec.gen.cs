﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuPattern.IntegrationTests;

namespace NuPattern.Authoring.IntegrationTests
{
    [TestClass]
    public class PatternToolkitVsixPackagingSpec
    {
        private static readonly IAssertion Assert = new Assertion();
        private const string DeployedContentDirectory = "Authoring.IntegrationTests.Content";
        private const string DeployedVsixItem = DeployedContentDirectory + "\\NuPatternToolkitBuilder.vsix";

        [TestClass]
        [DeploymentItem(DeployedContentDirectory, DeployedContentDirectory)]
        public class GivenTheCompiledVsix : VsixPackagingSpec.GivenAVsix
        {
            /// <summary>
            /// Returns the relative path to the deployed Vsix file in the project
            /// </summary>
            protected override string DeployedVsixItemPath
            {
                get
                {
                    return DeployedVsixItem;
                }
            }
         
            [TestMethod, TestCategory("Integration")]
            public void ThenVsixInfoCorrect()
            {
                //Identifier, Name, Author, Version
                Assert.Equal(@"9f6dc301-6f66-4d21-9f9c-b37412b162f6", this.VsixInfo.Header.Identifier);
                Assert.Equal(@"NuPattern Toolkit Builder", this.VsixInfo.Header.Name);
                Assert.Equal(@"An extension for building NuPattern Toolkits, which automate design patterns for rapid and consistent custom solution development.", this.VsixInfo.Header.Description);
                Assert.Equal(@"NuPattern", this.VsixInfo.Header.Author);
                Assert.Equal("1.3.20.0", this.VsixInfo.Header.Version.ToString());
                
                //License, Icon, PreviewImage, MoreInfoUrl, GettingStartedGuide
                Assert.Equal(@"LICENSE.txt", this.VsixInfo.Header.License);
                Assert.Equal(@"Resources\VsixIconPatternToolkit.png", this.VsixInfo.Header.Icon);
                Assert.Equal(@"Resources\VsixPreviewPatternToolkit.png", this.VsixInfo.Header.PreviewImage);
                Assert.Equal(new Uri(@"http://nupattern.codeplex.com"), this.VsixInfo.Header.MoreInfoUrl);
                Assert.Equal(new Uri(@"http://nupattern.codeplex.com/wikipage?title=Getting%20Started"), this.VsixInfo.Header.GettingStartedGuide);

#if VSVER10
                Assert.Equal(@"4.0", this.VsixInfo.Header.SupportedFrameworkMinVersion.ToString());
                Assert.Equal(@"4.0", this.VsixInfo.Header.SupportedFrameworkMaxVersion.ToString());
#endif
#if VSVER11
                Assert.Equal(@"4.0", this.VsixInfo.Header.SupportedFrameworkVersionRange.Minimum.ToString());
                Assert.Equal(@"4.5", this.VsixInfo.Header.SupportedFrameworkVersionRange.Maximum.ToString());
#endif
                //SupportedProducts
#if VSVER10
                Assert.Equal(1, this.VsixInfo.Header.SupportedVSVersions.Count(t => t.Major.ToString() + "." + t.Minor.ToString() == "10.0"));
#endif
#if VSVER11
                Assert.Equal(1, this.VsixInfo.Targets.Count(t => t.VersionRange.Minimum.ToString() == "11.0"));
#endif
            }

            [TestMethod, TestCategory("Integration")]
            public void ThenContainsSchemas()
            {
                //Schema files (\GeneratedCode\*)
                this.AssertFolderContainsExclusive(@"GeneratedCode",
                    new[]
                        {
                            "WorkflowDesignSchema.xsd",
                        });
            }

            [TestMethod, TestCategory("Integration")]
            public void ThenContainsGuidance()
            {
                //Guidance (\\GeneratedCode\Gudiance\Content\*
                this.AssertFolderNotEmpty(@"GeneratedCode\Guidance\Content", "*.mht");

                //Assets (\\Assets\Guidance\*
                this.AssertFolderContainsExclusive(@"Assets\Guidance",
                    new[]
                        {
                            "AuthoringToolkitGuidance.pdf",
                            "PatternToolkitGuidanceTemplate.dotm",
                        });
            }
                
            [TestMethod, TestCategory("Integration")]
            public void ThenContainsAssets()
            {
                 //Templates (\\Assets\Templates\*
                this.AssertFolderContainsExclusive(@"Assets\Templates\Projects\Extensibility",
                    new[]
                        {
                            "Authoring.zip",
                        });
                this.AssertFolderContainsExclusive(@"Assets\Templates\Items\Extensibility",
                    new[]
                        {
                            "ItemTemplate.zip",
                            "PatternTooling.zip",
                            "ProjectTemplate.zip",
                            "TextTemplate.zip",
                            "Wizard.zip",
                            "WizardPage.zip",
                        });

                this.AssertFolderContainsExclusive(@"Assets\Templates\Text",
                    new[]
                        {
                            "Header.t4include",
                            "Utilities.t4include",
                        });

                this.AssertFolderContainsExclusive(@"Assets\Templates\Text\Guidance",
                    new[]
                        {
                            "GuidanceWorkflow.t4",
                            "ToolkitGuidance.t4",
                        });

                this.AssertFolderContainsExclusive(@"Assets\Templates\Text\ItemTemplate",
                    new[]
                        {
                            "ItemTemplate.vstemplate.t4",
                        });

                this.AssertFolderContainsExclusive(@"Assets\Templates\Text\PatternModel",
                    new[]
                        {
                            "PatternModel.patterndefinition.t4",
                        });
                
                this.AssertFolderContainsExclusive(@"Assets\Templates\Text\ProjectTemplate",
                    new[]
                        {
                            "ProjectTemplate.vstemplate.t4",
                        });
                
                this.AssertFolderContainsExclusive(@"Assets\Templates\Text\VsixManifest",
                    new[]
                        {
                            "source.extension.t4",
                            "source.extension.include.t4",
                        });
            }

            [TestMethod, TestCategory("Integration")]
            public void ThenContainsResources()
            {
                //Schema files (\Resources\*)
                this.AssertFolderContainsExclusive(@"Resources",
                    new[]
                        {
                            "VsixIconPatternToolkit.png",
                            "VsixPreviewPatternToolkit.png",
                        });
            }
            
            [TestMethod, TestCategory("Integration")]
            public void ThenContainsRedistributables()
            {
                //Redist files
                this.AssertFolderContainsExclusive("",
                    new[]
                        {
                            "extension.vsixmanifest",
                            //"[Content_Types].xml",
                            "LICENSE.txt",
                            "redist.txt",
                            "Release%20Notes.docx",

                            //Authoring Assemblies
                            "NuPattern.Authoring.Guidance.dll",
                            "NuPattern.Authoring.PatternModelDesign.Shell.dll",
                            "NuPattern.Authoring.PatternModelDesign.Shell.pkgdef",
                            "NuPattern.Authoring.PatternToolkit.Automation.dll",
                            "NuPattern.Authoring.PatternToolkit.dll",
                            "NuPattern.Authoring.PatternToolkit.pkgdef",
                            "NuPattern.Authoring.PatternToolkit.targets",
                            "NuPattern.Authoring.WorkflowDesign.dll",
                            "NuPattern.Authoring.WorkflowDesign.Extensibility.dll",
                            "NuPattern.Authoring.WorkflowDesign.Shell.dll",
                            "NuPattern.Authoring.WorkflowDesign.Shell.pkgdef",

                            //Embedded VSIXes
                            "NuPatternToolkitLibrary.vsix",
                            "NuPatternToolkitManager.vsix",
                        });
            }
        }
    }
}
