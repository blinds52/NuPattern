﻿using System;
using System.IO;

namespace Microsoft.VisualStudio.Patterning.Runtime
{
	/// <summary>
	/// Helper methods for dealing with a schema state.
	/// </summary>
	[CLSCompliant(false)]
	public static class ISchemaReaderExtensions
	{
		/// <summary>
		/// Loads the model from the given model file.
		/// </summary>
		public static IPatternModelInfo Load(this ISchemaReader reader, string modelFile)
		{
			Guard.NotNull(() => reader, reader);
			Guard.NotNullOrEmpty(() => modelFile, modelFile);

			using (var stream = new FileStream(modelFile, FileMode.Open))
			{
				return reader.Load(stream);
			}
		}

		/// <summary>
		/// Loads the model using the information on the given resource to locate it.
		/// </summary>
		public static IPatternModelInfo Load(this ISchemaReader reader, ISchemaResource resource)
		{
			Guard.NotNull(() => reader, reader);
			Guard.NotNull(() => resource, resource);

			return reader.Load(resource.CreateStream());
		}
	}
}