﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Design;
using Microsoft.VisualStudio.Patterning.Extensibility;

namespace Microsoft.VisualStudio.Patterning.Runtime.Schema
{
    /// <summary>
    /// Customizations for the PatternModelSerializationHelper class.
    /// </summary>
	public partial class PatternModelSerializationHelper
	{
		/// <summary>
		/// Resets all tracking properties.
		/// </summary>
		private static void ResetTrackingProperties(Store store)
		{
			// Two passes required - once to set all elements to storage-based
			// then another to set some back to being tracking.
			var namedElementSchemas = store.ElementDirectory.AllElements.OfType<NamedElementSchema>();
			foreach (var element in namedElementSchemas)
			{
				NamedElementSchema.IsDisplayNameTrackingPropertyHandler.Instance.PreResetValue(element);
				NamedElementSchema.IsDescriptionTrackingPropertyHandler.Instance.PreResetValue(element);
				NamedElementSchema.IsCodeIdentifierTrackingPropertyHandler.Instance.PreResetValue(element);
			}

			foreach (var element in namedElementSchemas)
			{
				NamedElementSchema.IsDisplayNameTrackingPropertyHandler.Instance.ResetValue(element);
				NamedElementSchema.IsDescriptionTrackingPropertyHandler.Instance.ResetValue(element);
				NamedElementSchema.IsCodeIdentifierTrackingPropertyHandler.Instance.ResetValue(element);
			}
		}
	}

    /// <summary>
    /// Customizations for the NamedElementSchema class.
    /// </summary>
    public partial class NamedElementSchema
    {
        private string displayNameStorage = string.Empty;
        private string descriptionStorage = string.Empty;
        private string codeIdentifierStorage = string.Empty;

        /// <summary>
        /// Replaces the property descriptors for the tracking property.
        /// </summary>
		/// <remarks>
		/// Returned descriptors allow the properties to be reset with tracked value and resume tracking once modified.
		/// </remarks>
		internal PropertyDescriptorCollection ReplaceTrackingPropertyDescriptors(PropertyDescriptorCollection properties)
		{
			// Replace the existing descriptor for the DisplayName property
			DomainPropertyInfo displayNameProperty = this.Store.DomainDataDirectory.GetDomainProperty(NamedElementSchema.DisplayNameDomainPropertyId);
			DomainPropertyInfo displayNameTrackingProperty = this.Store.DomainDataDirectory.GetDomainProperty(NamedElementSchema.IsDisplayNameTrackingDomainPropertyId);
            var displayNameDescriptor = properties[Reflector<NamedElementSchema>.GetProperty(e => e.DisplayName).Name];
			if (displayNameDescriptor != null)
			{
				properties.Remove(displayNameDescriptor);
				properties.Add(new TrackingPropertyDescriptor(this, displayNameProperty, displayNameTrackingProperty, 
					displayNameDescriptor.Attributes.Cast<Attribute>().ToArray<Attribute>()));
			}

			// Replace the existing descriptor for the Description property
			DomainPropertyInfo descriptionProperty = this.Store.DomainDataDirectory.GetDomainProperty(NamedElementSchema.DescriptionDomainPropertyId);
			DomainPropertyInfo descriptionTrackingProperty = this.Store.DomainDataDirectory.GetDomainProperty(NamedElementSchema.IsDescriptionTrackingDomainPropertyId);
            var descriptionDescriptor = properties[Reflector<NamedElementSchema>.GetProperty(e => e.Description).Name];
			if (descriptionDescriptor != null)
			{
				properties.Remove(descriptionDescriptor);
				properties.Add(new TrackingPropertyDescriptor(this, descriptionProperty, descriptionTrackingProperty, 
					descriptionDescriptor.Attributes.Cast<Attribute>().ToArray<Attribute>()));
			}

			// Replace the existing descriptor for the CodeIdentifier property
			DomainPropertyInfo codeIdentifierProperty = this.Store.DomainDataDirectory.GetDomainProperty(NamedElementSchema.CodeIdentifierDomainPropertyId);
			DomainPropertyInfo codeIdentifierTrackingProperty = this.Store.DomainDataDirectory.GetDomainProperty(NamedElementSchema.IsCodeIdentifierTrackingDomainPropertyId);
            var codeIdentifierDescriptor = properties[Reflector<NamedElementSchema>.GetProperty(e => e.CodeIdentifier).Name];
			if (codeIdentifierDescriptor != null)
			{
				properties.Remove(codeIdentifierDescriptor);
				properties.Add(new TrackingPropertyDescriptor(this, codeIdentifierProperty, codeIdentifierTrackingProperty, 
					codeIdentifierDescriptor.Attributes.Cast<Attribute>().ToArray<Attribute>()));
			}

			return properties;
		}

