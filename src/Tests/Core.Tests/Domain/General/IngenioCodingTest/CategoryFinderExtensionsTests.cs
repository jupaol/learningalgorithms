using System;
using System.Collections.Generic;
using Core.Domain.General.IngenioCodingTest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General.IngenioCodingTest
{
	[TestClass]
	public class CategoryFinderExtensionsTests
	{
		private static IEnumerable<Category> BuildTestData()
		{
			yield return new Category(new[] { "Money" })
			{
				CategoryId = 100, ParentCategoryId = -1, Name = "Business"
			};

			yield return new Category(new[] { "Teaching" })
			{
				CategoryId = 200, ParentCategoryId = -1, Name = "Tutoring"
			};

			yield return new Category(new[] { "Taxes" })
			{
				CategoryId = 101, ParentCategoryId = 100, Name = "Accounting"
			};

			yield return new Category
			{
				CategoryId = 102, ParentCategoryId = 100, Name = "Taxation"
			};

			yield return new Category
			{
				CategoryId = 201, ParentCategoryId = 200, Name = "Computer"
			};

			yield return new Category
			{
				CategoryId = 103, ParentCategoryId = 101, Name = "Corporate Tax"
			};

			yield return new Category
			{
				CategoryId = 202, ParentCategoryId = 201, Name = "Operating System"
			};

			yield return new Category
			{
				CategoryId = 109, ParentCategoryId = 101, Name = "Small Business Tax"
			};
		}

		[TestClass]
		public class TheFindByIdMethod
		{
			[TestMethod]
			public void It_should_find_a_category_by_id()
			{
				IEnumerable<Category> sut;
				string res;

				sut = BuildTestData();
				res = sut.FindById(201);
				res.Should().Be("ParentCategoryId=200, Name=Computer, Keywords=Teaching");

				sut = BuildTestData();
				res = sut.FindById(202);
				res.Should().Be("ParentCategoryId=201, Name=Operating System, Keywords=Teaching");
			}

			[TestMethod]
			public void It_should_validate_its_parameters()
			{
				IEnumerable<Category> sut = BuildTestData();
				Action onCalling;

				sut = null;
				onCalling = () => sut.FindById(201);
				onCalling.Should().Throw<ArgumentNullException>();
			}

			[TestMethod]
			public void It_should_return_null_if_category_does_not_exist()
			{
				IEnumerable<Category> sut = BuildTestData();
				string res = sut.FindById(1000);

				res.Should().BeNull();
			}
		}

		[TestClass]
		public class TheFindIdsByLevelMethod
		{
			[TestMethod]
			public void It_should_find_the_ids_per_level()
			{
				IEnumerable<Category> sut;
				IEnumerable<int> res;
				var expected = new List<int>();

				sut = BuildTestData();
				res = sut.FindIdsByLevel(2);
				expected.AddRange(new[] { 101, 102, 201 });
				expected.ForEach(x => res.Should().Contain(x));

				expected.Clear();
				sut = BuildTestData();
				res = sut.FindIdsByLevel(3);
				expected.AddRange(new[] { 103, 109, 202 });
				expected.ForEach(x => res.Should().Contain(x));

				expected.Clear();
				sut = BuildTestData();
				res = sut.FindIdsByLevel(1);
				expected.AddRange(new[] { 100, 200 });
				expected.ForEach(x => res.Should().Contain(x));
			}

			[TestMethod]
			public void It_should_validate_its_parameters()
			{
				IEnumerable<Category> sut;
				Action onCalling;

				sut = null;
				onCalling = () => sut.FindIdsByLevel(0);
				onCalling.Should().Throw<ArgumentNullException>();
			}

			[TestMethod]
			public void It_should_return_an_empty_collection_of_ids_if_the_level_is_invalid()
			{
				IEnumerable<Category> sut;
				IEnumerable<int> res;

				sut = BuildTestData();
				res = sut.FindIdsByLevel(0);
				res.Should().BeEmpty();

				res = sut.FindIdsByLevel(1000);
				res.Should().BeEmpty();
			}
		}
	}
}
