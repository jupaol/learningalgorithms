using System;

namespace Core.Domain.Arrays
{
	public class MoveItemsInArray : IMoveItemsInArray
	{
		public T[] MoveLeft<T>(T[] source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				return Array.Empty<T>();
			}

			int readerIndex = source.Length - 1;
			int writerIndex = source.Length - 1;

			while (readerIndex >= 0)
			{
				if (source[readerIndex].Equals(key))
				{
					readerIndex--;
				}
				else
				{
					// not equal to key
					if (readerIndex != writerIndex)
					{
						source[writerIndex] = source[readerIndex];
					}

					writerIndex--;
					readerIndex--;
				}
			}

			for (int i = 0; i <= writerIndex; i++)
			{
				source[i] = key;
			}

			return source;
		}

		public T[] MoveRight<T>(T[] source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				return Array.Empty<T>();
			}

			int readerIndex = 0;
			int writerIndex = 0;

			while (readerIndex < source.Length)
			{
				if (source[readerIndex].Equals(key))
				{
					readerIndex++;
				}
				else
				{
					if (readerIndex != writerIndex)
					{
						source[writerIndex] = source[readerIndex];
					}

					readerIndex++;
					writerIndex++;
				}
			}

			for (int i = writerIndex; i < source.Length; i++)
			{
				source[i] = key;
			}

			return source;
		}
	}
}
