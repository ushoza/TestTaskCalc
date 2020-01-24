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
        protected  DefaultParser parser;
        protected string dec_sep = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        [SetUp]
        public virtual void Init()
        {
            IGrammar grammar = new DefaultGrammar();
            ITokensValidator validator = new DefaultValidator();
            parser = new DefaultParser(grammar, validator);
            
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

        [Test]
        public void ShouldBeOperandWitDecPlaces()
        {
            string expression = "7" + dec_sep + "3";
            IList<Token> actualListToken = parser.Parse(expression);
            TokenOperand operand = new TokenOperand() { Value = expression.Trim() };
            Assert.AreEqual(operand.Value, actualListToken[0].Value);

        }
        [Test]
        public void ShouldBeOperandWitDecPlaces_WithWiteSpece()
        {
             string expression = "7 " + dec_sep + " 3";
            IList<Token> actualListToken = parser.Parse(expression);
            TokenOperand operand = new TokenOperand() { Value = expression.Replace(" ", "") };
            Assert.AreEqual(operand.Value, actualListToken[0].Value);

        }
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void ShouldBeOperation(string expression)
        {
            
            IList<Token> actualListToken = parser.Parse(expression);
            DefaultTokenOperation expectedTokenOperation = new DefaultTokenOperation() { Value = expression.Trim() };
            Assert.AreEqual(expectedTokenOperation, actualListToken[0]);
        }
        [TestCase("2+3", "2", "+", "3")]
        [TestCase (" 3 + 2 ", " 3 ", "+", " 2 ")]
        public void HasExpressionShouldBeTokenList(string expression, string op1, string operation, string op2)
        {
            
            IList<Token> actualListToken = parser.Parse(expression);
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenOperand() { Value = op1.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = operation.Trim().ToString() });
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
            expectedListToken.Add(new TokenBracket() { Value = oBr1.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { Value = oBr2.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op1.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = operPlus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op2.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { Value = clBr1.Trim().ToString()});
            expectedListToken.Add(new DefaultTokenOperation() { Value = opeMult.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op3.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = operMinus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op4.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { Value = clBr2.Trim().ToString() });
            Assert.AreEqual(expectedListToken, actualListToken);
        }

        [TestCase("(1+2)*4+3", "(", "1", "+", "2", ")", "*", "4", "+", "3")]
        public void HasExpressionShouldBeTokenListWithBrackets(string expression, string oBr1,  string op1,
            string operPlus, string op2, string clBr1, string opeMult, string op3, string operPlus2, string op4)
        {

            IList<Token> actualListToken = parser.Parse(expression);
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenBracket() { Value = oBr1.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op1.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = operPlus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op2.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { Value = clBr1.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = opeMult.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op3.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = operPlus2.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op4.Trim().ToString() });
            Assert.AreEqual(expectedListToken, actualListToken);
        }

        [Test]
        //[TestCase("(1+2)*4+3", "(", "1", "+", "2", ")", "*", "4", "+", "3")]
        public void HasExpressionShouldBeTokenListWithBracketsWithDecimal()
        {
            string expression = "(1" + dec_sep + "1" + "+2)*4+3" + dec_sep + "2";
            string oBr1 = "(";
            string op1 = "1" + dec_sep + "1";
            string operPlus = "+";
            string op2 = "2";
            string clBr1 = ")";
            string opeMult = "*";
            string op3 = "4";
            string operPlus2 = "+";
            string op4 = "3" + dec_sep + "2";

            IList<Token> actualListToken = parser.Parse(expression);
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenBracket() { Value = oBr1.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op1.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = operPlus.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op2.Trim().ToString() });
            expectedListToken.Add(new TokenBracket() { Value = clBr1.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = opeMult.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op3.Trim().ToString() });
            expectedListToken.Add(new DefaultTokenOperation() { Value = operPlus2.Trim().ToString() });
            expectedListToken.Add(new TokenOperand() { Value = op4.Trim().ToString() });
            Assert.AreEqual(expectedListToken, actualListToken);
        }

        //[TestCase("-3+8*4", "-", "3","+","8", "*", "4")]
        [Test]
        public void ShouldBeTokenListWithNegativeNumbersSimple()
        {
            string expression = "-3+8*4";
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenOperand() {Value=-3 });
            expectedListToken.Add(new DefaultTokenOperation() { Value = "+" });
            expectedListToken.Add(new TokenOperand() { Value = 8 });
            expectedListToken.Add(new DefaultTokenOperation() { Value = "*" });
            expectedListToken.Add(new TokenOperand() { Value = 4 });
            List<Token> actualListToken = parser.Parse(expression);
            Assert.AreEqual(expectedListToken, actualListToken);
        }

        [Test]
        public void ShouldBeTokenListWithNegativeNumbersAndBrackets()
        {
            string expression = "-3+8*4+(-5+9)";
            List<Token> expectedListToken = new List<Token>();
            expectedListToken.Add(new TokenOperand() { Value = -3 });
            expectedListToken.Add(new DefaultTokenOperation() { Value = "+" });
            expectedListToken.Add(new TokenOperand() { Value = 8 });
            expectedListToken.Add(new DefaultTokenOperation() { Value = "*" });
            expectedListToken.Add(new TokenOperand() { Value = 4 });
            expectedListToken.Add(new DefaultTokenOperation() { Value = "+" });
            expectedListToken.Add(new TokenBracket() { Value = "("});
            expectedListToken.Add(new TokenOperand() { Value = -5 });
            expectedListToken.Add(new DefaultTokenOperation() { Value = "+" });
            expectedListToken.Add(new TokenOperand() { Value = 9 });
            expectedListToken.Add(new TokenBracket() { Value = ")" });
            List<Token> actualListToken = parser.Parse(expression);
            Assert.AreEqual(expectedListToken, actualListToken);
        }
    }
}
