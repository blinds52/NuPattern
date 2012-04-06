﻿using System;

namespace Microsoft.VisualStudio.Patterning.Runtime.Shell
{
	/// <summary>
	/// Defines the constants used in this package.
	/// </summary>
	internal static class Constants
	{
		/// <summary>
		/// The GUID for this package.
		/// </summary>
		public const string RuntimeShellPkgGuid = "93373818-600f-414b-8181-3a0cb79fa785";

		/// <summary>
		/// Description for the runtime store T4 process
		/// </summary>
		public const string ProductStateStoreDirectiveProcessorDescription = "Provides access to the solution builder store.";

		/// <summary>
		/// Description for the library T4 process
		/// </summary>
		public const string LibraryDirectiveProcessorDescription = "Provides access to pattern model element information.";

		/// <summary>
		/// Id of the Visual Studio OutputPane window.
		/// </summary>
		public const string VsOutputWindowPaneId = "{35A16645-19A3-4CCA-9C44-631C33D750D4}";

		/// <summary>
		/// The product name.
		/// </summary>
		public const string ProductName = "Pattern Toolkit Manager";

		/// <summary>
		/// The name for storing settings for this package.
		/// </summary>
		public const string SettingsName = "PatternToolkitExtensions";

		internal static class PackageDependencies
		{
			public const string PackageName = @"Newtonsoft.Json";
            public static readonly Version PackageVersion = new Version("4.0.2");
            public const string Marker = @"Newtonsoft.Json.dll";
            public const string TargetDir = @"lib\net40";
            public const string TargetMask = @"*.dll";
		}
	}
}