        /// <summary>
        /// Gets the DisplayName property value.
        /// </summary>
        private string GetDisplayNameValue()
        {
            // Ensure we are not tracking
            if (this.IsDisplayNameTracking && !this.IsSerializing)
            {
				// *******************************************************************
				// Note to implementors:
				// You must provide this method, to return the calculated text when the property is tracked
				// Signature: 
				// public partial class NamedElementSchema
				// {
				//		/// <summary>
				//		/// Returns the calculated value of the DisplayName property while being tracked.
				//		/// </summary>
				//		private string CalculateDisplayNameTrackingValue()
				// }
				// *******************************************************************
                return this.CalculateDisplayNameTrackingValue();
            }

            return this.displayNameStorage;
        }
		
        /// <summary>
        /// Sets the DisplayName property value.
        /// </summary>
        private void SetDisplayNameValue(string value)
        {
            // Ensure not de-serializing
            bool isSerializing = this.Store.TransactionManager.InTransaction && this.Store.TransactionManager.CurrentTransaction.IsSerializing;

            // Set value of property
            this.displayNameStorage = value;

            // Turn off tracking
            if (!this.Store.InUndoRedoOrRollback && !isSerializing)
            {
                this.IsDisplayNameTracking = false;
            }
        }

		/// <summary>
        /// Customizes the DisplayName property handler.
        /// </summary>
        internal partial class IsDisplayNameTrackingPropertyHandler
        {
            /// <summary>
            /// Sets the value of the tracking property based on stored value of the DisplayName property.
            /// </summary>
            internal void ResetValue(NamedElementSchema element)
            {
                string calculatedValue = null;

                try
                {
                    calculatedValue = element.CalculateDisplayNameTrackingValue();
                }
                catch (NullReferenceException)
                {
                }
                catch (System.Exception e)
                {
                    if (ErrorHandler.IsCriticalException(e))
                    {
                        throw;
                    }
                }

                if (calculatedValue != null)
                {
                    if (string.Equals(element.DisplayName, calculatedValue, StringComparison.Ordinal)
                        || string.IsNullOrEmpty(element.DisplayName))
                    {
                        element.isDisplayNameTrackingPropertyStorage = true;
                    }
                }
            }

            /// <summary>
            /// Preset the value of the tracking property as it is not serialized.
            /// </summary>
            internal void PreResetValue(NamedElementSchema element)
            {
                // Force the tracking property to false so that the value
                // of the DisplayName property is retrieved from storage.
                element.isDisplayNameTrackingPropertyStorage = false;
            }

            /// <summary>
            /// Called after the IsDisplayNameTracking property changes.
            /// </summary>
            protected override void OnValueChanged(NamedElementSchema element, bool oldValue, bool newValue)
            {
                base.OnValueChanged(element, oldValue, newValue);
                if (!element.Store.InUndoRedoOrRollback && newValue)
                {
                    DomainPropertyInfo propInfo =
                        element.Store.DomainDataDirectory.GetDomainProperty(
                            NamedElementSchema.DisplayNameDomainPropertyId);
                    propInfo.NotifyValueChange(element);
                }
            }
        }

        /// <summary>
        /// Gets the Description property value.
        /// </summary>
        private string GetDescriptionValue()
        {
            // Ensure we are not tracking
            if (this.IsDescriptionTracking && !this.IsSerializing)
            {
				// *******************************************************************
				// Note to implementors:
				// You must provide this method, to return the calculated text when the property is tracked
				// Signature: 
				// public partial class NamedElementSchema
				// {
				//		/// <summary>
				//		/// Returns the calculated value of the Description property while being tracked.
				//		/// </summary>
				//		private string CalculateDescriptionTrackingValue()
				// }
				// *******************************************************************
                return this.CalculateDescriptionTrackingValue();
            }

            return this.descriptionStorage;
        }
		
        /// <summary>
        /// Sets the Description property value.
        /// </summary>
        private void SetDescriptionValue(string value)
        {
            // Ensure not de-serializing
            bool isSerializing = this.Store.TransactionManager.InTransaction && this.Store.TransactionManager.CurrentTransaction.IsSerializing;

            // Set value of property
            this.descriptionStorage = value;

            // Turn off tracking
            if (!this.Store.InUndoRedoOrRollback && !isSerializing)
            {
                this.IsDescriptionTracking = false;
            }
        }

