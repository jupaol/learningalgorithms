using System.Collections.Generic;
using Core.Domain.General.IngenioCodingTest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General.IngenioCodingTest
{
	[TestClass]
	public class CategoriesTreeCollectionTests
	{
		private static IEnumerable<Category> BuildTestData()
		{
			yield return new Category(new[] { "Money" })
			{
				CategoryId = 100,
				ParentCategoryId = -1,
				Name = "Business"
			};

			yield return new Category(new[] { "Teaching" })
			{
				CategoryId = 200,
				ParentCategoryId = -1,
				Name = "Tutoring"
			};

			yield return new Category(new[] { "Taxes" })
			{
				CategoryId = 101,
				ParentCategoryId = 100,
				Name = "Accounting"
			};

			yield return new Category
			{
				CategoryId = 102,
				ParentCategoryId = 100,
				Name = "Taxation"
			};

			yield return new Category
			{
				CategoryId = 201,
				ParentCategoryId = 200,
				Name = "Computer"
			};

			yield return new Category
			{
				CategoryId = 103,
				ParentCategoryId = 101,
				Name = "Corporate Tax"
			};

			yield return new Category
			{
				CategoryId = 202,
				ParentCategoryId = 201,
				Name = "Operating System"
			};

			yield return new Category
			{
				CategoryId = 109,
				ParentCategoryId = 101,
				Name = "Small Business Tax"
			};
		}

		[TestClass]
		public class TheFindAndParseByIdMethod
		{
			[TestMethod]
			public void It_should_find_a_category_by_id()
			{
				var sut = new CategoriesTreeCollection();
				string res;

				sut.AddMany(BuildTestData());
				res = sut.FindAndParseById(201);
				res.Should().Be("ParentCategoryId=200, Name=Computer, Keywords=Teaching");

				res = sut.FindAndParseById(202);
				res.Should().Be("ParentCategoryId=201, Name=Operating System, Keywords=Teaching");
			}

			[TestMethod]
			public void It_should_return_null_if_category_does_not_exist()
			{
				var sut = new CategoriesTreeCollection();

				sut.AddMany(BuildTestData());

				string res = sut.FindAndParseById(1000);
				res.Should().BeNull();
			}
		}
	}
}
