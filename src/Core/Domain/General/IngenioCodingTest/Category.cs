using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.General.IngenioCodingTest
{
	public class Category
	{
		public Category()
		{
			Keywords = new List<string>();
		}

		public Category(IEnumerable<string> keywords)
		{
			Keywords = new List<string>(keywords);
		}

		public int CategoryId { get; set; }

		public int ParentCategoryId { get; set; }

		public string Name { get; set; }

		public ICollection<string> Keywords { get; }

		public override string ToString()
		{
			return Parse(Keywords);
		}

		public string ToString(IEnumerable<string> keywords)
		{
			if (keywords == null)
			{
				throw new ArgumentNullException(nameof(keywords));
			}

			return Parse(keywords);
		}

		private string Parse(IEnumerable<string> keywords)
		{
			var sb = new StringBuilder();

			sb
				.Append("ParentCategoryId=").Append(ParentCategoryId).Append(", ")
				.Append("Name=").Append(Name).Append(", ")
				.Append("Keywords=").Append(string.Join(",", keywords));

			return sb.ToString();
		}
	}
}
