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
            TokenOperand operand = new TokenOperand() { Value = expression.Trim() };
            Assert.AreEqual(operand.Value, actualListToken[0].Value);
            
        }
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void ShouldBeOperation(string expression)
        {
            
            IList<Token> actualListToken = parser.Parse(expression);
            TokenOperation expectedTokenOperation = new TokenOperation() { Value = expression.Trim() };
            Assert.AreEqual(expectedTokenOperation, actualListToken[0]);
        }
        [TestCase("2+3", "2", "+", "3")]
        [TestCase (" 3 + 2 ", " 3 ", "+", " 2 ")]
        public void HasExpressionShouldBeTokenList(string expression, string op1, string operation, string op2)
        {
            
            IList<Token> actualListToken = parser.Parse(expression);
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenOperand() { Value = op1.Trim().ToString() });
            expectedListToken.Add(new TokenOperation() { Value = operation.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op2.Trim().ToString() });
            Assert.AreEqual(expectedListToken, actualListToken);
        }

        [TestCase("2/")]
        [TestCase("2++3")]
        [TestCase("2 - / 4")]
        [TestCase("2a / 4")]
        [TestCase("2+3(4-5)")]
        public void ShouldBeBadSyntaxisException(string expression)
        {
            
            Assert.Throws<CalcBadSyntaxException>(() => parser.Parse(expression));
            //Assert.That(parser.Parse(expression), Throws.TypeOf<CalcBadSyntaxException>());
        }
        [Test]
        public void ShouldBeEqual()
        {
            TokenOperand actual = new TokenOperand();
            actual.Value = "2";
            List<Token> actualListToken = new List<Token>();
            actualListToken.Add(actual);
            TokenOperand expected = new TokenOperand();
            expected.Value = "2";
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
            expectedListToken.Add(new TokenBracket() { Value = oBr1.Trim().ToString(), isOpened = true });
            expectedListToken.Add(new TokenBracket() { Value = oBr2.Trim().ToString(), isOpened = true });
            expectedListToken.Add(new TokenOperand() { Value = op1.Trim().ToString() });
            expectedListToken.Add(new TokenOperation() { Value = operPlus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op2.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { Value = clBr1.Trim().ToString(), isOpened = false });
            expectedListToken.Add(new TokenOperation() { Value = opeMult.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op3.Trim().ToString() });
            expectedListToken.Add(new TokenOperation() { Value = operMinus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op4.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { Value = clBr2.Trim().ToString(), isOpened = false });
            Assert.AreEqual(expectedListToken, actualListToken);
        }

        [TestCase("(1+2)*4+3", "(", "1", "+", "2", ")", "*", "4", "+", "3")]
        public void HasExpressionShouldBeTokenListWithBrackets(string expression, string oBr1,  string op1,
            string operPlus, string op2, string clBr1, string opeMult, string op3, string operPlus2, string op4)
        {

            IList<Token> actualListToken = parser.Parse(expression);
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenBracket() { Value = oBr1.Trim().ToString(), isOpened = true });
            expectedListToken.Add(new TokenOperand() { Value = op1.Trim().ToString() });
            expectedListToken.Add(new TokenOperation() { Value = operPlus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op2.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { Value = clBr1.Trim().ToString(), isOpened = false });
            expectedListToken.Add(new TokenOperation() { Value = opeMult.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op3.Trim().ToString() });
            expectedListToken.Add(new TokenOperation() { Value = operPlus2.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op4.Trim().ToString() });
            Assert.AreEqual(expectedListToken, actualListToken);
        }
    }
}