		/// <summary>
        /// Customizes the Description property handler.
        /// </summary>
        internal partial class IsDescriptionTrackingPropertyHandler
        {
            /// <summary>
            /// Sets the value of the tracking property based on stored value of the Description property.
            /// </summary>
            internal void ResetValue(NamedElementSchema element)
            {
                string calculatedValue = null;

                try
                {
                    calculatedValue = element.CalculateDescriptionTrackingValue();
                }
                catch (NullReferenceException)
                {
                }
                catch (System.Exception e)
                {
                    if (ErrorHandler.IsCriticalException(e))
                    {
                        throw;
                    }
                }

                if (calculatedValue != null)
                {
                    if (string.Equals(element.Description, calculatedValue, StringComparison.Ordinal)
                        || string.IsNullOrEmpty(element.Description))
                    {
                        element.isDescriptionTrackingPropertyStorage = true;
                    }
                }
            }

            /// <summary>
            /// Preset the value of the tracking property as it is not serialized.
            /// </summary>
            internal void PreResetValue(NamedElementSchema element)
            {
                // Force the tracking property to false so that the value
                // of the Description property is retrieved from storage.
                element.isDescriptionTrackingPropertyStorage = false;
            }

            /// <summary>
            /// Called after the IsDescriptionTracking property changes.
            /// </summary>
            protected override void OnValueChanged(NamedElementSchema element, bool oldValue, bool newValue)
            {
                base.OnValueChanged(element, oldValue, newValue);
                if (!element.Store.InUndoRedoOrRollback && newValue)
                {
                    DomainPropertyInfo propInfo =
                        element.Store.DomainDataDirectory.GetDomainProperty(
                            NamedElementSchema.DescriptionDomainPropertyId);
                    propInfo.NotifyValueChange(element);
                }
            }
        }

        /// <summary>
        /// Gets the CodeIdentifier property value.
        /// </summary>
        private string GetCodeIdentifierValue()
        {
            // Ensure we are not tracking
            if (this.IsCodeIdentifierTracking && !this.IsSerializing)
            {
				// *******************************************************************
				// Note to implementors:
				// You must provide this method, to return the calculated text when the property is tracked
				// Signature: 
				// public partial class NamedElementSchema
				// {
				//		/// <summary>
				//		/// Returns the calculated value of the CodeIdentifier property while being tracked.
				//		/// </summary>
				//		private string CalculateCodeIdentifierTrackingValue()
				// }
				// *******************************************************************
                return this.CalculateCodeIdentifierTrackingValue();
            }

            return this.codeIdentifierStorage;
        }
		
        /// <summary>
        /// Sets the CodeIdentifier property value.
        /// </summary>
        private void SetCodeIdentifierValue(string value)
        {
            // Ensure not de-serializing
            bool isSerializing = this.Store.TransactionManager.InTransaction && this.Store.TransactionManager.CurrentTransaction.IsSerializing;

            // Set value of property
            this.codeIdentifierStorage = value;

            // Turn off tracking
            if (!this.Store.InUndoRedoOrRollback && !isSerializing)
            {
                this.IsCodeIdentifierTracking = false;
            }
        }

		/// <summary>
        /// Customizes the CodeIdentifier property handler.
        /// </summary>
        internal partial class IsCodeIdentifierTrackingPropertyHandler
        {
            /// <summary>
            /// Sets the value of the tracking property based on stored value of the CodeIdentifier property.
            /// </summary>
            internal void ResetValue(NamedElementSchema element)
            {
                string calculatedValue = null;

                try
                {
                    calculatedValue = element.CalculateCodeIdentifierTrackingValue();
                }
                catch (NullReferenceException)
                {
                }
                catch (System.Exception e)
                {
                    if (ErrorHandler.IsCriticalException(e))
                    {
                        throw;
                    }
                }

                if (calculatedValue != null)
                {
                    if (string.Equals(element.CodeIdentifier, calculatedValue, StringComparison.Ordinal)
                        || string.IsNullOrEmpty(element.CodeIdentifier))
                    {
                        element.isCodeIdentifierTrackingPropertyStorage = true;
                    }
                }
            }

            /// <summary>
            /// Preset the value of the tracking property as it is not serialized.
            /// </summary>
            internal void PreResetValue(NamedElementSchema element)
            {
                // Force the tracking property to false so that the value
                // of the CodeIdentifier property is retrieved from storage.
                element.isCodeIdentifierTrackingPropertyStorage = false;
            }

            /// <summary>
            /// Called after the IsCodeIdentifierTracking property changes.
            /// </summary>
            protected override void OnValueChanged(NamedElementSchema element, bool oldValue, bool newValue)
            {
                base.OnValueChanged(element, oldValue, newValue);
                if (!element.Store.InUndoRedoOrRollback && newValue)
                {
                    DomainPropertyInfo propInfo =
                        element.Store.DomainDataDirectory.GetDomainProperty(
                            NamedElementSchema.CodeIdentifierDomainPropertyId);
                    propInfo.NotifyValueChange(element);
                }
            }
        }

	}

}
