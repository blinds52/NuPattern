﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Patterning.Runtime.Shell.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.VisualStudio.Patterning.Runtime.Shell.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not create tool window..
        /// </summary>
        internal static string CanNotCreateWindow {
            get {
                return ResourceManager.GetString("CanNotCreateWindow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Solution Builder.
        /// </summary>
        internal static string ExplorerWindowTitle {
            get {
                return ResourceManager.GetString("ExplorerWindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The dependency &apos;{0}&apos; could not be found in the repository..
        /// </summary>
        internal static string RuntimeShellPackage_DependencyNotAvailable {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_DependencyNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A MEF exception happened loading &apos;{0}&apos;. The MEF logs will be opened now for diagnostics..
        /// </summary>
        internal static string RuntimeShellPackage_DumpMefLogs {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_DumpMefLogs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not locate the package extension..
        /// </summary>
        internal static string RuntimeShellPackage_ExtensionNotFound {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_ExtensionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; extension
        ///
        ///Unable to download and install critical dependent packages to initialize this extension.
        ///This extension will fail to load correctly, and the &apos;Solution Builder&apos; tool window will not be available in this session of Visual Studio.
        ///
        ///Please ensure a recent version of the &apos;NuGet Package Manager&apos; extension is installed (downloaded from the Visual Studio Gallery), and that you are connected to a network.
        ///
        ///Please connect to a network and restart Visual Studio to complete the installation and  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RuntimeShellPackage_FailedPackageDependencies {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_FailedPackageDependencies", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Nuget Package Manager service could not be found..
        /// </summary>
        internal static string RuntimeShellPackage_PackageManagerNotInstalled {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_PackageManagerNotInstalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pattern Toolkit References.
        /// </summary>
        internal static string ToolkitReferencesFolderName {
            get {
                return ResourceManager.GetString("ToolkitReferencesFolderName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Logging Level.
        /// </summary>
        internal static string TraceOptionsPageControl_LoggingLevelTitle {
            get {
                return ResourceManager.GetString("TraceOptionsPageControl_LoggingLevelTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source Name is Invalid..
        /// </summary>
        internal static string TraceOptionsPageControl_SourceNameInvalid {
            get {
                return ResourceManager.GetString("TraceOptionsPageControl_SourceNameInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source Name is Required..
        /// </summary>
        internal static string TraceOptionsPageControl_SourceNameRequired {
            get {
                return ResourceManager.GetString("TraceOptionsPageControl_SourceNameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source Name.
        /// </summary>
        internal static string TraceOptionsPageControl_SourceNameTitle {
            get {
                return ResourceManager.GetString("TraceOptionsPageControl_SourceNameTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pattern Toolkit Extensions.
        /// </summary>
        internal static string TraceOutput_WindowTitle {
            get {
                return ResourceManager.GetString("TraceOutput_WindowTitle", resourceCulture);
            }
        }
    }
}
