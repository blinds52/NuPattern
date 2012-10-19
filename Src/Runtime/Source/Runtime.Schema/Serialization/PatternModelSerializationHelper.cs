﻿using System;
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
    /// <summary>
    /// Helper class for serializing and deserializing pattern models.
    /// </summary>
    public sealed partial class PatternModelSerializationHelper
    {
        private MemoryStream InternalSaveModel(DslModeling::SerializationResult serializationResult, PatternModelSchema modelRoot, string fileName, global::System.Text.Encoding encoding, bool writeOptionalPropertiesWithDefaultValue)
        {
            #region Check Parameters
            global::System.Diagnostics.Debug.Assert(serializationResult != null);
            global::System.Diagnostics.Debug.Assert(modelRoot != null);
            global::System.Diagnostics.Debug.Assert(!serializationResult.Failed);
            #endregion

            serializationResult.Encoding = encoding;

            DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(modelRoot.Store);


            global::System.IO.MemoryStream newFileContent = new global::System.IO.MemoryStream();

            DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, fileName, serializationResult);
            this.InitializeSerializationContext(modelRoot.Partition, serializationContext, false);
            // MonikerResolver shouldn't be required in Save operation, so not calling SetupMonikerResolver() here.
            serializationContext.WriteOptionalPropertiesWithDefaultValue = writeOptionalPropertiesWithDefaultValue;
            global::System.Xml.XmlWriterSettings settings = PatternModelSerializationHelper.Instance.CreateXmlWriterSettings(serializationContext, false, encoding);
            using (global::System.Xml.XmlWriter writer = global::System.Xml.XmlWriter.Create(newFileContent, settings))
            {
                this.WriteRootElement(serializationContext, modelRoot, writer);
            }

            return newFileContent;
        }

        private global::System.IO.MemoryStream InternalSaveDiagram(DslModeling::SerializationResult serializationResult, PatternModelSchemaDiagram diagram, string diagramFileName, global::System.Text.Encoding encoding, bool writeOptionalPropertiesWithDefaultValue)
        {
            #region Check Parameters
            global::System.Diagnostics.Debug.Assert(serializationResult != null);
            global::System.Diagnostics.Debug.Assert(diagram != null);
            global::System.Diagnostics.Debug.Assert(!serializationResult.Failed);
            #endregion

            DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(diagram.Store);


            global::System.IO.MemoryStream newFileContent = new global::System.IO.MemoryStream();

            DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, diagramFileName, serializationResult);
            this.InitializeSerializationContext(diagram.Partition, serializationContext, false);
            // MonikerResolver shouldn't be required in Save operation, so not calling SetupMonikerResolver() here.
            serializationContext.WriteOptionalPropertiesWithDefaultValue = writeOptionalPropertiesWithDefaultValue;
            global::System.Xml.XmlWriterSettings settings = PatternModelSerializationHelper.Instance.CreateXmlWriterSettings(serializationContext, true, encoding);
            using (global::System.Xml.XmlWriter writer = global::System.Xml.XmlWriter.Create(newFileContent, settings))
            {
                this.WriteRootElement(serializationContext, diagram, writer);
            }

            return newFileContent;
        }

        /// <summary>
        /// Read an element from the root of XML.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="rootElement">In-memory element instance that will get the deserialized data.</param>
        /// <param name="reader">XmlReader to read serialized data from.</param>
        /// <param name="schemaResolver">An ISchemaResolver that allows the serializer to do schema validation on the root element (and everything inside it).</param>
        protected override void ReadRootElement(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement rootElement, global::System.Xml.XmlReader reader, DslModeling::ISchemaResolver schemaResolver)
        {
            #region Check Parameters
            global::System.Diagnostics.Debug.Assert(serializationContext != null);
            if (serializationContext == null)
                throw new global::System.ArgumentNullException("serializationContext");
            global::System.Diagnostics.Debug.Assert(rootElement != null);
            if (rootElement == null)
                throw new global::System.ArgumentNullException("rootElement");
            global::System.Diagnostics.Debug.Assert(reader != null);
            if (reader == null)
                throw new global::System.ArgumentNullException("reader");
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

            // Version check.
            this.CheckVersion(serializationContext, reader);

            if (!serializationContext.Result.Failed)
            {
                // Use a validating reader if possible
                using (reader = TryCreateValidatingReader(schemaResolver, reader, serializationContext))
                {
                    rootSerializer.Read(serializationContext, rootElement, reader);
                }
            }

        }
        /// <summary>
        /// Loads the model from a filename.
        /// </summary>
        /// <param name="serializationResult">The seriazation result.</param>
        /// <param name="partition">The state partition.</param>
        /// <param name="fileName">the filename of the model.</param>
        /// <param name="schemaResolver">The schemaresolver.</param>
        /// <param name="validationController">The validation controller.</param>
        /// <param name="serializerLocator">The serialization locator.</param>
        /// <remarks>This overload is called by teh T4Runner engine.</remarks>
        public override PatternModelSchema LoadModel(SerializationResult serializationResult, Partition partition, string fileName, ISchemaResolver schemaResolver, ValidationController validationController, ISerializerLocator serializerLocator)
        {
            var productLine = base.LoadModel(serializationResult, partition, fileName, schemaResolver, validationController, serializerLocator);

            // Set tracking properties
            if (partition != null)
            {
                ResetTrackingProperties(partition.Store);
            }

            return productLine;
        }

        /// <summary>
        /// Load the model from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="schemaResolver">The schema resolver.</param>
        /// <param name="serializerLocator">The serializer locator.</param>
        /// <remarks>This overload is called by the runtime environment when deserializing with no diagram.</remarks>
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "DSL")]
        public PatternModelSchema LoadModel(Store store, Stream stream, ISchemaResolver schemaResolver, ISerializerLocator serializerLocator)
        {
            Guard.NotNull(() => store, store);
            Guard.NotNull(() => stream, stream);

            if (!store.DefaultPartition.Store.TransactionActive)
            {
                throw new InvalidOperationException(PatternModelDomainModel.SingletonResourceManager.GetString("MissingTransaction"));
            }

            var directory = this.GetDirectory(store.DefaultPartition.Store);
            var modelRootSerializer = directory.GetSerializer(PatternModelSchema.DomainClassId);
            var serializationResult = new SerializationResult();

            Debug.Assert(modelRootSerializer != null, "Cannot find serializer for ProductLine!");

            if (modelRootSerializer != null)
            {
                PatternModelSchema modelRoot = null;

                var serializationContext = new SerializationContext(directory, string.Empty, serializationResult);
                this.InitializeSerializationContext(store.DefaultPartition, serializationContext, true);

                var transactionContext = new TransactionContext();
                transactionContext.Add(SerializationContext.TransactionContextKey, serializationContext);

                using (var tx = store.DefaultPartition.Store.TransactionManager.BeginTransaction("Loading Model", true, transactionContext))
                {
                    try
                    {
                        var settings = PatternModelSerializationHelper.Instance.CreateXmlReaderSettings(serializationContext, false);

                        using (var reader = XmlReader.Create(stream, settings))
                        {
                            reader.Read();
                            Encoding encoding;
                            if (this.TryGetEncoding(reader, out encoding))
                            {
                                serializationResult.Encoding = encoding;
                            }

                            SerializationUtilities.ResolveDomainModels(reader, serializerLocator, store.DefaultPartition.Store);

                            reader.MoveToContent();

                            modelRoot = modelRootSerializer.TryCreateInstance(serializationContext, reader, store.DefaultPartition) as PatternModelSchema;

                            if (modelRoot != null && !serializationResult.Failed)
                            {
                                this.ReadRootElement(serializationContext, modelRoot, reader, schemaResolver);
                            }
                        }
                    }
                    catch (XmlException ex)
                    {
                        SerializationUtilities.AddMessage(serializationContext, SerializationMessageKind.Error, ex);
                    }

                    if (modelRoot == null && !serializationResult.Failed)
                    {
                        modelRoot = this.CreateModelHelper(store.DefaultPartition);
                    }

                    if (tx.IsActive)
                    {
                        tx.Commit();
                    }
                }

                // Set tracking properties
                ResetTrackingProperties(store);

                return modelRoot;
            }

            return null;
        }

        /// <summary>
        /// Saves the model.
        /// </summary>
        /// <param name="modelRoot">The model root.</param>
        /// <param name="stream">The stream.</param>
        public void SaveModel(PatternModelSchema modelRoot, Stream stream)
        {
            Guard.NotNull(() => modelRoot, modelRoot);
            Guard.NotNull(() => stream, stream);

            var context = new SerializationContext(GetDirectory(modelRoot.Store));

            this.InitializeSerializationContext(modelRoot.Partition, context, false);

            var settings = CreateXmlWriterSettings(context, false, Encoding.UTF8);
            using (var writer = XmlWriter.Create(stream, settings))
            {
                this.WriteRootElement(context, modelRoot, writer);
            }
        }

        /// <summary>
        /// Loads the model and diagrams.
        /// </summary>
        /// <param name="serializationResult">The serialization result.</param>
        /// <param name="modelPartition">The model partition.</param>
        /// <param name="modelFileName">Name of the model file.</param>
        /// <param name="diagramPartition">The diagram partition.</param>
        /// <param name="diagramFileNames">The diagram file names.</param>
        /// <param name="schemaResolver">The schema resolver.</param>
        /// <param name="validationController">The validation controller.</param>
        /// <param name="serializerLocator">The serializer locator.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "DSL")]
        public PatternModelSchema LoadModelAndDiagrams(
            SerializationResult serializationResult,
            Partition modelPartition,
            string modelFileName,
            Partition diagramPartition,
            IEnumerable<string> diagramFileNames,
            ISchemaResolver schemaResolver,
            ValidationController validationController,
            ISerializerLocator serializerLocator)
        {
            Guard.NotNull(() => serializationResult, serializationResult);
            Guard.NotNull(() => modelPartition, modelPartition);
            Guard.NotNullOrEmpty(() => modelFileName, modelFileName);
            Guard.NotNull(() => diagramPartition, diagramPartition);
            Guard.NotNull(() => diagramFileNames, diagramFileNames);
            Guard.NotNull(() => schemaResolver, schemaResolver);
            Guard.NotNull(() => serializerLocator, serializerLocator);

            PatternModelSchema modelRoot;

            if (!diagramPartition.Store.TransactionActive)
            {
                throw new InvalidOperationException(PatternModelDomainModel.SingletonResourceManager.GetString("MissingTransaction"));
            }

            modelRoot = this.LoadModel(serializationResult, modelPartition, modelFileName, schemaResolver, validationController, serializerLocator);

            if (serializationResult.Failed)
            {
                // don't try to deserialize diagram data if model load failed.
                return modelRoot;
            }

            var directory = this.GetDirectory(diagramPartition.Store);
            var diagramSerializer = directory.GetSerializer(PatternModelSchemaDiagram.DomainClassId);
            var views = modelRoot.Store.ElementDirectory.AllElements.OfType<ViewSchema>().ToList();

            foreach (var view in views)
            {
                var diagramFileName = diagramFileNames.FirstOrDefault(file => Path.GetFileNameWithoutExtension(file).Contains(view.DiagramId));

                if (diagramFileName == null)
                {
                    PatternModelSerializationHelper.CreatePatternModelSchemaDiagram(serializationResult, diagramPartition, modelRoot, view.DiagramId);
                }
                else
                {
                    this.LoadDiagram(serializationResult, diagramPartition, modelRoot, directory, diagramSerializer, diagramFileName, schemaResolver, validationController);
                }
            }

            // Set tracking properties
            ResetTrackingProperties(modelPartition.Store);

            return modelRoot;
        }

        /// <summary>
        /// Saves the model and diagrams.
        /// </summary>
        /// <param name="serializationResult">The serialization result.</param>
        /// <param name="modelRoot">The model root.</param>
        /// <param name="modelFileName">Name of the model file.</param>
        /// <param name="diagrams">The diagrams.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="writeOptionalPropertiesWithDefaultValue">If set to <c>true</c> [write optional properties with default value].</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "NotApplicable")]
        public void SaveModelAndDiagrams(
            SerializationResult serializationResult,
            PatternModelSchema modelRoot,
            string modelFileName,
            Dictionary<string, PatternModelSchemaDiagram> diagrams,
            Encoding encoding,
            bool writeOptionalPropertiesWithDefaultValue)
        {
            Guard.NotNull(() => serializationResult, serializationResult);
            Guard.NotNull(() => modelRoot, modelRoot);
            Guard.NotNullOrEmpty(() => modelFileName, modelFileName);
            Guard.NotNull(() => diagrams, diagrams);
            Guard.NotNull(() => encoding, encoding);

            if (serializationResult.Failed)
            {
                return;
            }

            using (MemoryStream modelFileContent =
                this.InternalSaveModel(serializationResult, modelRoot, modelFileName, encoding, writeOptionalPropertiesWithDefaultValue))
            {
                if (serializationResult.Failed)
                {
                    return;
                }

                foreach (var diagram in diagrams)
                {
                    using (MemoryStream diagramFileContent =
                        this.InternalSaveDiagram(serializationResult, diagram.Value, diagram.Key, encoding, writeOptionalPropertiesWithDefaultValue))
                    {
                        if (!serializationResult.Failed)
                        {
                            if (modelFileContent != null)
                            {
                                using (FileStream fileStream = new FileStream(modelFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                                {
                                    using (BinaryWriter writer = new BinaryWriter(fileStream, encoding))
                                    {
                                        writer.Write(modelFileContent.ToArray());
                                    }
                                }
                            }

                            if (diagramFileContent != null)
                            {
                                using (FileStream fileStream = new FileStream(diagram.Key, FileMode.Create, FileAccess.Write, FileShare.None))
                                {
                                    using (BinaryWriter writer = new BinaryWriter(fileStream, encoding))
                                    {
                                        writer.Write(diagramFileContent.ToArray());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates the diagram.
        /// </summary>
        /// <param name="serializationResult">The serialization result.</param>
        /// <param name="diagramPartition">The diagram partition.</param>
        /// <param name="modelRoot">The model root.</param>
        /// <param name="diagramId">The diagram id.</param>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "NotApplicable")]
        internal static PatternModelSchemaDiagram CreatePatternModelSchemaDiagram(SerializationResult serializationResult, Partition diagramPartition, PatternModelSchema modelRoot, string diagramId)
        {
            var diagram = new PatternModelSchemaDiagram(
                diagramPartition.Store,
                new PropertyAssignment(Diagram.NameDomainPropertyId, diagramId),
                new PropertyAssignment(
                    ElementFactory.IdPropertyAssignment,
                    !string.IsNullOrEmpty(diagramId) ? new Guid(diagramId) : Guid.NewGuid()));

            diagram.ModelElement = modelRoot;
            diagram.PostDeserialization(true);
            DoCheckForOrphanedShapes(diagram, serializationResult);

            return diagram;
        }

        /// <summary>
        /// Does the check for orphaned shapes.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        /// <param name="serializationResult">The serialization result.</param>
        internal static void DoCheckForOrphanedShapes(Diagram diagram, SerializationResult serializationResult)
        {
            PatternModelSerializationHelper.Instance.CheckForOrphanedShapes(diagram, serializationResult);
        }

        /// <summary>
        /// Write extension element data inside the current XML element.
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="element">The element whose attributes have just been written.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <remarks>The default implemenation is to write out all non-embedded extension elements,
        /// regardless of whether they relate to the current element or not.
        /// The additional data should be written as a series of one or more
        /// XML elements.</remarks>
        protected internal override void WriteExtensions(SerializationContext serializationContext, ModelElement element, XmlWriter writer)
        {
            Guard.NotNull(() => serializationContext, serializationContext);
            Guard.NotNull(() => element, element);
            Guard.NotNull(() => writer, writer);

            if (!(element is PatternModelSchemaDiagram))
            {
                var allExtensionElements = element.Partition.ElementDirectory.FindElements(ExtensionElement.DomainClassId, true);
                var nonEmbeddedExtensionsElements =
                    allExtensionElements.Where(e => DomainClassInfo.FindEmbeddingElementLink(e) == null).OfType<ExtensionElement>();

                SerializationUtilities.WriteExtensions(serializationContext, writer, nonEmbeddedExtensionsElements);
            }
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "NotApplicable")]
        private void LoadDiagram(
            SerializationResult serializationResult,
            Partition diagramPartition,
            PatternModelSchema modelRoot,
            DomainXmlSerializerDirectory directory,
            DomainClassXmlSerializer diagramSerializer,
            string diagramFileName,
            ISchemaResolver schemaResolver,
            ValidationController validationController)
        {
            if (diagramSerializer != null)
            {
                PatternModelSchemaDiagram diagram = null;

                using (FileStream fileStream = File.OpenRead(diagramFileName))
                {
                    var serializationContext = new SerializationContext(directory, fileStream.Name, serializationResult);
                    this.InitializeSerializationContext(diagramPartition, serializationContext, true);
                    var transactionContext = new TransactionContext();
                    transactionContext.Add(SerializationContext.TransactionContextKey, serializationContext);

                    using (var transaction = diagramPartition.Store.TransactionManager.BeginTransaction("LoadDiagram", true, transactionContext))
                    {
                        // Ensure there is some content in the file. Blank (or almost blank, to account for encoding header bytes, etc.)
                        // files will cause a new diagram to be created and returned 
                        if (fileStream.Length > 5)
                        {
                            var settings = PatternModelSerializationHelper.Instance.CreateXmlReaderSettings(serializationContext, false);
                            try
                            {
                                using (var reader = XmlReader.Create(fileStream, settings))
                                {
                                    reader.MoveToContent();
                                    diagram = diagramSerializer.TryCreateInstance(serializationContext, reader, diagramPartition) as PatternModelSchemaDiagram;
                                    if (diagram != null)
                                    {
                                        this.ReadRootElement(serializationContext, diagram, reader, schemaResolver);
                                    }
                                }
                            }
                            catch (XmlException ex)
                            {
                                SerializationUtilities.AddMessage(serializationContext, SerializationMessageKind.Error, ex);
                            }

                            if (serializationResult.Failed)
                            {
                                // Serialization error encountered, rollback the transaction.
                                diagram = null;
                                transaction.Rollback();
                            }
                        }

                        if (diagram == null && !serializationResult.Failed)
                        {
                            // Create diagram if it doesn't exist
                            if (diagramFileName.EndsWith(DesignerConstants.DiagramFileExtension, StringComparison.OrdinalIgnoreCase))
                            {
                                diagram = new PatternModelSchemaDiagram(
                                    diagramPartition.Store,
                                    new PropertyAssignment(Diagram.NameDomainPropertyId, Guid.NewGuid()));
                            }
                            else
                            {
                                diagram = this.CreateDiagramHelper(diagramPartition, modelRoot);
                            }
                        }

                        if (transaction.IsActive)
                        {
                            transaction.Commit();
                        }
                    } // End inner Tx

                    // Do load-time validation if a ValidationController is provided.
                    if (!serializationResult.Failed && validationController != null)
                    {
                        using (new SerializationValidationObserver(serializationResult, validationController))
                        {
                            validationController.Validate(diagramPartition, ValidationCategories.Load);
                        }
                    }
                }

                if (diagram != null)
                {
                    if (!serializationResult.Failed)
                    {	// Succeeded.
                        diagram.ModelElement = modelRoot;
                        diagram.PostDeserialization(true);
                        this.CheckForOrphanedShapes(diagram, serializationResult);
                    }
                    else
                    {	// Failed.
                        diagram.PostDeserialization(false);
                    }
                }
            }
        }
    }
}