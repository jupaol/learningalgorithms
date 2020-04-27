using Core.Domain.Strings;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Strings
{
	[TestClass]
	public class ReverseWordsInASentenceExtensionsTests
	{
		[TestClass]
		public class TheReverseWordsInASentenceMethod
		{
			[TestMethod]
			public void It_should_reverse_the_words_in_a_sentence()
			{
				string source;
				string res;

				source = "Hello World !!! nice";
				res = source.ReverseWordsInASentence();
				res.Should().Be("nice !!! World Hello");

				source = "Hello World !!! nice ";
				res = source.ReverseWordsInASentence();
				res.Should().Be(" nice !!! World Hello");

				source = " Hello World !!! nice";
				res = source.ReverseWordsInASentence();
				res.Should().Be("nice !!! World Hello ");

				source = " Hello World !!! nice  ";
				res = source.ReverseWordsInASentence();
				res.Should().Be("  nice !!! World Hello ");
			}
		}
	}
}
