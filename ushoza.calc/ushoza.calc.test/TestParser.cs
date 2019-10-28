using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ushoza.calc.Exceptions;

namespace ushoza.calc.test
{
    [TestFixture]
    public class TestParser
    {
        protected  Parser parser;

        [SetUp]
        public virtual void Init()
        {
            parser = new Parser();
        }

        [TestCase("7")]
        [TestCase("23")]
        [TestCase("10")]
        [TestCase(" 45")]
        public void ShouldBeOperand(string expression)
        {
            
            IList<Token> actualListToken = parser.Parse(expression);
            TokenOperand operand = new TokenOperand() { value = expression.Trim() };
            Assert.AreEqual(operand.value, actualListToken[0].value);
            
        }
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void ShouldBeOperation(string expression)
        {
            
            IList<Token> actualListToken = parser.Parse(expression);
            TokenOperation expectedTokenOperation = new TokenOperation() { value = expression.Trim() };
            Assert.AreEqual(expectedTokenOperation, actualListToken[0]);
        }
        [TestCase("2+3", "2", "+", "3")]
        [TestCase (" 3 + 2 ", " 3 ", "+", " 2 ")]
        public void HasExpressionShouldBeTokenList(string expression, string op1, string operation, string op2)
        {
            
            IList<Token> actualListToken = parser.Parse(expression);
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenOperand() { value = op1.Trim().ToString() });
            expectedListToken.Add(new TokenOperation() { value = operation.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { value = op2.Trim().ToString() });
            Assert.AreEqual(expectedListToken, actualListToken);
        }

        [TestCase("2/")]
        [TestCase("2++3")]
        [TestCase("2 - / 4")]
        [TestCase("2a / 4")]
        public void ShouldBeBadSyntaxisException(string expression)
        {
            
            Assert.Throws<CalcBadSyntaxException>(() => parser.Parse(expression));
            //Assert.That(parser.Parse(expression), Throws.TypeOf<CalcBadSyntaxException>());
        }
        [Test]
        public void ShouldBeEqual()
        {
            TokenOperand actual = new TokenOperand();
            actual.value = "2";
            List<Token> actualListToken = new List<Token>();
            actualListToken.Add(actual);
            TokenOperand expected = new TokenOperand();
            expected.value = "2";
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(expected);
            Assert.AreEqual(expectedListToken, actualListToken);
        }

        [TestCase("((2+3)*2-5)","(", "(", "2", "+", "3", ")", "*", "2", "-", "5", ")")]
        public void HasExpressionShouldBeTokenListWithBrackets(string expression, string oBr1, string oBr2, string op1,
            string operPlus, string op2, string clBr1, string opeMult, string op3, string operMinus, string op4, string clBr2)
        {

            IList<Token> actualListToken = parser.Parse(expression);
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenBracket() { value = oBr1.Trim().ToString(), isOpened = true });
            expectedListToken.Add(new TokenBracket() { value = oBr2.Trim().ToString(), isOpened = true });
            expectedListToken.Add(new TokenOperand() { value = op1.Trim().ToString() });
            expectedListToken.Add(new TokenOperation() { value = operPlus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { value = op2.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { value = clBr1.Trim().ToString(), isOpened = false });
            expectedListToken.Add(new TokenOperation() { value = opeMult.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { value = op3.Trim().ToString() });
            expectedListToken.Add(new TokenOperation() { value = operMinus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { value = op4.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { value = clBr2.Trim().ToString(), isOpened = false });
            Assert.AreEqual(expectedListToken, actualListToken);
        }
    }
}
