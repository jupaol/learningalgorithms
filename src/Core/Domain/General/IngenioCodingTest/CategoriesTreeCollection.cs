using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.General.IngenioCodingTest
{
	public class CategoriesTreeCollection : IEnumerable<Category>
	{
		public TreeNode<Category> Root { get; private set; }

		public void Add(Category item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			var node = new TreeNode<Category>(item);

			if (Root == null)
			{
				Root = node;
			}
			else
			{
				AddRec(Root, item);
			}
		}

		public void AddMany(IEnumerable<Category> categories)
		{
			if (categories == null)
			{
				throw new ArgumentNullException(nameof(categories));
			}

			foreach (Category category in categories)
			{
				Add(category);
			}
		}

		public string FindAndParseById(int categoryId)
		{
			if (Root == null)
			{
				return null;
			}

			(Category Category, IEnumerable<string> Keywords) item =
				FindByIdRec(Root, categoryId, new List<string>());

			return item.Category?.ToString(item.Keywords);
		}

		public IEnumerable<int> FindCategoryIdsPerLevel(int level)
		{
			if (level < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(level));
			}

			return FindCategoryIdsPerLevel(Root, level);
		}

		public IEnumerator<Category> GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private TreeNode<Category> AddRec(TreeNode<Category> root, Category item)
		{
			if (root == null)
			{
				root = new TreeNode<Category>(item);
			}
			else if (item.CategoryId <= root.Item.CategoryId)
			{
				root.Left = AddRec(root.Left, item);
			}
			else
			{
				root.Right = AddRec(root.Right, item);
			}

			return root;
		}

		private (Category Category, IEnumerable<string> Keywords) FindByIdRec(
			TreeNode<Category> root, int categoryId, ICollection<string> previousKeywords)
		{
			if (root == null)
			{
				return (null, Enumerable.Empty<string>());
			}

			if (root.Item.Keywords.Count > 0)
			{
#pragma warning disable S1226 // Method parameters, caught exceptions and foreach variables' initial values should not be ignored
				previousKeywords = root.Item.Keywords;
#pragma warning restore S1226 // Method parameters, caught exceptions and foreach variables' initial values should not be ignored
			}

			if (categoryId == root.Item.CategoryId)
			{
				return (root.Item, previousKeywords);
			}

			if (categoryId <= root.Item.CategoryId)
			{
				return FindByIdRec(root.Left, categoryId, previousKeywords);
			}

			return FindByIdRec(root.Right, categoryId, previousKeywords);
		}

		private IEnumerable<int> FindCategoryIdsPerLevel(TreeNode<Category> root, int level)
		{
			throw new NotImplementedException();
		}
	}
}
