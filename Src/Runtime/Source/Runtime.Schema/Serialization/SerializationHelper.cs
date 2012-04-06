﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Validation;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
using DslModeling = global::Microsoft.VisualStudio.Modeling;

namespace Microsoft.VisualStudio.Patterning.Runtime.Schema
{
	public sealed partial class PatternModelSerializationHelper
	{
	
		/// <summary>
		/// Write an element as the root of XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="rootElement">Root element instance that will be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>
		public override void WriteRootElement(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement rootElement, global::System.Xml.XmlWriter writer)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert(serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException("serializationContext");
			global::System.Diagnostics.Debug.Assert(rootElement != null);
			if (rootElement == null)
				throw new global::System.ArgumentNullException("rootElement");
			global::System.Diagnostics.Debug.Assert(writer != null);
			if (writer == null)
				throw new global::System.ArgumentNullException("writer");
			#endregion
	
			DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(rootElement.Store);
	
			DslModeling::DomainClassXmlSerializer rootSerializer = null;
	
			if (rootElement is DslDiagrams::Diagram)
			{
				rootSerializer = directory.GetSerializer(PatternModelSchemaDiagram.DomainClassId);
			}
			else
			{
				rootSerializer = directory.GetSerializer(rootElement.GetDomainClass().Id);
			}
	
			global::System.Diagnostics.Debug.Assert(rootSerializer != null, "Cannot find serializer for " + rootElement.GetDomainClass().Name + "!");
	
			// Set up root element settings
			DslModeling::RootElementSettings rootElementSettings = new DslModeling::RootElementSettings();
			if (!(rootElement is DslDiagrams::Diagram))
			{
				// Only model has schema, diagram has no schema.
				rootElementSettings.SchemaTargetNamespace = "http://schemas.microsoft.com/visualstudio/patterning/runtime/patternmodel";
			}
			rootElementSettings.Version = new global::System.Version("1.2.0.0");
	
			// Carry out the normal serialization.
			rootSerializer.Write(serializationContext, rootElement, writer, rootElementSettings);
		}
	}
}
