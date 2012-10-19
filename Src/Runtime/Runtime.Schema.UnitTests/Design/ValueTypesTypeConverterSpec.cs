﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.VisualStudio.Patterning.Runtime.Schema.UnitTests
{
    [TestClass]
    public class ValueTypesTypeConverterSpec
    {
        internal static readonly IAssertion Assert = new Assertion();

        [TestClass]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Test code")]
        public class GivenNoContext
        {
            private ValueTypesTypeConverter converter;

            [TestInitialize]
            public void InitializeContext()
            {
                this.converter = new ValueTypesTypeConverter();
            }

            [TestMethod]
            public void ThenExclusiveStandardValues()
            {
                Assert.True(this.converter.GetStandardValuesSupported());
                Assert.True(this.converter.GetStandardValuesExclusive());
            }
        }
    }
}