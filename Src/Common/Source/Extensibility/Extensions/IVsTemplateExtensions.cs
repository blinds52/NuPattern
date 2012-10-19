﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features.VsTemplateSchema;

namespace Microsoft.VisualStudio.Patterning.Extensibility
{
    /// <summary>
    /// IVsTemplate extension methods.
    /// </summary>
    public static class IVsTemplateExtensions
    {
        /// <summary>
        /// Removes a Wizard Extension if it exists.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="templateExtensionType">Type of the template extension to remove.</param>
        [CLSCompliant(false)]
        public static void RemoveWizardExtension(this IVsTemplate template, Type templateExtensionType)
        {
            Guard.NotNull(() => template, template);
            Guard.NotNull(() => templateExtensionType, templateExtensionType);
            Guard.OfType(() => template, template, typeof(VSTemplate));

            var temp = (VSTemplate)template;

            if (temp.WizardExtension == null)
            {
                return;
            }
            else
            {
                var extensionToRemove = temp.WizardExtension.FirstOrDefault(ext =>
                    (ext.Assembly[0] as XmlNode[])[0].Value.Contains(templateExtensionType.Assembly.GetName().Name) &&
                    (ext.FullClassName[0] as XmlNode[])[0].Value.Contains(templateExtensionType.Name));
                if (extensionToRemove != null)
                {
                    var existingExtensions = temp.WizardExtension.Except(new[] { extensionToRemove }).ToArray();
                    temp.WizardExtension = existingExtensions;
                    VsTemplateFile.Write(template);
                }
            }
        }

        /// <summary>
        /// Sets the wizard extension.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="templateExtensionType">Type of the template extension.</param>
        [CLSCompliant(false)]
        public static void AddWizardExtension(this IVsTemplate template, Type templateExtensionType)
        {
            Guard.NotNull(() => template, template);
            Guard.NotNull(() => templateExtensionType, templateExtensionType);
            Guard.OfType(() => template, template, typeof(VSTemplate));

            var temp = (VSTemplate)template;
            var doc = new XmlDocument();

            var assemblyPartialName = string.Format("{0}, PublicKeyToken={1}",
                templateExtensionType.Assembly.GetName().Name,
                templateExtensionType.Assembly.GetName().GetPublicKeyTokenString());

            var newExtension = new VSTemplateWizardExtension[]
			{
				new VSTemplateWizardExtension
				{
					Assembly = new[] { new XmlNode[] { doc.CreateTextNode(assemblyPartialName) } },
					FullClassName = new[] { new XmlNode[] { doc.CreateTextNode(templateExtensionType.FullName) } }
				}
			};

            if (temp.WizardExtension == null)
            {
                temp.WizardExtension = newExtension;
                VsTemplateFile.Write(template);
            }
            else
            {
                if (temp.WizardExtension.GetExtension(templateExtensionType) == null)
                {
                    if (temp.WizardExtension.Any(ext =>
                        (ext.Assembly[0] as XmlNode[])[0].Value.Contains(templateExtensionType.Assembly.GetName().Name) &&
                        (ext.FullClassName[0] as XmlNode[])[0].Value.Contains(templateExtensionType.Name)))
                    {
                        RemoveWizardExtension(template, templateExtensionType);
                    }

                    var existingExtensions = temp.WizardExtension;

                    temp.WizardExtension = existingExtensions.Concat(newExtension).ToArray();
                    VsTemplateFile.Write(template);
                }
            }
        }

        /// <summary>
        /// Returns an <see cref="IVsTemplateWizardExtension"/> of the appropriate type, if present
        /// </summary>
        /// <param name="extensions">The collection of extensions in the template</param>
        /// <param name="extensionType">The type of the extension to return</param>
        /// <returns>If a wizard extension of the appropriate type exists, returns the <see cref="IVsTemplateWizardExtension"/> for that wizard. Returns null if it doesn't exist.</returns>
        [CLSCompliant(false)]
        public static IVsTemplateWizardExtension GetExtension(this IEnumerable<IVsTemplateWizardExtension> extensions, Type extensionType)
        {
            //return extensions.FirstOrDefault(ext => ext.Assembly.Equals(extensionType.Assembly.GetName().ToString()) && ext.FullClassName.Equals(extensionType.ToString()));
            return extensions.FirstOrDefault(ext =>
                ext.Assembly.StartsWith(extensionType.Assembly.GetName().Name)
                && ext.Assembly.EndsWith(string.Format(CultureInfo.CurrentCulture, "PublicKeyToken={0}", extensionType.Assembly.GetName().GetPublicKeyTokenString()))
                && ext.FullClassName.Equals(extensionType.ToString()));
        }

