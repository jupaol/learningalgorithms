using Core.Domain.General;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General
{
	[TestClass]
	public class ArithmeticExpressionExtensionsTests
	{
		[TestClass]
		public class TheToPostfixExpressionMethod
		{
			[TestMethod]
			public void It_should_convert_an_infix_expression_to_postfix()
			{
				string source;
				string res;

				source = "1 + ( 4 * 6) ";
				res = source.ToPostfixExpression();
				res.Should().Be("1,4,6*+");

				source = "[8 + 7] / (1 + ( 4 * 6)) / {8 + 3 ^ 3} ";
				res = source.ToPostfixExpression();
				res.Should().Be("8,7+1,4,6*+/8,3,3^+/");

				source = "[8 + 7] / (1.0 + ( 4 * 6.2)) / {8 + 3.456 ^ 3} ";
				res = source.ToPostfixExpression();
				res.Should().Be("8,7+1.0,4,6.2*+/8,3.456,3^+/");
			}
		}

		[TestClass]
		public class TheEvaluatePostfixExpressionMethod
		{
			[TestMethod]
			public void It_should_evaluate_the_postfix_arithmetic_expression()
			{
				string source;
				string expression;
				double res;

				source = "1 + ( 4 * 6) ";
				expression = source.ToPostfixExpression();
				expression.Should().Be("1,4,6*+");
				res = expression.EvaluatePostfixExpression();
				res.Should().Be(25, source);

				source = "[8 + 7] / (1 + ( 4 * 6)) / {8 + 3 ^ 3} ";
				expression = source.ToPostfixExpression();
				expression.Should().Be("8,7+1,4,6*+/8,3,3^+/");
				res = expression.EvaluatePostfixExpression();
				res.Should().Be(0.017142857142857144, source);

				source = "[8 + 7] / (1.0 + ( 4 * 6.2)) / {8 + 3.456 ^ 3} ";
				expression = source.ToPostfixExpression();
				expression.Should().Be("8,7+1.0,4,6.2*+/8,3.456,3^+/");
				res = expression.EvaluatePostfixExpression();
				res.Should().Be(0.011798215918698261, source);
			}
		}
	}
}
