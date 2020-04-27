using System.Collections.Generic;
using Core.Domain.Strings;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Strings
{
	[TestClass]
	public class MatchingWordsInStringPresentInListExtensionsTests
	{
		[TestClass]
		public class TheContainsAllWordsInListMethod
		{
			[TestMethod]
			public void It_should_indicate_if_string_contains_all_words()
			{
				string source;
				bool res;
				var hash = new HashSet<string>();

				hash.Add("one");
				hash.Add("two");
				hash.Add("three");
				hash.Add("on");
				hash.Add("net");
				hash.Add("o");
				source = "onetwothree";
				res = source.ContainsAllWordsInList(hash);
				res.Should().BeTrue();

				hash.Add("one");
				hash.Add("two");
				hash.Add("three");
				hash.Add("on");
				hash.Add("net");
				hash.Add("o");
				source = "onetwothrees";
				res = source.ContainsAllWordsInList(hash);
				res.Should().BeFalse();
			}
		}
	}
}