        /// <summary>
        /// Sets the TemplateID.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="templateId">New value for TemplateID.</param>
        [CLSCompliant(false)]
        public static void SetTemplateId(this IVsTemplate template, string templateId)
        {
            Guard.NotNull(() => template, template);
            Guard.OfType(() => template, template, typeof(VSTemplate));

            var temp = (VSTemplate)template;

            temp.TemplateData.TemplateID = templateId;
        }

        /// <summary>
        /// Sets the Template Description.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="description">New value for the Description.</param>
        [CLSCompliant(false)]
        public static void SetDescription(this IVsTemplate template, string description)
        {
            Guard.NotNull(() => template, template);
            Guard.OfType(() => template, template, typeof(VSTemplate));

            var temp = (VSTemplate)template;

            temp.TemplateData.Description.Value = description;
        }

        /// <summary>
        /// Sets the Template Name.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="name">New value for the Name.</param>
        [CLSCompliant(false)]
        public static void SetName(this IVsTemplate template, string name)
        {
            Guard.NotNull(() => template, template);
            Guard.OfType(() => template, template, typeof(VSTemplate));

            var temp = (VSTemplate)template;

            temp.TemplateData.Name.Value = name;
        }

        /// <summary>
        /// Sets the Template Default Name.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="defaultName">New value for the Default Name.</param>
        [CLSCompliant(false)]
        public static void SetDefaultName(this IVsTemplate template, string defaultName)
        {
            Guard.NotNull(() => template, template);
            Guard.OfType(() => template, template, typeof(VSTemplate));

            var temp = (VSTemplate)template;

            temp.TemplateData.DefaultName = defaultName;
        }

        /// <summary>
        /// Sets the Template Hidden.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="hidden">New value for the Hidden.</param>
        [CLSCompliant(false)]
        public static void SetHidden(this IVsTemplate template, bool hidden)
        {
            Guard.NotNull(() => template, template);
            Guard.OfType(() => template, template, typeof(VSTemplate));

            var temp = (VSTemplate)template;

            temp.TemplateData.HiddenSpecified = hidden;
            temp.TemplateData.Hidden = hidden;
            VsTemplateFile.Write(temp);
        }

        /// <summary>
        /// Sets Wizard Data avoiding duplicated.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="name">Name for the Datum.</param>
        /// <param name="value">Value for the Datum.</param>
        [CLSCompliant(false)]
        public static void SetWizardData(this IVsTemplate template, string name, string value)
        {
            Guard.NotNull(() => template, template);
            Guard.NotNull(() => name, name);
            Guard.NotNull(() => value, value);
            Guard.OfType(() => template, template, typeof(VSTemplate));

            var temp = (VSTemplate)template;

            var doc = new XmlDocument();
            var dataElement = doc.CreateElement(name, "http://schemas.microsoft.com/developer/vstemplate/2005");
            dataElement.InnerText = value;

            var newData = new VSTemplateWizardData[]
			{
				new VSTemplateWizardData
				{
                    Any = new[] { dataElement }
				}
			};

            if (temp.WizardData == null)
            {
                temp.WizardData = newData;
                VsTemplateFile.Write(template);
            }
            else if (!temp.WizardData.Any(ext =>
                        ext.Any.Count(e => e.Name == name && e.InnerText == value) > 0))
            {
                var existingData = temp.WizardData;

                temp.WizardData[0].Any = existingData[0].Any.Concat(new[] { dataElement }).ToArray();
                VsTemplateFile.Write(template);
            }
        }

        /// <summary>
        /// Returns the public key token as a string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetPublicKeyTokenString(this AssemblyName name)
        {
            Guard.NotNull(() => name, name);

            return name.GetPublicKeyToken().Select(x => x.ToString("x2")).Aggregate((x, y) => x + y);
        }
    }
}