using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core.Domain.General
{
	public static class ArithmeticExpressionExtensions
	{
		private static readonly Dictionary<char, int> _operators = new Dictionary<char, int>
		{
			{ '^', 10 },
			{ '*', 5 },
			{ '/', 5 },
			{ '+', 1 },
			{ '-', 1 }
		};

		private static readonly Dictionary<char, char> _openParenthesis = new Dictionary<char, char>
		{
			{ '(', ')' },
			{ '[', ']' },
			{ '{', '}' }
		};

		private static readonly Dictionary<char, char> _closedParenthesis = new Dictionary<char, char>
		{
			{ ')', '(' },
			{ ']', '[' },
			{ '}', '{' }
		};

		public static string ToPostfixExpression(this string source)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				throw new ArgumentNullException(nameof(source));
			}

			var res = new StringBuilder();
			var stack = new Stack<char>();
			bool isCurrentOperand = false;

			foreach (char c in source)
			{
				if (char.IsWhiteSpace(c))
				{
					continue;
				}

				if (IsOperand(c))
				{
					if (!isCurrentOperand)
					{
						isCurrentOperand = true;
					}

					res.Append(c);
				}
				else if (IsOpenedParenthesis(c))
				{
					if (isCurrentOperand)
					{
						isCurrentOperand = false;
						res.Append(',');
					}

					stack.Push(c);
				}
				else if (IsClosedParenthesis(c))
				{
					if (isCurrentOperand)
					{
						isCurrentOperand = false;
					}

					while (stack.Count > 0 && !IsOpenedParenthesis(stack.Peek()))
					{
						res.Append(stack.Pop());
					}

					if (!AreOpenAndCloseParenthesisAMatch(stack.Peek(), c))
					{
						throw new Exception("Parenthesis mismatch");
					}

					stack.Pop();
				}
				else if (IsOperator(c))
				{
					if (isCurrentOperand)
					{
						isCurrentOperand = false;
						res.Append(',');
					}

					if (stack.Count == 0)
					{
						stack.Push(c);
					}
					else if (IsOpenedParenthesis(stack.Peek()))
					{
						stack.Push(c);
					}
					else if (HasHigherPrecedence(stack.Peek(), c))
					{
						while (stack.Count > 0 && IsOperator(stack.Peek()))
						{
							res.Append(stack.Pop());
						}

						stack.Push(c);
					}
					else
					{
						stack.Push(c);
					}
				}
				else
				{
					throw new Exception($"Unknown token: {c.ToString(CultureInfo.InvariantCulture)}");
				}
			}

			while (stack.Count > 0)
			{
				res.Append(stack.Pop());
			}

			return res.ToString();
		}

		public static double EvaluatePostfixExpression(this string source)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				throw new ArgumentNullException(nameof(source));
			}

			var currentOperand = new StringBuilder();
			var operandsStack = new Stack<double>();
			bool isOperand = false;

			foreach (char c in source)
			{
				if (char.IsWhiteSpace(c))
				{
					continue;
				}

				if (c == ',')
				{
					isOperand = false;
					operandsStack.Push(double.Parse(currentOperand.ToString()));
					currentOperand.Clear();
				}
				else if (IsOperand(c))
				{
					isOperand = true;
					currentOperand.Append(c);
				}
				else if (IsOperator(c))
				{
					if (isOperand)
					{
						isOperand = false;
						operandsStack.Push(double.Parse(currentOperand.ToString()));
						currentOperand.Clear();
					}

					double b = operandsStack.Pop();
					double a = operandsStack.Pop();
					double tmpRes = Operate(c, a, b);

					operandsStack.Push(tmpRes);
				}
				else
				{
					throw new Exception($"Invalid character detected: {c.ToString(CultureInfo.InvariantCulture)}");
				}
			}

			return operandsStack.Pop();
		}

		private static double Operate(char c, double a, double b)
		{
			switch (c)
			{
				case '+':
					return a + b;

				case '-':
					return a - b;

				case '*':
					return a * b;

				case '/':
					return a / b;

				case '^':
					return Math.Pow(a, b);

				default:
					throw new ArgumentOutOfRangeException(nameof(c));
			}
		}

		private static bool IsOperator(char c)
		{
			return _operators.ContainsKey(c);
		}

		private static bool HasHigherPrecedence(char current, char compareAgainst)
		{
			if (!IsOperator(current) || !IsOperator(compareAgainst))
			{
				throw new ArgumentException(
					$"Either '{current.ToString(CultureInfo.InvariantCulture)}' or '{compareAgainst.ToString(CultureInfo.InvariantCulture)}' are not operators");
			}

			if (_operators[current] == _operators[compareAgainst])
			{
				return !IsOperatorRightAssociation(current);
			}

			return
				_operators[current] > _operators[compareAgainst];
		}

		private static bool IsOpenedParenthesis(char c)
		{
			return _openParenthesis.ContainsKey(c);
		}

		private static bool IsClosedParenthesis(char c)
		{
			return _closedParenthesis.ContainsKey(c);
		}

		private static bool IsOperand(char c)
		{
			return
				!IsOpenedParenthesis(c)
				&& !IsClosedParenthesis(c)
				&& !IsOperator(c)
				&& !char.IsWhiteSpace(c);
		}

		private static bool AreOpenAndCloseParenthesisAMatch(
			char candidateOpened, char candidateClosed)
		{
			return
				IsOpenedParenthesis(candidateOpened)
				&& IsClosedParenthesis(candidateClosed)
				&& _openParenthesis[candidateOpened] == candidateClosed;
		}

		private static bool IsOperatorRightAssociation(char c)
		{
			return c == '^';
		}
	}
}
