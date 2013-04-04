﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TeamArchitect.PowerTools;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features.Diagnostics;
using NuPattern.ComponentModel.Design;
using NuPattern.Library.Properties;
using NuPattern.VisualStudio.Solution;

namespace NuPattern.Library.Commands
{
    /// <summary>
    /// Transforms all the Text Templates for the current solution.
    /// </summary>
    [DisplayNameResource("RunVsCommandCommand_DisplayName", typeof(Resources))]
    [CategoryResource("AutomationCategory_VisualStudio", typeof(Resources))]
    [DescriptionResource("RunVsCommandCommand_Description", typeof(Resources))]
    [CLSCompliant(false)]
    public class RunVsCommandCommand : FeatureCommand
    {
        private static readonly ITraceSource tracer = Tracer.GetSourceFor<RunVsCommandCommand>();

        /// <summary>
        /// Gets or sets the solution.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public ISolution Solution { get; set; }

        /// <summary>
        /// Gets or sets the command to execute.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [DisplayNameResource("RunVsCommandCommand_CommandName_DisplayName", typeof(Resources))]
        [DescriptionResource("RunVsCommandCommand_CommandName_Description", typeof(Resources))]
        public virtual string CommandName { get; set; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public override void Execute()
        {
            this.ValidateObject();

            tracer.TraceInformation(
                Resources.RunVsCommandCommand_TraceInitial, this.CommandName);

            this.Solution.RunCommand(this.CommandName);
        }
    }
}
