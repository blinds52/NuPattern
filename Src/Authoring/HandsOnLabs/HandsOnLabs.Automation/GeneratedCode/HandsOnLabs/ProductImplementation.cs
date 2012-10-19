﻿
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Patterning.HandsOnLabs
{
	using global::Microsoft.VisualStudio.Patterning.Runtime;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Composition;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::Microsoft.VisualStudio.Patterning.Runtime;

	///	<summary>
	///	Hands on Labs for Creating Pattern Toolkits
	///	</summary>
	[Description("Hands on Labs for Creating Pattern Toolkits")]
	[ToolkitInterfaceProxy(ExtensionId ="5d64cfe6-a6ff-4e73-a000-c6a8832740ff", DefinitionId = "71309920-c4ac-4283-b6bf-3cec975eca86", ProxyType = typeof(PatternToolkitHOLs))]
	[System.CodeDom.Compiler.GeneratedCode("Pattern Toolkit Automation Library", "1.3.20.0")]
	[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
	internal partial class PatternToolkitHOLs : IPatternToolkitHOLs
	{
		private Runtime.IProduct target;
		private Runtime.IProductProxy<IPatternToolkitHOLs> proxy;

		/// <summary>
		/// For MEF.
		/// </summary>
		[ImportingConstructor]
		private PatternToolkitHOLs() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PatternToolkitHOLs"/> class.
		/// </summary>
		public PatternToolkitHOLs(Runtime.IProduct target)
		{
			this.target = target;
			this.proxy = target.ProxyFor<IPatternToolkitHOLs>();
			OnCreated();
		}	

		partial void OnCreated();
		
		///	<summary>
		///	The ToolkitInfo.
		///	</summary>
		public virtual IProductToolkitInfo ToolkitInfo 
		{ 
			get { return this.proxy.GetValue(() => this.ToolkitInfo); }
		}
		
		///	<summary>
		///	The CurrentView.
		///	</summary>
		public virtual IView CurrentView 
		{ 
			get { return this.proxy.GetValue(() => this.CurrentView); }
			set { this.proxy.SetValue(() => this.CurrentView, value); }
		}
		
		///	<summary>
		///	The name of this element instance.
		///	</summary>
		[ParenthesizePropertyName(true)]
		[Description("The name of this element instance.")]
		public virtual String InstanceName 
		{ 
			get { return this.proxy.GetValue(() => this.InstanceName); }
			set { this.proxy.SetValue(() => this.InstanceName, value); }
		}
		
		///	<summary>
		///	The order of this element relative to its siblings.
		///	</summary>
		[ReadOnly(true)]
		[Description("The order of this element relative to its siblings.")]
		public virtual Double InstanceOrder 
		{ 
			get { return this.proxy.GetValue(() => this.InstanceOrder); }
			set { this.proxy.SetValue(() => this.InstanceOrder, value); }
		}
		
		///	<summary>
		///	The references of this element.
		///	</summary>
		[Description("The references of this element.")]
		public virtual IEnumerable<IReference> References 
		{ 
			get { return this.proxy.GetValue(() => this.References); }
		}
		
		///	<summary>
		///	Notes for this element.
		///	</summary>
		[Description("Notes for this element.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		public virtual String Notes 
		{ 
			get { return this.proxy.GetValue(() => this.Notes); }
			set { this.proxy.SetValue(() => this.Notes, value); }
		}
		
		///	<summary>
		///	The InTransaction.
		///	</summary>
		public virtual Boolean InTransaction 
		{ 
			get { return this.proxy.GetValue(() => this.InTransaction); }
		}
		
		///	<summary>
		///	The IsSerializing.
		///	</summary>
		public virtual Boolean IsSerializing 
		{ 
			get { return this.proxy.GetValue(() => this.IsSerializing); }
		}

		///	<summary>
		///	Description for PatternToolkitHOLs.DefaultView
		///	</summary>
		[Description("Description for PatternToolkitHOLs.DefaultView")]
		public virtual IDefaultView DefaultView
		{ 
			get { return this.proxy.GetView(() => this.DefaultView, view => new DefaultView(view)); }
		}

		/// <summary>
		/// Gets the generic <see cref="Runtime.IProduct"/> underlying element.
		/// </summary>
		public virtual Runtime.IProduct AsProduct()
		{
			return this.target;
		}

		/// <summary>
		/// Gets the generic underlying element as the given type if possible.
		/// </summary>
		public virtual TRuntimeInterface As<TRuntimeInterface>()
			where TRuntimeInterface : class
		{
			return this.target as TRuntimeInterface;
		}

		/// <summary>
		/// Deletes this instance.
		/// </summary>
		public virtual void Delete()
		{
			this.target.Delete();
		}
	}
}