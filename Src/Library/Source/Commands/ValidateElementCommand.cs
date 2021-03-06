﻿using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NuPattern.ComponentModel.Design;
using NuPattern.Diagnostics;
using NuPattern.Library.Properties;
using NuPattern.Runtime;

namespace NuPattern.Library.Commands
{
    /// <summary>
    /// Invokes the validation of the current element.
    /// </summary>
    [DescriptionResource(@"ValidateElementCommand_Description", typeof(Resources))]
    [DisplayNameResource(@"ValidateElementCommand_DisplayName", typeof(Resources))]
    [CategoryResource(@"AutomationCategory_Automation", typeof(Resources))]
    [CLSCompliant(false)]
    public class ValidateElementCommand : Command
    {
        private const bool DefaultValidateDescendants = true;

        private static readonly ITracer tracer = Tracer.Get<ValidateElementCommand>();

        /// <summary>
        /// Initializes a new instance fo the <see cref="ValidateElementCommand"/> class.
        /// </summary>
        public ValidateElementCommand()
        {
            this.ValidateDescendants = DefaultValidateDescendants;
        }

        /// <summary>
        /// Gets or sets whether to validate the descendants of the current element.
        /// </summary>
        [DefaultValue(DefaultValidateDescendants)]
        [DisplayNameResource(@"ValidateElementCommand_ValidateDescendantsDisplayName", typeof(Resources))]
        [DescriptionResource(@"ValidateElementCommand_ValidateDescendantsDescription", typeof(Resources))]
        public bool ValidateDescendants { get; set; }

        /// <summary>
        /// The current element.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IProductElement CurrentElement { get; set; }

        /// <summary>
        /// The pattern manager.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IPatternManager PatternManager { get; set; }

        /// <summary>
        /// Executes the validation behavior.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public override void Execute()
        {
            this.ValidateObject();

            tracer.Info(
                Resources.ValidateElementCommand_TraceInitial, this.CurrentElement.InstanceName, this.ValidateDescendants);

            var instances = this.ValidateDescendants ? this.CurrentElement.Traverse().OfType<IInstanceBase>() : new[] { this.CurrentElement };

            var elements = instances.Concat(instances.OfType<IProductElement>().SelectMany(e => e.Properties));

            var result = this.PatternManager.Validate(elements);

            tracer.Info(
                Resources.ValidateElementCommand_TraceResult, this.CurrentElement.InstanceName, this.ValidateDescendants, result);
        }
    }
}