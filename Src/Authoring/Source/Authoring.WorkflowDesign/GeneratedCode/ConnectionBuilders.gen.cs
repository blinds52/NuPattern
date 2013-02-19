﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;

namespace NuPattern.Authoring.WorkflowDesign
{
	/// <summary>
	/// ConnectionBuilder class to provide logic for constructing connections between elements.
	/// </summary>
	public static partial class ProductionWorkflow
	{
		#region Accept Connection Methods
		/// <summary>
		/// Test whether a given model element is acceptable to this ConnectionBuilder as the source of a connection.
		/// </summary>
		/// <param name="candidate">The model element to test.</param>
		/// <returns>Whether the element can be used as the source of a connection.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		public static bool CanAcceptSource(DslModeling::ModelElement candidate)
		{
			if (candidate == null) return false;
			else if (candidate is global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset)
			{ 
				return true;
			}
			else if (candidate is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
			{ 
				return true;
			}
			else if (candidate is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
			{ 
				return true;
			}
			else
				return false;
		}

		/// <summary>
		/// Test whether a given model element is acceptable to this ConnectionBuilder as the target of a connection.
		/// </summary>
		/// <param name="candidate">The model element to test.</param>
		/// <returns>Whether the element can be used as the target of a connection.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		public static bool CanAcceptTarget(DslModeling::ModelElement candidate)
		{
			if (candidate == null) return false;
			else if (candidate is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
			{ 
				return true;
			}
			else if (candidate is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
			{ 
				return true;
			}
			else if (candidate is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
			{ 
				return true;
			}
			else if (candidate is global::NuPattern.Authoring.WorkflowDesign.VariabilityRequirement)
			{ 
				return true;
			}
			else if (candidate is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
			{ 
				return true;
			}
			else
				return false;
		}
		
		/// <summary>
		/// Test whether a given pair of model elements are acceptable to this ConnectionBuilder as the source and target of a connection
		/// </summary>
		/// <param name="candidateSource">The model element to test as a source</param>
		/// <param name="candidateTarget">The model element to test as a target</param>
		/// <returns>Whether the elements can be used as the source and target of a connection</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		public static bool CanAcceptSourceAndTarget(DslModeling::ModelElement candidateSource, DslModeling::ModelElement candidateTarget)
		{
			// Accepts null, null; source, null; source, target but NOT null, target
			if (candidateSource == null)
			{
				if (candidateTarget != null)
				{
					throw new global::System.ArgumentNullException("candidateSource");
				}
				else // Both null
				{
					return false;
				}
			}
			bool acceptSource = CanAcceptSource(candidateSource);
			// If the source wasn't accepted then there's no point checking targets.
			// If there is no target then the source controls the accept.
			if (!acceptSource || candidateTarget == null)
			{
				return acceptSource;
			}
			else // Check combinations
			{
				if (candidateSource is global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset)
				{
					if (candidateTarget is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
					{
						global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset sourceSuppliedAsset = (global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset)candidateSource;
						global::NuPattern.Authoring.WorkflowDesign.ProducedAsset targetProducedAsset = (global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)candidateTarget;
						if(targetProducedAsset == null || sourceSuppliedAsset == null || global::NuPattern.Authoring.WorkflowDesign.SuppliedAssetCopiesToProducedAssets.GetLinks(sourceSuppliedAsset, targetProducedAsset).Count > 0) return false;
						return true;
					}
					else if (candidateTarget is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
					{
						global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset sourceSuppliedAsset = (global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset)candidateSource;
						global::NuPattern.Authoring.WorkflowDesign.ProductionTool targetProductionTool = (global::NuPattern.Authoring.WorkflowDesign.ProductionTool)candidateTarget;
						if(targetProductionTool == null || sourceSuppliedAsset == null || global::NuPattern.Authoring.WorkflowDesign.SuppliedAssetSuppliesProductionTools.GetLinks(sourceSuppliedAsset, targetProductionTool).Count > 0) return false;
						return true;
					}
				}
				if (candidateSource is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
				{
					if (candidateTarget is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
					{
						global::NuPattern.Authoring.WorkflowDesign.ProducedAsset sourceProducedAsset = (global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)candidateSource;
						global::NuPattern.Authoring.WorkflowDesign.ProductionTool targetProductionTool = (global::NuPattern.Authoring.WorkflowDesign.ProductionTool)candidateTarget;
						if(targetProductionTool == null || sourceProducedAsset == null || global::NuPattern.Authoring.WorkflowDesign.ProducedAssetSuppliesProductionTools.GetLinks(sourceProducedAsset, targetProductionTool).Count > 0) return false;
						return true;
					}
				}
				if (candidateSource is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
				{
					if (candidateTarget is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
					{
						global::NuPattern.Authoring.WorkflowDesign.ProductionTool sourceProductionTool = (global::NuPattern.Authoring.WorkflowDesign.ProductionTool)candidateSource;
						global::NuPattern.Authoring.WorkflowDesign.ProducedAsset targetProducedAsset = (global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)candidateTarget;
						if(targetProducedAsset == null || sourceProductionTool == null || global::NuPattern.Authoring.WorkflowDesign.ProductionToolProducesProducedAssets.GetLinks(sourceProductionTool, targetProducedAsset).Count > 0) return false;
						return true;
					}
					else if (candidateTarget is global::NuPattern.Authoring.WorkflowDesign.VariabilityRequirement)
					{
						global::NuPattern.Authoring.WorkflowDesign.ProductionTool sourceProductionTool = (global::NuPattern.Authoring.WorkflowDesign.ProductionTool)candidateSource;
						global::NuPattern.Authoring.WorkflowDesign.VariabilityRequirement targetVariabilityRequirement = (global::NuPattern.Authoring.WorkflowDesign.VariabilityRequirement)candidateTarget;
						if(targetVariabilityRequirement == null || sourceProductionTool == null || global::NuPattern.Authoring.WorkflowDesign.ProductionToolReferencesVariabilityRequirements.GetLinks(sourceProductionTool, targetVariabilityRequirement).Count > 0) return false;
						return true;
					}
				}
				
			}
			return false;
		}
		#endregion

		#region Connection Methods
		/// <summary>
		/// Make a connection between the given pair of source and target elements
		/// </summary>
		/// <param name="source">The model element to use as the source of the connection</param>
		/// <param name="target">The model element to use as the target of the connection</param>
		/// <returns>A link representing the created connection</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		public static DslModeling::ElementLink Connect(DslModeling::ModelElement source, DslModeling::ModelElement target)
		{
			if (source == null)
			{
				throw new global::System.ArgumentNullException("source");
			}
			if (target == null)
			{
				throw new global::System.ArgumentNullException("target");
			}
			
			if (CanAcceptSourceAndTarget(source, target))
			{
				if (source is global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset)
				{
					if (target is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
					{
						global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset sourceAccepted = (global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset)source;
						global::NuPattern.Authoring.WorkflowDesign.ProducedAsset targetAccepted = (global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)target;
						DslModeling::ElementLink result = new global::NuPattern.Authoring.WorkflowDesign.SuppliedAssetCopiesToProducedAssets(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
					else if (target is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
					{
						global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset sourceAccepted = (global::NuPattern.Authoring.WorkflowDesign.SuppliedAsset)source;
						global::NuPattern.Authoring.WorkflowDesign.ProductionTool targetAccepted = (global::NuPattern.Authoring.WorkflowDesign.ProductionTool)target;
						DslModeling::ElementLink result = new global::NuPattern.Authoring.WorkflowDesign.SuppliedAssetSuppliesProductionTools(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
				}
				if (source is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
				{
					if (target is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
					{
						global::NuPattern.Authoring.WorkflowDesign.ProducedAsset sourceAccepted = (global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)source;
						global::NuPattern.Authoring.WorkflowDesign.ProductionTool targetAccepted = (global::NuPattern.Authoring.WorkflowDesign.ProductionTool)target;
						DslModeling::ElementLink result = new global::NuPattern.Authoring.WorkflowDesign.ProducedAssetSuppliesProductionTools(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
				}
				if (source is global::NuPattern.Authoring.WorkflowDesign.ProductionTool)
				{
					if (target is global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)
					{
						global::NuPattern.Authoring.WorkflowDesign.ProductionTool sourceAccepted = (global::NuPattern.Authoring.WorkflowDesign.ProductionTool)source;
						global::NuPattern.Authoring.WorkflowDesign.ProducedAsset targetAccepted = (global::NuPattern.Authoring.WorkflowDesign.ProducedAsset)target;
						DslModeling::ElementLink result = new global::NuPattern.Authoring.WorkflowDesign.ProductionToolProducesProducedAssets(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
					else if (target is global::NuPattern.Authoring.WorkflowDesign.VariabilityRequirement)
					{
						global::NuPattern.Authoring.WorkflowDesign.ProductionTool sourceAccepted = (global::NuPattern.Authoring.WorkflowDesign.ProductionTool)source;
						global::NuPattern.Authoring.WorkflowDesign.VariabilityRequirement targetAccepted = (global::NuPattern.Authoring.WorkflowDesign.VariabilityRequirement)target;
						DslModeling::ElementLink result = new global::NuPattern.Authoring.WorkflowDesign.ProductionToolReferencesVariabilityRequirements(sourceAccepted, targetAccepted);
						if (DslModeling::DomainClassInfo.HasNameProperty(result))
						{
							DslModeling::DomainClassInfo.SetUniqueName(result);
						}
						return result;
					}
				}
				
			}
			global::System.Diagnostics.Debug.Fail("Having agreed that the connection can be accepted we should never fail to make one.");
			throw new global::System.InvalidOperationException();
		}
		#endregion
 	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class SuppliedAssetCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new SuppliedAssetCreateAction for the given Diagram.
		/// </summary>
		public SuppliedAssetCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class ProductionToolCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new ProductionToolCreateAction for the given Diagram.
		/// </summary>
		public ProductionToolCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}

 	/// <summary>
	/// Handles creation of an element through its ElementTool.
	/// </summary>
	internal partial class ProducedAssetCreateAction : DslDiagrams::CreateAction
	{
		/// <summary>
		/// Constructs a new ProducedAssetCreateAction for the given Diagram.
		/// </summary>
		public ProducedAssetCreateAction(DslDiagrams::Diagram diagram): base(diagram)
		{
		}
	}
 	
 	/// <summary>
	/// Handles interaction between the ConnectionBuilder and the corresponding ConnectionTool.
	/// </summary>
	internal partial class ProductionWorkflowConnectorConnectAction : DslDiagrams::ConnectAction
	{
		private DslDiagrams::ConnectionType[] connectionTypes;
		
		/// <summary>
		/// Constructs a new ProductionWorkflowConnectorConnectAction for the given Diagram.
		/// </summary>
		public ProductionWorkflowConnectorConnectAction(DslDiagrams::Diagram diagram): base(diagram, true) 
		{
		}
		
		/// <summary>
		/// Gets the cursor corresponding to the given mouse position.
		/// </summary>
		/// <remarks>
		/// Changes the cursor to Cursors.No before the first mouse click if the source shape is not valid.
		/// </remarks>
		public override global::System.Windows.Forms.Cursor GetCursor(global::System.Windows.Forms.Cursor currentCursor, DslDiagrams::DiagramClientView diagramClientView, DslDiagrams::PointD mousePosition)
		{
			if (this.MouseDownHitShape == null && currentCursor != global::System.Windows.Forms.Cursors.No)
			{
				DslDiagrams::DiagramHitTestInfo hitTestInfo = new DslDiagrams::DiagramHitTestInfo(diagramClientView);
				this.Diagram.DoHitTest(mousePosition, hitTestInfo);
				DslDiagrams::ShapeElement shape = hitTestInfo.HitDiagramItem.Shape;

				DslDiagrams::ConnectionType connectionType = GetConnectionTypes(shape, null)[0];
				string warningString = string.Empty;
				if (!connectionType.CanCreateConnection(shape, null, ref warningString))
				{
					return global::System.Windows.Forms.Cursors.No;
				}
			}
			return base.GetCursor(currentCursor, diagramClientView, mousePosition);
		}
		
		
		/// <summary>
		/// Returns the ProductionWorkflowConnectorConnectionType associated with this action.
		/// </summary>
		protected override DslDiagrams::ConnectionType[] GetConnectionTypes(DslDiagrams::ShapeElement sourceShapeElement, DslDiagrams::ShapeElement targetShapeElement)
		{
			if(this.connectionTypes == null)
			{
				this.connectionTypes = new DslDiagrams::ConnectionType[] { new ProductionWorkflowConnectorConnectionType() };
			}
			
			return this.connectionTypes;
		}
		
		private partial class ProductionWorkflowConnectorConnectionTypeBase : DslDiagrams::ConnectionType
		{
			/// <summary>
			/// Constructs a new the ProductionWorkflowConnectorConnectionType with the given ConnectionBuilder.
			/// </summary>
			protected ProductionWorkflowConnectorConnectionTypeBase() : base() {}
			
			private static DslDiagrams::ShapeElement RemovePassThroughShapes(DslDiagrams::ShapeElement shape)
			{
				if (shape is DslDiagrams::Compartment)
				{
					return shape.ParentShape;
				}
				DslDiagrams::SwimlaneShape swimlane = shape as DslDiagrams::SwimlaneShape;
				if (swimlane != null && swimlane.ForwardDragDropToParent)
				{
					return shape.ParentShape;
				}
				return shape;
			}
						
			/// <summary>
			/// Called by the base ConnectAction class to determine if the given shapes can be connected.
			/// </summary>
			/// <remarks>
			/// This implementation delegates calls to the ConnectionBuilder ProductionWorkflow.
			/// </remarks>
			public override bool CanCreateConnection(DslDiagrams::ShapeElement sourceShapeElement, DslDiagrams::ShapeElement targetShapeElement, ref string connectionWarning)
			{
				bool canConnect = true;
				
				if(sourceShapeElement == null) throw new global::System.ArgumentNullException("sourceShapeElement");
				sourceShapeElement = RemovePassThroughShapes(sourceShapeElement);
				DslModeling::ModelElement sourceElement = sourceShapeElement.ModelElement;
				if(sourceElement == null) sourceElement = sourceShapeElement;
				
				DslModeling::ModelElement targetElement = null;
				if (targetShapeElement != null)
				{
					targetShapeElement = RemovePassThroughShapes(targetShapeElement);
					targetElement = targetShapeElement.ModelElement;
					if(targetElement == null) targetElement = targetShapeElement;
			
				}

				// base.CanCreateConnection must be called to check whether existing Locks prevent this link from getting created.	
				canConnect = base.CanCreateConnection(sourceShapeElement, targetShapeElement, ref connectionWarning);
				if (canConnect)
				{				
					if(targetShapeElement == null)
					{
						return ProductionWorkflow.CanAcceptSource(sourceElement);
					}
					else
					{				
						return ProductionWorkflow.CanAcceptSourceAndTarget(sourceElement, targetElement);
					}
				}
				else
				{
					//return false
					return canConnect;
				}
			}
						
			/// <summary>
			/// Called by the base ConnectAction class to ask whether the given source and target are valid.
			/// </summary>
			/// <remarks>
			/// Always return true here, to give CanCreateConnection a chance to decide.
			/// </remarks>
			public override bool IsValidSourceAndTarget(DslDiagrams::ShapeElement sourceShapeElement, DslDiagrams::ShapeElement targetShapeElement)
			{
				return true;
			}
			
			/// <summary>
			/// Called by the base ConnectAction class to create the underlying relationship.
			/// </summary>
			/// <remarks>
			/// This implementation delegates calls to the ConnectionBuilder ProductionWorkflow.
			/// </remarks>
			public override void CreateConnection(DslDiagrams::ShapeElement sourceShapeElement, DslDiagrams::ShapeElement targetShapeElement, DslDiagrams::PaintFeedbackArgs paintFeedbackArgs)
			{
				if(sourceShapeElement == null) throw new global::System.ArgumentNullException("sourceShapeElement");
				if(targetShapeElement == null) throw new global::System.ArgumentNullException("targetShapeElement");
				
				sourceShapeElement = RemovePassThroughShapes(sourceShapeElement);
				targetShapeElement = RemovePassThroughShapes(targetShapeElement);
				
				DslModeling::ModelElement sourceElement = sourceShapeElement.ModelElement;
				if(sourceElement == null) sourceElement = sourceShapeElement;
				DslModeling::ModelElement targetElement = targetShapeElement.ModelElement;
				if(targetElement == null) targetElement = targetShapeElement;
				ProductionWorkflow.Connect(sourceElement, targetElement);
			}
		}
		
		private partial class ProductionWorkflowConnectorConnectionType : ProductionWorkflowConnectorConnectionTypeBase
		{
			/// <summary>
			/// Constructs a new the ProductionWorkflowConnectorConnectionType with the given ConnectionBuilder.
			/// </summary>
			public ProductionWorkflowConnectorConnectionType() : base() {}
		}
	}
}

