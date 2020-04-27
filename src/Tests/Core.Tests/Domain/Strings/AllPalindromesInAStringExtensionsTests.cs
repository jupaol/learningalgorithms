using System.Collections.Generic;
using Core.Domain.Strings;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Strings
{
	[TestClass]
	public class AllPalindromesInAStringExtensionsTests
	{
		[TestClass]
		public class TheFindAllPalindromesMethod
		{
			[TestMethod]
			public void It_should_find_all_palindromes_from_a_string()
			{
				string source;
				IEnumerable<string> res;

				source = "aabbbaa";
				res = source.FindAllPalindromes(2);
				res.Should().HaveCount(7);
				res.Should().Contain(
					"aa", "bb", "bbb", "abbba", "aabbbaa", "bb", "aa");
			}
		}

		[TestClass]
		public class TheFindAllPalindromesNSquareRuntimeMethod
		{
			[TestMethod]
			public void It_should_find_all_palindromes_from_a_string()
			{
				string source;
				IEnumerable<string> res;

				source = "aabbbaa";
				res = source.FindAllPalindromesNSquareRuntime(2);
				res.Should().HaveCount(7);
				res.Should().Contain(
					"aa", "bb", "bbb", "abbba", "aabbbaa", "bb", "aa");
			}
		}
	}
}
