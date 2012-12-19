﻿using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features.Diagnostics;
using NuPattern.Extensibility;
using NuPattern.Library.Properties;
using NuPattern.Runtime;

namespace NuPattern.Library.Conditions
{
    /// <summary>
    /// Indicates that an element, and its descendants are valid.
    /// </summary>
    [CategoryResource("AutomationCategory_Automation", typeof(Resources))]
    [DescriptionResource("ValidElementCondition_Description", typeof(Resources))]
    [DisplayNameResource("ValidElementCondition_DisplayName", typeof(Resources))]
    [CLSCompliant(false)]
    public class ValidElementCondition : Condition
    {
        private static readonly ITraceSource tracer = Tracer.GetSourceFor<ValidElementCondition>();

        private const bool DefaultValidateDescendants = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidElementCondition"/> class.
        /// </summary>
        public ValidElementCondition()
        {
            this.ValidateDescendants = true;
        }

        /// <summary>
        /// Gets or sets whether to validate the descendants of the current element.
        /// </summary>
        [DefaultValue(DefaultValidateDescendants)]
        [DisplayNameResource("ValidElementCondition_ValidateDescendantsDisplayName", typeof(Resources))]
        [DescriptionResource("ValidElementCondition_ValidateDescendantsDescription", typeof(Resources))]
        public bool ValidateDescendants { get; set; }

        /// <summary>
        /// Gets the current element.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IProductElement CurrentElement { get; set; }

        /// <summary>
        /// Gets the pattern manager.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IPatternManager PatternManager { get; set; }

        /// <summary>
        /// Evaluates this instance.
        /// </summary>
        public override bool Evaluate()
        {
            this.ValidateObject();

            tracer.TraceInformation(
                Resources.ValidElementCondition_TraceInitial, this.CurrentElement.InstanceName, this.ValidateDescendants);

            var instances = this.ValidateDescendants ? this.CurrentElement.Traverse().OfType<IInstanceBase>() : new[] { this.CurrentElement };

            var elements = instances.Concat(instances.OfType<IProductElement>().SelectMany(e => e.Properties));

            var result = this.PatternManager.Validate(elements);

            tracer.TraceInformation(
                Resources.ValidElementCondition_TraceEvaluation, this.CurrentElement.InstanceName, this.ValidateDescendants, result);

            return result;
        }
    }
}