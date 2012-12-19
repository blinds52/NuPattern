﻿
namespace NuPattern.Extensibility.References
{
    /// <summary>
    /// Constants for reference kinds.
    /// </summary>
    public static partial class ReferenceKindConstants
    {
        /// <summary>
        /// Kind used on guidance references.
        /// </summary>
        public static readonly string Guidance = typeof(GuidanceReference).FullName;

        /// <summary>
        /// Kind used on artifact link references.
        /// </summary>
        public static readonly string ArtifactLink = typeof(SolutionArtifactLinkReference).FullName;
    }
}
