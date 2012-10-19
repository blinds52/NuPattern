﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.Patterning.Extensibility;
using Microsoft.VisualStudio.Patterning.Extensibility.References;
using Microsoft.VisualStudio.Patterning.Library.Properties;
using Microsoft.VisualStudio.Patterning.Runtime;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features.Diagnostics;

namespace Microsoft.VisualStudio.Patterning.Library.Conditions
{
    /// <summary>
    /// A <see cref="Condition"/> that evaluates to true if a solution artifact reference exists on the current element.
    /// </summary>
    [DisplayNameResource("ArtifactReferenceExistsCondition_DisplayName", typeof(Resources))]
    [CategoryResource("AutomationCategory_Automation", typeof(Resources))]
    [DescriptionResource("ArtifactReferenceExistsCondition_Description", typeof(Resources))]
    [CLSCompliant(false)]
    public class ArtifactReferenceExistsCondition : Condition
    {
        private static readonly ITraceSource tracer = Tracer.GetSourceFor<ArtifactReferenceExistsCondition>();

        /// <summary>
        /// Gets or sets the current element.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IProductElement CurrentElement { get; set; }

        /// <summary>
        /// Evaluates the condition by verifying the existence of any artifact references.
        /// </summary>
        public override bool Evaluate()
        {
            this.ValidateObject();

            tracer.TraceInformation(
                Resources.ArtifactReferenceExistsCondition_TraceInitial, this.CurrentElement.InstanceName);

            var result = SolutionArtifactLinkReference.GetReferences(this.CurrentElement).Any();

            tracer.TraceInformation(
                Resources.ArtifactReferenceExistsCondition_TraceEvaluation, this.CurrentElement.InstanceName, result);

            return result;
        }
    }
}
