﻿using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TeamArchitect.PowerTools;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features;
using NuPattern.Runtime;

namespace NuPattern.Extensibility
{
	/// <summary>
	/// Representes the editor to change icon paths.
	/// </summary>
	public class IconEditor : UITypeEditor
	{
		/// <summary>
		/// Edits the specified object's value using the editor style indicated by the <see cref="UITypeEditor.GetEditStyle()"/> method.
		/// </summary>
		/// <param name="context">An <see cref="ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
		/// <param name="provider">An <see cref="IServiceProvider"/> that this editor can use to obtain services.</param>
		/// <param name="value">The object to edit.</param>
		/// <returns>
		/// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
		/// </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			Guard.NotNull(() => context, context);
			Guard.NotNull(() => provider, provider);

			var componentModel = provider.GetService<SComponentModel, IComponentModel>();
			var picker = componentModel.GetService<Func<ISolutionPicker>>()();

			var solution = provider.GetService<ISolution>();
			picker.Owner = provider.GetService<SVsUIShell, IVsUIShell>().GetMainWindow();
			picker.Title = Properties.Resources.IconEditor_PickerTitle;
			picker.RootItem = solution;
			picker.Filter.Kind = ItemKind.Solution | ItemKind.SolutionFolder | ItemKind.Project | ItemKind.Folder | ItemKind.Item;
			picker.Filter.IncludeFileExtensions = Properties.Resources.IconEditor_FileExtensions;

			if (picker.ShowDialog().GetValueOrDefault())
			{
				var item = (IItem)picker.SelectedItem;
				item.Data.ItemType = BuildAction.Content.ToString();
				item.Data.IncludeInVSIX = Boolean.TrueString.ToLower(CultureInfo.CurrentCulture);
				value = item;
			}

			var converter = context.PropertyDescriptor.Converter;

			if (converter != null && converter.CanConvertTo(context, context.PropertyDescriptor.PropertyType))
			{
				return converter.ConvertTo(context, CultureInfo.CurrentCulture, value, context.PropertyDescriptor.PropertyType);
			}

			return value;
		}

		/// <summary>
		/// Gets the editor style used by the <see cref="UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method.
		/// </summary>
		/// <param name="context">An <see cref="ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
		/// <returns>
		/// A <see cref="UITypeEditorEditStyle"/> value that indicates the style of editor used by the <see cref="UITypeEditor.EditValue(IServiceProvider,Object)"/> method. If the <see cref="UITypeEditor"/> does not support this method, then <see cref="UITypeEditor.GetEditStyle()"/> will return <see cref="UITypeEditorEditStyle.None"/>.
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}