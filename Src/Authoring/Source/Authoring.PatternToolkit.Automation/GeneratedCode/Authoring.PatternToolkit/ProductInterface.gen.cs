﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuPattern.Authoring.PatternToolkit
{
	using global::NuPattern.Runtime;
	using global::NuPattern.Runtime.Bindings;
	using global::NuPattern.Runtime.Design;
	using global::NuPattern.Runtime.ToolkitInterface;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::NuPattern.Runtime;

	/// <summary>
	/// A Pattern Toolkit which captures and automates a design pattern for rapid and consistent custom solution development.
	/// </summary>
	[Description("A Pattern Toolkit which captures and automates a design pattern for rapid and consistent custom solution development.")]
	[ToolkitInterface(ExtensionId = "9f6dc301-6f66-4d21-9f9c-b37412b162f6", DefinitionId = "c034429e-01f9-48dd-a478-0321fb708dd3", ProxyType = typeof(PatternToolkit))]
	[System.CodeDom.Compiler.GeneratedCode("NuPattern Toolkit Library", "1.3.20.0")]
	public partial interface IPatternToolkit : IToolkitInterface
	{

		/// <summary>
		/// When to transform all code generation templates in this toolkit, to ensure that all toolkit artifacts are up to date.
		/// </summary>
		[Description("When to transform all code generation templates in this toolkit, to ensure that all toolkit artifacts are up to date.")]
		[DisplayName("Transform On Build")]
		[Category("Code Generation")]
		[TypeConverter(typeof(TransformOnBuildConverter))]
		String TransformOnBuild { get; set; }

		/// <summary>
		/// The initial name of the pattern
		/// </summary>
		[Description("The initial name of the pattern")]
		[DisplayName("Pattern Name")]
		[Category("General")]
		String PatternName { get; set; }

		/// <summary>
		/// The initial description of the pattern
		/// </summary>
		[Description("The initial description of the pattern")]
		[DisplayName("Pattern Description")]
		[Category("General")]
		String PatternDescription { get; set; }

		/// <summary>
		/// The ID of the tailored pattern, if this pattern is tailored
		/// </summary>
		[Description("The ID of the tailored pattern, if this pattern is tailored")]
		[DisplayName("Base Toolkit")]
		[Category("General")]
		String ExistingToolkitId { get; set; }

		/// <summary>
		/// The solution name.
		/// </summary>
		[Description("The solution name.")]
		[DisplayName("Solution Name")]
		[Category("General")]
		String SolutionName { get; set; }

		/// <summary>
		/// The project root namespace
		/// </summary>
		[Description("The project root namespace")]
		[DisplayName("Project Root Namespace")]
		[Category("General")]
		String ProjectRootNamespace { get; set; }

		/// <summary>
		/// The project assembly name
		/// </summary>
		[Description("The project assembly name")]
		[DisplayName("Project Assembly Name")]
		[Category("General")]
		String ProjectAssemblyName { get; set; }

		/// <summary>
		/// Excludes all generated code from code coverage metrics.
		/// </summary>
		[Description("Excludes all generated code from code coverage metrics.")]
		[DisplayName("Exclude From Code Coverage")]
		[Category("Code Generation")]
		Boolean ExcludeFromCodeCoverage { get; set; }

		/// <summary>
		/// Gets or sets the ToolkitInfo property.
		/// </summary>
		IProductToolkitInfo ToolkitInfo { get; }

		/// <summary>
		/// Gets or sets the CurrentView property.
		/// </summary>
		IView CurrentView { get; set; }

		/// <summary>
		/// The name of this element instance.
		/// </summary>
		[Description("The name of this element instance.")]
		[ParenthesizePropertyName(true)]
		String InstanceName { get; set; }

		/// <summary>
		/// The order of this element relative to its siblings.
		/// </summary>
		[Description("The order of this element relative to its siblings.")]
		[ReadOnly(true)]
		Double InstanceOrder { get; set; }

		/// <summary>
		/// The references of this element.
		/// </summary>
		[Description("The references of this element.")]
		IEnumerable<IReference> References { get; }

		/// <summary>
		/// Notes for this element.
		/// </summary>
		[Description("Notes for this element.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		String Notes { get; set; }

		/// <summary>
		/// Gets or sets the InTransaction property.
		/// </summary>
		Boolean InTransaction { get; }

		/// <summary>
		/// Gets or sets the IsSerializing property.
		/// </summary>
		Boolean IsSerializing { get; }

		/// <summary>
		/// The development view of a toolkit.
		/// </summary>
		[Description("The development view of a toolkit.")]
		IDevelopment Development { get; }

		/// <summary>
		/// The design view of the toolkit.
		/// </summary>
		[Description("The design view of the toolkit.")]
		IDesign Design { get; }

		/// <summary>
		/// Deletes this element.
		/// </summary>
		void Delete();

		/// <summary>
		/// Gets the generalized interface (<see cref="Runtime.IProduct"/>) of this element.
		/// </summary>
		Runtime.IProduct AsProduct();
	}
}
