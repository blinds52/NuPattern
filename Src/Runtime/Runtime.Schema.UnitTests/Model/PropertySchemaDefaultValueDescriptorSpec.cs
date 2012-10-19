﻿using System;
using Microsoft.VisualStudio.Patterning.Extensibility;
using Microsoft.VisualStudio.Patterning.Extensibility.Binding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.VisualStudio.Patterning.Runtime.Schema.UnitTests.Model
{
    public class PropertySchemaDefaultValueDescriptorSpec
    {
        private static readonly IAssertion Assert = new Assertion();

        [TestClass]
        public class GivenAProperty
        {
            private DslTestStore<PatternModelDomainModel> store = new DslTestStore<PatternModelDomainModel>();
            private PropertySchema property;
            private DefaultValuePropertyDescriptor descriptor;

            [TestInitialize]
            public void InitializeContext()
            {
                this.store.TransactionManager.DoWithinTransaction(() =>
                {
                    var patternModel = this.store.ElementFactory.CreateElement<PatternModelSchema>();
                    var pattern = patternModel.Create<PatternSchema>();
                    this.property = pattern.Create<PropertySchema>();
                });

                this.descriptor = new DefaultValuePropertyDescriptor("DefaultValue", property, typeof(string), new Attribute[0]);
            }

            [TestMethod]
            public void ThenCanResetValueIsFalse()
            {
                Assert.False(this.descriptor.CanResetValue(null));
            }

            [TestMethod]
            public void WhenDefaultValueHasAValue_ThenCanResetValueIsTrue()
            {
                this.store.TransactionManager.DoWithinTransaction(() =>
                {
                    this.property.DefaultValue.Value = "Foo";
                });

                Assert.True(this.descriptor.CanResetValue(null));
            }

            [TestMethod]
            public void WhenDefaultValueHasAValueProvider_ThenCanResetValueIsTrue()
            {
                this.store.TransactionManager.DoWithinTransaction(() =>
                {
                    this.property.DefaultValue.ValueProvider = new ValueProviderBindingSettings { TypeId = "Foo" };
                });

                Assert.True(this.descriptor.CanResetValue(null));
            }

            [TestMethod]
            public void WhenReset_ThenCanResetValueIsFalse()
            {
                this.store.TransactionManager.DoWithinTransaction(() =>
                {
                    this.property.DefaultValue.ValueProvider = new ValueProviderBindingSettings { TypeId = "Foo" };
                });
                this.descriptor.ResetValue(null);

                Assert.False(this.descriptor.CanResetValue(null));
            }

            [TestMethod]
            public void WhenReset_ThenDefaultValueIsReset()
            {
                this.store.TransactionManager.DoWithinTransaction(() =>
                {
                    this.property.DefaultValue.Value = "Foo";
                    this.property.DefaultValue.ValueProvider = new ValueProviderBindingSettings { TypeId = "Foo" };
                });
                this.descriptor.ResetValue(null);

                Assert.Equal(string.Empty, this.property.DefaultValue.Value);
                Assert.Null(this.property.DefaultValue.ValueProvider);
            }
        }
    }
}
