using Core.Domain.Strings;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Strings
{
	[TestClass]
	public class RemoveDuplicatesExtensionsTests
	{
		[TestClass]
		public class TheRemoveDuplicateCharactersMethod
		{
			[TestMethod]
			public void It_should_remove_duplicated_characters_from_the_array()
			{
				string source;
				char[] sut;

				source = "Hello World !!!";
				sut = source.ToCharArray();
				sut.RemoveDuplicateCharacters();
				sut.Should().ContainInOrder(source.Remove(0).ToCharArray());
			}
		}
	}
}
