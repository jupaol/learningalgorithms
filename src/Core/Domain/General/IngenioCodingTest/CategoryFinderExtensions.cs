using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.General.IngenioCodingTest
{
	public static class CategoryFinderExtensions
	{
		public static string FindById(this IEnumerable<Category> categories, int categoryId)
		{
			if (categories == null)
			{
				throw new ArgumentNullException(nameof(categories));
			}

			Category category = categories.FirstOrDefault(x => x.CategoryId.Equals(categoryId));

			if (category == null)
			{
				return null;
			}

			Category parentCategory = category;

			while (parentCategory.Keywords.Count == 0)
			{
				int parentCategoryId = parentCategory.ParentCategoryId;

				parentCategory = categories
					.FirstOrDefault(x => x.CategoryId.Equals(parentCategoryId));

				if (parentCategory == null)
				{
					throw new Exception(
						$"Corrupted data, category not found: {parentCategoryId.ToString()}");
				}
			}

			return category.ToString(parentCategory.Keywords);
		}

		public static IEnumerable<int> FindIdsByLevel(
			this IEnumerable<Category> categories, int level)
		{
			if (categories == null)
			{
				throw new ArgumentNullException(nameof(categories));
			}

			if (level < 1)
			{
				return Enumerable.Empty<int>();
			}

			IEnumerable<Category> sortedCategories = categories.OrderBy(x => x.ParentCategoryId);
			List<int> ids = sortedCategories
				.Where(x => x.ParentCategoryId == -1)
				.Select(x => x.CategoryId)
				.ToList();

			if (level == 1)
			{
				return ids;
			}

			int currentLevel = 1;

			while (ids.Count > 0 && currentLevel < level)
			{
				ids = sortedCategories
					.Where(x => ids.Contains(x.ParentCategoryId))
					.Select(x => x.CategoryId)
					.ToList();

				currentLevel++;
			}

			if (level != currentLevel)
			{
				return Enumerable.Empty<int>();
			}

			return ids;
		}
	}
}
