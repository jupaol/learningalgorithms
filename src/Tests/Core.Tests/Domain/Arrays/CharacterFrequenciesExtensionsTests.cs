using Core.Domain.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class CharacterFrequenciesExtensionsTests
	{
		[TestClass]
		public class TheIsStringValidMethod
		{
			[TestMethod]
			public void It_should_detect_if_the_string_is_valid()
			{
				string source;
				bool res;

				source = "aabbcccdddggggg";
				res = source.IsStringValid();
				res.Should().BeFalse(source);

				source = "aabbcccddd";
				res = source.IsStringValid();
				res.Should().BeFalse(source);

				source = "aabbc";
				res = source.IsStringValid();
				res.Should().BeTrue(source);

				source = "aabbcd";
				res = source.IsStringValid();
				res.Should().BeFalse(source);

				source = "aabbc";
				res = source.IsStringValid();
				res.Should().BeTrue(source);

				source = "aaaabbcc";
				res = source.IsStringValid();
				res.Should().BeFalse(source);

				source = "aaaaabc";
				res = source.IsStringValid();
				res.Should().BeFalse(source);
			}
		}
	}
}
