﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features;
using NuPattern.Extensibility.Properties;
using NuPattern.Runtime;

namespace NuPattern.Extensibility.Binding
{
	/// <summary>
	/// Implements a <see cref="IDynamicBindingContext"/> over an <see cref="IFeatureCompositionService"/> 
	/// so that dynamic exports can be added on top of it.
	/// </summary>
	/// <remarks>
	/// This class is internal as it's almost a memento pattern used by the dynamic binding 
	/// to provide consumers an API to add exports without exposing the internals.
	/// </remarks>
	internal sealed class CompositionServiceBindingContext : IDynamicBindingContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CompositionServiceBindingContext"/> class.
		/// </summary>
		public CompositionServiceBindingContext(IFeatureCompositionService compositionService)
		{
			try
			{
				// TODO: This should work as per suggestion BlueTab-PLATU10.
				this.SetupContainer(compositionService.GetExportedValue<ExportProvider>());

				return;
			}
			catch (ImportCardinalityMismatchException)
			{
				// TODO: \o/ when BlueTab-PLATU10 is fixed, this workaround should be removed.
				// Note: we don't go straight for this behavior because otherwise anything that uses dynamic 
				// bindings would become untestable automatically.
				var defaultImplementation = compositionService as FeatureCompositionService;
				if (defaultImplementation != null)
				{
					var containerField = typeof(FeatureCompositionService).GetField("container", BindingFlags.Instance | BindingFlags.NonPublic);
					if (containerField == null)
					{
						throw new NotSupportedException(Resources.BindingFactory_DefaultCompositionServiceChanged);
					}

					var compositionContainer = containerField.GetValue(defaultImplementation) as CompositionContainer;
					if (compositionContainer == null)
					{
						throw new NotSupportedException(Resources.BindingFactory_DefaultCompositionServiceContainerUnavailable);
					}

					this.SetupContainer(compositionContainer);

					return;
				}
			}

			throw new NotSupportedException(Resources.BindingFactory_DynamicContextUnsupported);
		}

		/// <summary>
		/// Gets the container that has the dynamically added exports.
		/// </summary>
		public CompositionContainer Container { get; set; }

		/// <summary>
		/// Gets the composition service backing the context.
		/// </summary>
		public ICompositionService CompositionService { get { return this.Container; } }

		/// <summary>
		/// Adds the given instance with the contract specified.
		/// </summary>
		/// <typeparam name="T">The type of the contract to export the instance with.</typeparam>
		/// <param name="instance">The exported value.</param>
		public void AddExport<T>(T instance) where T : class
		{
			this.Container.ComposeExportedValue(instance);
		}

		/// <summary>
		/// Adds the given instance with the contract type and name specified.
		/// </summary>
		/// <typeparam name="T">The type of the contract to export the instance with.</typeparam>
		/// <param name="instance">The exported value.</param>
		/// <param name="contractName">Name of the contract.</param>
		public void AddExport<T>(T instance, string contractName) where T : class
		{
			this.Container.ComposeExportedValue(contractName, instance);
		}

		/// <summary>
		/// Disposes the <see cref="Container"/> in use.
		/// </summary>
		public void Dispose()
		{
			this.Container.Dispose();
		}

		private void SetupContainer(ExportProvider parentProvider)
		{
			this.Container = new CompositionContainer(parentProvider);
		}
	}
}
