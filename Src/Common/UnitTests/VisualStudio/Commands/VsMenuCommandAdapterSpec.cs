﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuPattern.VisualStudio.Commands;

namespace NuPattern.VisualStudio.UnitTests.Commands
{
    [TestClass]
    public class VsMenuCommandAdapterSpec
    {
        internal static readonly IAssertion Assert = new Assertion();

        [TestMethod, TestCategory("Unit")]
        public void WhenCreatingMenuCommandAndCommandIsNull_ThenThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new VsMenuCommandAdapter(null));
        }
    }
}