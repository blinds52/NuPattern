﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NuPattern.Runtime.UnitTests
{
	[TestClass]
	public class ToolkitInfoSerializerSpec
	{
		internal static readonly IAssertion Assert = new Assertion();

		[TestMethod, TestCategory("Unit")]
		public void WhenTryingToWriteANullList_ThenThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => ToolkitInfoSerializer.ToXml(null));
		}

		[TestMethod, TestCategory("Unit")]
		public void WhenTryingToReadANullValue_ThenThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => ToolkitInfoSerializer.FromXml(null));
		}

		[TestMethod, TestCategory("Unit")]
        public void WhenTryingToReadAnEmptyValue_ThenThrowsArgumentOutOfRangeException()
		{
            Assert.Throws<ArgumentOutOfRangeException>(() => ToolkitInfoSerializer.FromXml(string.Empty));
		}

		[TestMethod, TestCategory("Unit")]
		public void WhenSavingAList_ThenReturnCanBeLoadedBack()
		{
			var infos = new[] { new ToolkitInfo { Name = "Foo" } };

			var content = ToolkitInfoSerializer.ToXml(infos);

			Assert.True(!String.IsNullOrEmpty(content));

			var readResult = ToolkitInfoSerializer.FromXml(content);

			Assert.Equal(infos.Count(), readResult.Count());

			Assert.True(readResult.Any(info => info.Name.Equals("Foo")));
		}
	}
}
