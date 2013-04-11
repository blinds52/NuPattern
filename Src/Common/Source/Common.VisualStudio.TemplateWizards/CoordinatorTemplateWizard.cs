﻿extern alias npvs;
using System;
using VsTemplateWizards = npvs::NuPattern.VisualStudio.TemplateWizards;

namespace NuPattern.VisualStudio.TemplateWizards
{
    /// <summary>
    /// Proxy for the <see cref="VsTemplateWizards.CoordinatorTemplateWizard"/> class.
    /// </summary>
    [CLSCompliant(false)]
    public sealed class CoordinatorTemplateWizard : VsTemplateWizards.CoordinatorTemplateWizard
    {
    }
}
