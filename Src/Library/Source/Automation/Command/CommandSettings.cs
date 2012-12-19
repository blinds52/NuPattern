﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using NuPattern.Runtime;

namespace NuPattern.Library.Automation
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	[TypeDescriptionProvider(typeof(CommandSettingsTypeDescriptionProvider))]
	public partial class CommandSettings : IBindingSettings
	{
		/// <summary>
		/// Creates the runtime automation element for this setting element.
		/// </summary>
		public IAutomationExtension CreateAutomation(IProductElement owner)
		{
			return new CommandAutomation(owner, this);
		}

		/// <summary>
		/// Gets the optional property bindings.
		/// </summary>
		IList<IPropertyBindingSettings> IBindingSettings.Properties
		{
			get
			{
				return new ReadOnlyCollection<IPropertyBindingSettings>(this.Properties
					.Where(prop => prop.ParentProvider == null)
					.Cast<IPropertyBindingSettings>()
					.ToList());
			}
		}

		/// <summary>
		/// Gets the classification of these settings.
		/// </summary>
		public AutomationSettingsClassification Classification
		{
			get { return AutomationSettingsClassification.General; }
		}
	}
}