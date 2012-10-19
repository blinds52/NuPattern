﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.Patterning.Library.Commands;
using Microsoft.VisualStudio.Patterning.Runtime;
using Moq;

namespace Microsoft.VisualStudio.Patterning.Library.UnitTests.Commands
{
	public class UnfoldScopeSpec
	{
		internal static readonly IAssertion Assert = new Assertion();

		[TestClass]
		public class GivenAScope
		{
			public UnfoldScope Scope { get; private set; }
			public IAutomationExtension<IAutomationSettings> Automation { get; private set; }
			public ReferenceTag Tag { get; private set; }

			[TestInitialize]
			public virtual void Initialize()
			{
				var mock = new Mock<IAutomationExtension<IAutomationSettings>>();
				mock.SetupAllProperties();

				this.Automation = mock.Object;
				this.Tag = new ReferenceTag();

				this.Scope = CreateScope();
			}

			[TestCleanup]
			public virtual void Cleanup()
			{
				this.Scope.Dispose();
			}

			protected virtual UnfoldScope CreateScope()
			{
				return new UnfoldScope(this.Automation, this.Tag, "template://foo");
			}

			[TestMethod]
			public void ThenIsActiveIsTrue()
			{
				Assert.True(UnfoldScope.IsActive);
			}

			[TestMethod]
			public void ThenCurrentIsSame()
			{
				Assert.Same(this.Scope, UnfoldScope.Current);
			}

			[TestMethod]
			public void ThenAutomationIsSame()
			{
				Assert.Same(this.Automation, UnfoldScope.Current.Automation);
			}

			[TestMethod]
			public void ThenHasUnfoldedTemplate()
			{
				Assert.True(UnfoldScope.Current.HasUnfolded("template://foo"));
			}

			[TestMethod]
			public void ThenHasNotUnfoldedOtherTemplate()
			{
				Assert.False(UnfoldScope.Current.HasUnfolded("template://bar"));
			}

			[TestMethod]
			public void WhenDisposingScope_ThenIsActiveFalse()
			{
				this.Scope.Dispose();

				Assert.False(UnfoldScope.IsActive);
			}

			[TestMethod]
			public void WhenDisposingScope_ThenCurrentIsNull()
			{
				this.Scope.Dispose();

				Assert.Null(UnfoldScope.Current);
			}
		}

		[TestClass]
		public class GivenANestedScope
		{
			protected UnfoldScope RootScope { get; private set; }
			protected UnfoldScope NestedScope { get; private set; }
			public IAutomationExtension<IAutomationSettings> Automation { get; private set; }
			public ReferenceTag Tag { get; private set; }

			[TestInitialize]
			public virtual void Initialize()
			{
				var mock = new Mock<IAutomationExtension<IAutomationSettings>>();
				mock.SetupAllProperties();

				this.Automation = mock.Object;
				this.Tag = new ReferenceTag();
			}

			[TestCleanup]
			public virtual void Cleanup()
			{
				this.NestedScope.Dispose();
				this.RootScope.Dispose();
			}

			[TestMethod]
			public void WhenDisposingRootScope_ThenIsActiveFalse()
			{
				this.RootScope = new UnfoldScope(this.Automation, this.Tag, "template://foo");
				this.NestedScope = new UnfoldScope(this.Automation, this.Tag, "template://bar");

				this.RootScope.Dispose();

				Assert.False(UnfoldScope.IsActive);
				Assert.Null(UnfoldScope.Current);

				// dispose child is no-op
				this.NestedScope.Dispose();
			}

			[TestMethod]
			public void WhenDisposingRootScopeThenNestedScope_ThenIsNoOp()
			{
				this.RootScope = new UnfoldScope(this.Automation, this.Tag, "template://foo");
				this.NestedScope = new UnfoldScope(this.Automation, this.Tag, "template://bar");

				this.RootScope.Dispose();
				// dispose child is no-op
				this.NestedScope.Dispose();

				Assert.False(UnfoldScope.IsActive);
				Assert.Null(UnfoldScope.Current);
			}

			[TestMethod]
			public void WhenHasUnfoldedRootTemplateFromNested_ThenReturnsTrue()
			{
				this.RootScope = new UnfoldScope(this.Automation, this.Tag, "template://foo");
				this.NestedScope = new UnfoldScope(this.Automation, this.Tag, "template://bar");

				Assert.True(UnfoldScope.Current.HasUnfolded("template://foo"));
				Assert.False(UnfoldScope.Current.HasUnfolded("template://baz"));
			}
		}
	}
}
