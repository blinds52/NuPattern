﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuPattern.Authoring.PatternToolkitLibrary
{
	using global::NuPattern.Runtime;
	using global::NuPattern.Runtime.ToolkitInterface;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Composition;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::NuPattern.Runtime;

	/// <summary>
	/// Description for PatternToolkitLibrary.Development
	/// </summary>
	[Description("Description for PatternToolkitLibrary.Development")]
	[ToolkitInterfaceProxy(ExtensionId = "97bd7ab2-964b-43f1-8a08-be6db68b018b", DefinitionId = "e0779d33-8f19-4025-9a57-e75bc53a03ff", ProxyType = typeof(Development))]
	[System.CodeDom.Compiler.GeneratedCode("NuPattern Toolkit Library", "1.3.20.0")]
	[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
	internal partial class Development : IDevelopment
	{

		private Runtime.IView target;
		private IContainerProxy<IDevelopment> proxy;

		/// <summary>
		/// Creates a new instance of the <see cref="Development"/> class.
		/// </summary>
		[ImportingConstructor]
		private Development() { }

		/// <summary>
		/// Creates a new instance of the <see cref="Development"/> class.
		/// </summary>
		public Development(Runtime.IView target)
		{
		this.target = target;
		this.proxy = target.ProxyFor<IDevelopment>();
		OnCreated();
		}

		/// <summary>
		/// When overridden, initializes the class.
		/// </summary>
		partial void OnCreated();

		/// <summary>
		/// Gets the parent element.
		/// </summary>
		public virtual IPatternToolkitLibrary Parent
		{
			get { return this.target.Parent.As<IPatternToolkitLibrary>(); }
		}

		/// <summary>
		/// Gets the <see cref="ICommands"/> contained in this element.
		/// </summary>
		public virtual ICommands Commands
		{
			get { return proxy.GetElement(() => this.Commands, element => new Commands(element)); }
		}

		/// <summary>
		/// Gets the <see cref="IConditions"/> contained in this element.
		/// </summary>
		public virtual IConditions Conditions
		{
			get { return proxy.GetElement(() => this.Conditions, element => new Conditions(element)); }
		}

		/// <summary>
		/// Gets the <see cref="IEvents"/> contained in this element.
		/// </summary>
		public virtual IEvents Events
		{
			get { return proxy.GetElement(() => this.Events, element => new Events(element)); }
		}

		/// <summary>
		/// Gets the <see cref="ITypeConverters"/> contained in this element.
		/// </summary>
		public virtual ITypeConverters TypeConverters
		{
			get { return proxy.GetElement(() => this.TypeConverters, element => new TypeConverters(element)); }
		}

		/// <summary>
		/// Gets the <see cref="ITypeEditors"/> contained in this element.
		/// </summary>
		public virtual ITypeEditors TypeEditors
		{
			get { return proxy.GetElement(() => this.TypeEditors, element => new TypeEditors(element)); }
		}

		/// <summary>
		/// Gets the <see cref="IValidationRules"/> contained in this element.
		/// </summary>
		public virtual IValidationRules ValidationRules
		{
			get { return proxy.GetElement(() => this.ValidationRules, element => new ValidationRules(element)); }
		}

		/// <summary>
		/// Gets the <see cref="IValueProviders"/> contained in this element.
		/// </summary>
		public virtual IValueProviders ValueProviders
		{
			get { return proxy.GetElement(() => this.ValueProviders, element => new ValueProviders(element)); }
		}

		/// <summary>
		/// Gets the <see cref="IValueComparers"/> contained in this element.
		/// </summary>
		public virtual IValueComparers ValueComparers
		{
			get { return proxy.GetElement(() => this.ValueComparers, element => new ValueComparers(element)); }
		}

		/// <summary>
		/// Creates a new <see cref="ICommands"/>  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public virtual ICommands CreateCommands(string name, Action<ICommands> initializer = null, bool raiseInstantiateEvents = true)
		{
			return proxy.CreateCollection<ICommands>(name, initializer, raiseInstantiateEvents);
		}

		/// <summary>
		/// Creates a new <see cref="IConditions"/>  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public virtual IConditions CreateConditions(string name, Action<IConditions> initializer = null, bool raiseInstantiateEvents = true)
		{
			return proxy.CreateCollection<IConditions>(name, initializer, raiseInstantiateEvents);
		}

		/// <summary>
		/// Creates a new <see cref="IEvents"/>  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public virtual IEvents CreateEvents(string name, Action<IEvents> initializer = null, bool raiseInstantiateEvents = true)
		{
			return proxy.CreateCollection<IEvents>(name, initializer, raiseInstantiateEvents);
		}

		/// <summary>
		/// Creates a new <see cref="ITypeConverters"/>  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public virtual ITypeConverters CreateTypeConverters(string name, Action<ITypeConverters> initializer = null, bool raiseInstantiateEvents = true)
		{
			return proxy.CreateCollection<ITypeConverters>(name, initializer, raiseInstantiateEvents);
		}

		/// <summary>
		/// Creates a new <see cref="ITypeEditors"/>  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public virtual ITypeEditors CreateTypeEditors(string name, Action<ITypeEditors> initializer = null, bool raiseInstantiateEvents = true)
		{
			return proxy.CreateCollection<ITypeEditors>(name, initializer, raiseInstantiateEvents);
		}

		/// <summary>
		/// Creates a new <see cref="IValidationRules"/>  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public virtual IValidationRules CreateValidationRules(string name, Action<IValidationRules> initializer = null, bool raiseInstantiateEvents = true)
		{
			return proxy.CreateCollection<IValidationRules>(name, initializer, raiseInstantiateEvents);
		}

		/// <summary>
		/// Creates a new <see cref="IValueProviders"/>  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public virtual IValueProviders CreateValueProviders(string name, Action<IValueProviders> initializer = null, bool raiseInstantiateEvents = true)
		{
			return proxy.CreateCollection<IValueProviders>(name, initializer, raiseInstantiateEvents);
		}

		/// <summary>
		/// Creates a new <see cref="IValueComparers"/>  
		/// executing the optional <paramref name="initializer"/> if not <see langword="null"/>.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public virtual IValueComparers CreateValueComparers(string name, Action<IValueComparers> initializer = null, bool raiseInstantiateEvents = true)
		{
			return proxy.CreateCollection<IValueComparers>(name, initializer, raiseInstantiateEvents);
		}

		/// <summary>
		/// Deletes this element.
		/// </summary>
		public virtual void Delete()
		{
			this.target.Delete();
		}

		/// <summary>
		/// Gets the generalized interface (<see cref="Runtime.IView"/>) of this element.
		/// </summary>
		public virtual Runtime.IView AsView()
		{
			return this.target;
		}

		/// <summary>
		/// Gets the specified generalized interface of this element, if possible.
		/// </summary>
		public virtual TGeneralizedInterface As<TGeneralizedInterface>() where TGeneralizedInterface : class
		{
			return this.target as TGeneralizedInterface;
		}
	}
}
