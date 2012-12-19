﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// The definition of the pattern in this toolkit.
	/// </summary>
	public partial interface IPatternModelSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IPatternModelSchema, object>> propertyExpression, Action<IPatternModelSchema> callbackAction);
	}
	
	/// <summary>
	/// The definition of the pattern in this toolkit.
	/// </summary>
	[Description("The definition of the pattern in this toolkit.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IPatternModelSchema  
	{
		/// <summary>
		/// Gets the identifier for this element.
		/// </summary>
		[Description("Gets the identifier for this element.")]
		global::System.Guid Id { get; } 
		/// <summary>
		/// The version of the base pattern line that this pattern line derives from.
		/// </summary>
		[Description("The version of the base pattern line that this pattern line derives from.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String BaseVersion { get; set; }
		
		/// <summary>
		/// The unique identifier of the base pattern line that this pattern line derives from.
		/// </summary>
		[Description("The unique identifier of the base pattern line that this pattern line derives from.")]
		global::System.String BaseId { get; set; }
		
		/// <summary>
		/// The pattern in this definition.
		/// </summary>
		[Description("The pattern in this definition.")]
		IPatternSchema Pattern { get; set; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IPatternSchema"/>, which is automatically added to the <c>Pattern</c> collection.
		/// </summary>
		IPatternSchema CreatePatternSchema(Action<IPatternSchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="IPatternSchema"/>, which is removed from the <c>Pattern</c> collection.
		/// </summary>
		void DeletePatternSchema(IPatternSchema instance);
	
		/// <summary>
		/// Gets the model extensions injected via Modeling extensions infrastructure.
		/// </summary>
		IEnumerable<TExtension> GetExtensions<TExtension>();
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// The definition of the pattern.
	/// </summary>
	public partial interface IPatternSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IPatternSchema, object>> propertyExpression, Action<IPatternSchema> callbackAction);
	}
	
	/// <summary>
	/// The definition of the pattern.
	/// </summary>
	[Description("The definition of the pattern.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IPatternSchema : IPatternElementSchema 
	{
		/// <summary>
		/// The identifier of the Visual Studio extension that deploys this pattern.
		/// </summary>
		[Description("The identifier of the Visual Studio extension that deploys this pattern.")]
		global::System.String ExtensionId { get; }
		
		/// <summary>
		/// Gets the currently opened diagram identifier.
		/// </summary>
		[Description("Gets the currently opened diagram identifier.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String CurrentDiagramId { get; set; }
		
		/// <summary>
		/// The identifier of the instance of this pattern.
		/// </summary>
		[Description("The identifier of the instance of this pattern.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String PatternLink { get; }
		
		/// <summary>
		/// The definition of the pattern.
		/// </summary>
		[Description("The definition of the pattern.")]
		IPatternModelSchema PatternModel { get; set; }
		
		/// <summary>
		/// The views of this pattern.
		/// </summary>
		[Description("The views of this pattern.")]
		IEnumerable<IViewSchema> Views { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IViewSchema"/>, which is automatically added to the <c>Views</c> collection.
		/// </summary>
		IViewSchema CreateViewSchema(Action<IViewSchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="IViewSchema"/>, which is removed from the <c>Views</c> collection.
		/// </summary>
		void DeleteViewSchema(IViewSchema instance);
		
		/// <summary>
		/// The extension points of other patterns that this pattern extends.
		/// </summary>
		[Description("The extension points of other patterns that this pattern extends.")]
		IEnumerable<IProvidedExtensionPointSchema> ProvidedExtensionPoints { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IProvidedExtensionPointSchema"/>, which is automatically added to the <c>ProvidedExtensionPoints</c> collection.
		/// </summary>
		IProvidedExtensionPointSchema CreateProvidedExtensionPointSchema(Action<IProvidedExtensionPointSchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="IProvidedExtensionPointSchema"/>, which is removed from the <c>ProvidedExtensionPoints</c> collection.
		/// </summary>
		void DeleteProvidedExtensionPointSchema(IProvidedExtensionPointSchema instance);
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// An element that has a unique name.
	/// </summary>
	public partial interface INamedElementSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<INamedElementSchema, object>> propertyExpression, Action<INamedElementSchema> callbackAction);
	}
	
	/// <summary>
	/// An element that has a unique name.
	/// </summary>
	[Description("An element that has a unique name.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface INamedElementSchema  
	{
		/// <summary>
		/// Gets the identifier for this element.
		/// </summary>
		[Description("Gets the identifier for this element.")]
		global::System.Guid Id { get; } 
		/// <summary>
		/// The well-known name of this item in this model.
		/// </summary>
		[Description("The well-known name of this item in this model.")]
		global::System.String Name { get; set; }
		
		/// <summary>
		/// The identifier of the inherited variability model.
		/// </summary>
		[Description("The identifier of the inherited variability model.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String BaseId { get; }
		
		/// <summary>
		/// The name used for instances of this item, as seen by the user. Also used to name associated artifacts/configuration created for this item.
		/// </summary>
		[Description("The name used for instances of this item, as seen by the user. Also used to name associated artifacts/configuration created for this item.")]
		global::System.String DisplayName { get; set; }
		
		/// <summary>
		/// The description of this item displayed to the user.
		/// </summary>
		[Description("The description of this item displayed to the user.")]
		global::System.String Description { get; set; }
		
		/// <summary>
		/// Whether the element is derived from a base variability model definition.
		/// </summary>
		[Description("Whether the element is derived from a base variability model definition.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.Boolean IsInheritedFromBase { get; }
		
		/// <summary>
		/// Whether this element is hidden from the design-view. Used by automation extensions.
		/// </summary>
		[Description("Whether this element is hidden from the design-view. Used by automation extensions.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.Boolean IsSystem { get; set; }
		
		/// <summary>
		/// The identifier used for naming generating code artifacts that represent this element. This identifier must be unique across the whole model.
		/// </summary>
		[Description("The identifier used for naming generating code artifacts that represent this element. This identifier must be unique across the whole model.")]
		global::System.String CodeIdentifier { get; set; }
	
		/// <summary>
		/// Gets the model extensions injected via Modeling extensions infrastructure.
		/// </summary>
		IEnumerable<TExtension> GetExtensions<TExtension>();
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// A container of properties and automation.
	/// </summary>
	public partial interface IPatternElementSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IPatternElementSchema, object>> propertyExpression, Action<IPatternElementSchema> callbackAction);
	}
	
	/// <summary>
	/// A container of properties and automation.
	/// </summary>
	[Description("A container of properties and automation.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IPatternElementSchema : ICustomizableElementSchema 
	{
		/// <summary>
		/// The icon for this item displayed to the user.
		/// </summary>
		[Description("The icon for this item displayed to the user.")]
		global::System.String Icon { get; set; }
		
		/// <summary>
		/// The properties of this element.
		/// </summary>
		[Description("The properties of this element.")]
		IEnumerable<IPropertySchema> Properties { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IPropertySchema"/>, which is automatically added to the <c>Properties</c> collection.
		/// </summary>
		IPropertySchema CreatePropertySchema(Action<IPropertySchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="IPropertySchema"/>, which is removed from the <c>Properties</c> collection.
		/// </summary>
		void DeletePropertySchema(IPropertySchema instance);
		
		/// <summary>
		/// The automation settings of this element.
		/// </summary>
		[Description("The automation settings of this element.")]
		IEnumerable<IAutomationSettingsSchema> AutomationSettings { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="IAutomationSettingsSchema"/>, which is automatically added to the <c>AutomationSettings</c> collection.
		/// </summary>
		IAutomationSettingsSchema CreateAutomationSettingsSchema(Action<IAutomationSettingsSchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="IAutomationSettingsSchema"/>, which is removed from the <c>AutomationSettings</c> collection.
		/// </summary>
		void DeleteAutomationSettingsSchema(IAutomationSettingsSchema instance);
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// A property of an element.
	/// </summary>
	public partial interface IPropertySchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IPropertySchema, object>> propertyExpression, Action<IPropertySchema> callbackAction);
	}
	
	/// <summary>
	/// A property of an element.
	/// </summary>
	[Description("A property of an element.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IPropertySchema : ICustomizableElementSchema 
	{
		/// <summary>
		/// The initial value of this property when created.
		/// </summary>
		[Description("The initial value of this property when created.")]
		global::System.String RawDefaultValue { get; }
		
		/// <summary>
		/// The data type of this property, which determines the type of its value.
		/// </summary>
		[Description("The data type of this property, which determines the type of its value.")]
		global::System.String Type { get; set; }
		
		/// <summary>
		/// Whether this property is shown to the user.
		/// </summary>
		[Description("Whether this property is shown to the user.")]
		global::System.Boolean IsVisible { get; set; }
		
		/// <summary>
		/// Whether this property is read-only to the user.
		/// </summary>
		[Description("Whether this property is read-only to the user.")]
		global::System.Boolean IsReadOnly { get; set; }
		
		/// <summary>
		/// The category for this property, used to organize similar properties shown in the Properties Window.
		/// </summary>
		[Description("The category for this property, used to organize similar properties shown in the Properties Window.")]
		global::System.String Category { get; set; }
		
		/// <summary>
		/// The primary usage of this property,
		/// </summary>
		[Description("The primary usage of this property,")]
		[System.ComponentModel.ReadOnly(true)]
		global::NuPattern.Runtime.PropertyUsages PropertyUsage { get; }
		
		/// <summary>
		/// A System.ComponentModel.TypeConverter that converts from the string value of this property, that the user enters, to an instance of the Type of this property (and visa-versa). This Type Converter can also be used to provide a list of acceptable values.
		/// </summary>
		[Description("A System.ComponentModel.TypeConverter that converts from the string value of this property, that the user enters, to an instance of the Type of this property (and visa-versa). This Type Converter can also be used to provide a list of acceptable values.")]
		global::System.String TypeConverterTypeName { get; set; }
		
		/// <summary>
		/// A System.Drawing.Design.UITypeEditor that provides a custom UI for editing the value of this property.
		/// </summary>
		[Description("A System.Drawing.Design.UITypeEditor that provides a custom UI for editing the value of this property.")]
		global::System.String EditorTypeName { get; set; }
		
		/// <summary>
		/// A value provider that calculates the value of this property dynamically.
		/// </summary>
		[Description("A value provider that calculates the value of this property dynamically.")]
		global::System.String RawValueProvider { get; set; }
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// A distinct view of the pattern.
	/// </summary>
	public partial interface IViewSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IViewSchema, object>> propertyExpression, Action<IViewSchema> callbackAction);
	}
	
	/// <summary>
	/// A distinct view of the pattern.
	/// </summary>
	[Description("A distinct view of the pattern.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IViewSchema : ICustomizableElementSchema 
	{
		/// <summary>
		/// Whether this view is shown to the user.
		/// </summary>
		[Description("Whether this view is shown to the user.")]
		global::System.Boolean IsVisible { get; set; }
		
		/// <summary>
		/// Whether this is the default view
		/// </summary>
		[Description("Whether this is the default view")]
		global::System.Boolean IsDefault { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String DiagramId { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String Caption { get; }
		
		/// <summary>
		/// The owning pattern.
		/// </summary>
		[Description("The owning pattern.")]
		IPatternSchema Pattern { get; set; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="ICollectionSchema"/>, which is automatically added to the <c>Elements</c> collection.
		/// </summary>
		ICollectionSchema CreateCollectionSchema(Action<ICollectionSchema> initializer = null);
		
		/// <summary>
		/// Creates an instance of a child <see cref="IElementSchema"/>, which is automatically added to the <c>Elements</c> collection.
		/// </summary>
		IElementSchema CreateElementSchema(Action<IElementSchema> initializer = null);
		
		/// <summary>
		/// Creates an instance of a child <see cref="IExtensionPointSchema"/>, which is automatically added to the <c>ExtensionPoints</c> collection.
		/// </summary>
		IExtensionPointSchema CreateExtensionPointSchema(Action<IExtensionPointSchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="IExtensionPointSchema"/>, which is removed from the <c>ExtensionPoints</c> collection.
		/// </summary>
		void DeleteExtensionPointSchema(IExtensionPointSchema instance);
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// A child collection element.
	/// </summary>
	public partial interface ICollectionSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<ICollectionSchema, object>> propertyExpression, Action<ICollectionSchema> callbackAction);
	}
	
	/// <summary>
	/// A child collection element.
	/// </summary>
	[Description("A child collection element.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface ICollectionSchema : IAbstractElementSchema 
	{}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// A child element.
	/// </summary>
	public partial interface IElementSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IElementSchema, object>> propertyExpression, Action<IElementSchema> callbackAction);
	}
	
	/// <summary>
	/// A child element.
	/// </summary>
	[Description("A child element.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IElementSchema : IAbstractElementSchema 
	{}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// An element that supports customization of its properties.
	/// </summary>
	public partial interface ICustomizableElementSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<ICustomizableElementSchema, object>> propertyExpression, Action<ICustomizableElementSchema> callbackAction);
	}
	
	/// <summary>
	/// An element that supports customization of its properties.
	/// </summary>
	[Description("An element that supports customization of its properties.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface ICustomizableElementSchema : INamedElementSchema 
	{
		/// <summary>
		/// Whether customization is permitted for this element, all its policy settings, and any child elements.
		/// </summary>
		[Description("Whether customization is permitted for this element, all its policy settings, and any child elements.")]
		global::NuPattern.Runtime.CustomizationState IsCustomizable { get; set; }
		
		/// <summary>
		/// Whether customization is enabled for the tailor.
		/// </summary>
		[Description("Whether customization is enabled for the tailor.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.Boolean IsCustomizationEnabled { get; }
		
		/// <summary>
		/// Whether the policy can be modified.
		/// </summary>
		[Description("Whether the policy can be modified.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.Boolean IsCustomizationPolicyModifyable { get; }
		
		/// <summary>
		/// The customization policy that applies to the element.
		/// </summary>
		[Description("The customization policy that applies to the element.")]
		ICustomizationPolicySchema Policy { get; set; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="ICustomizationPolicySchema"/>, which is automatically added to the <c>Policy</c> collection.
		/// </summary>
		ICustomizationPolicySchema CreateCustomizationPolicySchema(Action<ICustomizationPolicySchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="ICustomizationPolicySchema"/>, which is removed from the <c>Policy</c> collection.
		/// </summary>
		void DeleteCustomizationPolicySchema(ICustomizationPolicySchema instance);
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// A child element or collection of the pattern.
	/// </summary>
	public partial interface IAbstractElementSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IAbstractElementSchema, object>> propertyExpression, Action<IAbstractElementSchema> callbackAction);
	}
	
	/// <summary>
	/// A child element or collection of the pattern.
	/// </summary>
	[Description("A child element or collection of the pattern.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IAbstractElementSchema : IPatternElementSchema 
	{
		/// <summary>
		/// Whether this item is shown to the user.
		/// </summary>
		[Description("Whether this item is shown to the user.")]
		global::System.Boolean IsVisible { get; set; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="ICollectionSchema"/>, which is automatically added to the <c>Elements</c> collection.
		/// </summary>
		ICollectionSchema CreateCollectionSchema(Action<ICollectionSchema> initializer = null);
		
		/// <summary>
		/// Creates an instance of a child <see cref="IElementSchema"/>, which is automatically added to the <c>Elements</c> collection.
		/// </summary>
		IElementSchema CreateElementSchema(Action<IElementSchema> initializer = null);
		
		/// <summary>
		/// Creates an instance of a child <see cref="IExtensionPointSchema"/>, which is automatically added to the <c>ExtensionPoints</c> collection.
		/// </summary>
		IExtensionPointSchema CreateExtensionPointSchema(Action<IExtensionPointSchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="IExtensionPointSchema"/>, which is removed from the <c>ExtensionPoints</c> collection.
		/// </summary>
		void DeleteExtensionPointSchema(IExtensionPointSchema instance);
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// The policy that controls what properties are customizable on an element.
	/// </summary>
	public partial interface ICustomizationPolicySchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<ICustomizationPolicySchema, object>> propertyExpression, Action<ICustomizationPolicySchema> callbackAction);
	}
	
	/// <summary>
	/// The policy that controls what properties are customizable on an element.
	/// </summary>
	[Description("The policy that controls what properties are customizable on an element.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface ICustomizationPolicySchema  
	{
		/// <summary>
		/// Gets the identifier for this element.
		/// </summary>
		[Description("Gets the identifier for this element.")]
		global::System.Guid Id { get; } 
		/// <summary>
		/// Whether any of the settings in the policy have been modified from their default values.
		/// </summary>
		[Description("Whether any of the settings in the policy have been modified from their default values.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.Boolean IsModified { get; }
		
		/// <summary>
		/// The extent to which settings have been customized.
		/// </summary>
		[Description("The extent to which settings have been customized.")]
		[System.ComponentModel.ReadOnly(true)]
		global::NuPattern.Runtime.CustomizedLevel CustomizationLevel { get; }
		
		/// <summary>
		/// The individual settings of the customization policy
		/// </summary>
		[Description("The individual settings of the customization policy")]
		IEnumerable<ICustomizableSettingSchema> Settings { get; }
		
		/// <summary>
		/// Creates an instance of a child <see cref="ICustomizableSettingSchema"/>, which is automatically added to the <c>Settings</c> collection.
		/// </summary>
		ICustomizableSettingSchema CreateCustomizableSettingSchema(Action<ICustomizableSettingSchema> initializer = null);
		
		/// <summary>
		/// Deletes an instance of a child <see cref="ICustomizableSettingSchema"/>, which is removed from the <c>Settings</c> collection.
		/// </summary>
		void DeleteCustomizableSettingSchema(ICustomizableSettingSchema instance);
		
		/// <summary>
		/// The owning element.
		/// </summary>
		[Description("The owning element.")]
		ICustomizableElementSchema Owner { get; set; }
	
		/// <summary>
		/// Gets the model extensions injected via Modeling extensions infrastructure.
		/// </summary>
		IEnumerable<TExtension> GetExtensions<TExtension>();
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// The settings for a customizable property.
	/// </summary>
	public partial interface ICustomizableSettingSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<ICustomizableSettingSchema, object>> propertyExpression, Action<ICustomizableSettingSchema> callbackAction);
	}
	
	/// <summary>
	/// The settings for a customizable property.
	/// </summary>
	[Description("The settings for a customizable property.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface ICustomizableSettingSchema  
	{
		/// <summary>
		/// Gets the identifier for this element.
		/// </summary>
		[Description("Gets the identifier for this element.")]
		global::System.Guid Id { get; } 
		/// <summary>
		/// Whether this setting can be further customized by a tailor.
		/// </summary>
		[Description("Whether this setting can be further customized by a tailor.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.Boolean IsEnabled { get; }
		
		/// <summary>
		/// The displayed caption shown to the user.
		/// </summary>
		[Description("The displayed caption shown to the user.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String Caption { get; }
		
		/// <summary>
		/// The formatter used for the caption.
		/// </summary>
		[Description("The formatter used for the caption.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String CaptionFormatter { get; }
		
		/// <summary>
		/// Whether the settings has been modified from its default value.
		/// </summary>
		[Description("Whether the settings has been modified from its default value.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.Boolean IsModified { get; }
		
		/// <summary>
		/// Whether this setting can be customized by a tailor by default.
		/// </summary>
		[Description("Whether this setting can be customized by a tailor by default.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.Boolean DefaultValue { get; set; }
		
		/// <summary>
		/// Whether this setting can be customized by a tailor.
		/// </summary>
		[Description("Whether this setting can be customized by a tailor.")]
		global::System.Boolean Value { get; set; }
		
		/// <summary>
		/// The associated property name for the setting.
		/// </summary>
		[Description("The associated property name for the setting.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String PropertyId { get; set; }
		
		/// <summary>
		/// The formatter used for the description.
		/// </summary>
		[Description("The formatter used for the description.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String DescriptionFormatter { get; }
		
		/// <summary>
		/// The displayed description shown to the user.
		/// </summary>
		[Description("The displayed description shown to the user.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String Description { get; }
		
		/// <summary>
		/// The owning policy.
		/// </summary>
		[Description("The owning policy.")]
		ICustomizationPolicySchema Policy { get; set; }
	
		/// <summary>
		/// Gets the model extensions injected via Modeling extensions infrastructure.
		/// </summary>
		IEnumerable<TExtension> GetExtensions<TExtension>();
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// The settings for an automation extension.
	/// </summary>
	public partial interface IAutomationSettingsSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IAutomationSettingsSchema, object>> propertyExpression, Action<IAutomationSettingsSchema> callbackAction);
	}
	
	/// <summary>
	/// The settings for an automation extension.
	/// </summary>
	[Description("The settings for an automation extension.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IAutomationSettingsSchema : ICustomizableElementSchema 
	{
		/// <summary>
		/// The name of this type of automation.
		/// </summary>
		[Description("The name of this type of automation.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String AutomationType { get; set; }
		
		/// <summary>
		/// The classification of this automation.
		/// </summary>
		[Description("The classification of this automation.")]
		[System.ComponentModel.ReadOnly(true)]
		global::NuPattern.Runtime.AutomationSettingsClassification Classification { get; set; }
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// The extension points that this pattern provides.
	/// </summary>
	public partial interface IProvidedExtensionPointSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IProvidedExtensionPointSchema, object>> propertyExpression, Action<IProvidedExtensionPointSchema> callbackAction);
	}
	
	/// <summary>
	/// The extension points that this pattern provides.
	/// </summary>
	[Description("The extension points that this pattern provides.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IProvidedExtensionPointSchema  
	{
		/// <summary>
		/// Gets the identifier for this element.
		/// </summary>
		[Description("Gets the identifier for this element.")]
		global::System.Guid Id { get; } 
		/// <summary>
		/// The extension point provided by this pattern.
		/// </summary>
		[Description("The extension point provided by this pattern.")]
		global::System.String ExtensionPointId { get; set; }
		
		/// <summary>
		/// The owning pattern.
		/// </summary>
		[Description("The owning pattern.")]
		IPatternSchema Pattern { get; set; }
	
		/// <summary>
		/// Gets the model extensions injected via Modeling extensions infrastructure.
		/// </summary>
		IEnumerable<TExtension> GetExtensions<TExtension>();
	}
}

namespace NuPattern.Runtime
{ 
	/// <summary>
	/// A child extension to the pattern, provided by a pattern of another toolkit.
	/// </summary>
	public partial interface IExtensionPointSchema : INotifyPropertyChanged
	{
		/// <summary>
		/// Subscribes to changes in the property referenced in the given 
		/// <paramref name="propertyExpression"/> with the given 
		/// <paramref name="callbackAction"/> delegate.
		/// </summary>
		/// <param name="propertyExpression">A lambda expression that accesses a property, such as <c>x => x.Name</c>.</param>
		/// <param name="callbackAction">The callback action to invoke when the given property changes.</param>
		IDisposable SubscribeChanged(Expression<Func<IExtensionPointSchema, object>> propertyExpression, Action<IExtensionPointSchema> callbackAction);
	}
	
	/// <summary>
	/// A child extension to the pattern, provided by a pattern of another toolkit.
	/// </summary>
	[Description("A child extension to the pattern, provided by a pattern of another toolkit.")]
	[GeneratedCode("NuPattern", "1.2.0.0")]
	public partial interface IExtensionPointSchema : IPatternElementSchema 
	{
		/// <summary>
		/// The unique type of this extension point, that other patterns would provide extensions to.
		/// </summary>
		[Description("The unique type of this extension point, that other patterns would provide extensions to.")]
		[System.ComponentModel.ReadOnly(true)]
		global::System.String RequiredExtensionPointId { get; }
		
		/// <summary>
		/// The owning element.
		/// </summary>
		[Description("The owning element.")]
		IAbstractElementSchema Owner { get; set; }
	}
}

