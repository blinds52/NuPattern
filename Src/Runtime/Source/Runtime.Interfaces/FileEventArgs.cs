﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.VisualStudio.Patterning.Runtime
{
	/// <summary>
	/// Argument for events that expose a file name.
	/// </summary>
	public class FileEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FileEventArgs"/> class.
		/// </summary>
		public FileEventArgs(string fileName)
		{
			this.FileName = fileName;
		}

		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		public string FileName { get; private set; }
	}
}
