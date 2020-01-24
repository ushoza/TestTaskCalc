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
    public class TestMathParser : TestParser
    {
        [SetUp]
        public override void Init()
        {
            IGrammar grammar = new MathGrammar();
            ITokensValidator validator = new DefaultValidator();
            parser = new DefaultParser(grammar, validator);
        }

        [TestCase("^")]
        public void MustBeReturnCalcBadSyntaxRxception(string expression)
        {
            Assert.Throws<CalcBadSyntaxException>(() => parser.Parse(expression));
        }
        [TestCase("2^3")]
            public void MustBeReturnList2step3(string expression)
        {
            IList<Token> actual = parser.Parse(expression);
            List<Token> expected = new List<Token>();
            TokenOperand op1 = new TokenOperand();
            op1.Value = "2";
            DefaultTokenOperation oper = new DefaultTokenOperation();
            oper.Value = "^";
            TokenOperand op2 = new TokenOperand();
            op2.Value = "3";
            expected.Add(op1);
            expected.Add(oper);
            expected.Add(op2);
            Assert.AreEqual(expected, actual);

        }

        [Test]
       // [TestCase("2^3")]
        public void MustBeReturnList2and1step3()
        {
            string expression = "2" + dec_sep +"1"+ "^3";
            IList<Token> actual = parser.Parse(expression);
            List<Token> expected = new List<Token>();
            TokenOperand op1 = new TokenOperand();
            op1.Value = "2" + dec_sep + "1";
            DefaultTokenOperation oper = new DefaultTokenOperation();
            oper.Value = "^";
            TokenOperand op2 = new TokenOperand();
            op2.Value = "3";
            expected.Add(op1);
            expected.Add(oper);
            expected.Add(op2);
            Assert.AreEqual(expected, actual);

        }

        [TestCase("2^3+4-2")]
        public void MustBeReturnListTwoFreePlusFourMinusTwo(string expression)
        {
            IList<Token> actual = parser.Parse(expression);
            List<Token> expected = new List<Token>();
            TokenOperand op1 = new TokenOperand();
            op1.Value = "2";
            DefaultTokenOperation oper = new DefaultTokenOperation();
            oper.Value = "^";
            TokenOperand op2 = new TokenOperand();
            op2.Value = "3";
            DefaultTokenOperation op3 = new DefaultTokenOperation();
            op3.Value = "+";
            TokenOperand op4 = new TokenOperand();
            op4.Value = "4";
            DefaultTokenOperation op5 = new DefaultTokenOperation();
            op5.Value = "-";
            TokenOperand op6 = new TokenOperand();
            op6.Value = "2";
            expected.Add(op1);
            expected.Add(oper);
            expected.Add(op2);
            expected.Add(op3);
            expected.Add(op4);
            expected.Add(op5);
            expected.Add(op6);
            Assert.AreEqual(expected, actual);

        }

        [TestCase("2^(3+4-2)")]
        public void MustBeReturnListTwoFreePlusFourMinusTwoWithBrackets(string expression)
        {
            IList<Token> actual = parser.Parse(expression);
            List<Token> expected = new List<Token>();
            TokenOperand op1 = new TokenOperand();
            op1.Value = "2";
            DefaultTokenOperation oper = new DefaultTokenOperation();
            oper.Value = "^";
            TokenBracket brOpen = new TokenBracket();
           // brOpen.isOpened = true;
            brOpen.Value = "(";
            TokenOperand op2 = new TokenOperand();
            op2.Value = "3";
            DefaultTokenOperation op3 = new DefaultTokenOperation();
            op3.Value = "+";
            TokenOperand op4 = new TokenOperand();
            op4.Value = "4";
            DefaultTokenOperation op5 = new DefaultTokenOperation();
            op5.Value = "-";
            TokenOperand op6 = new TokenOperand();
            op6.Value = "2";
            TokenBracket brClose = new TokenBracket();
            //brOpen.isOpened = false;
            brClose.Value = ")";
            expected.Add(op1);
            expected.Add(oper);
            expected.Add(brOpen);
            expected.Add(op2);
            expected.Add(op3);
            expected.Add(op4);
            expected.Add(op5);
            expected.Add(op6);
            expected.Add(brClose);
            Assert.AreEqual(expected, actual);

        }

        [TestCase("6/2^2")]
        public void MustBeReturnList6dev2exp2(string expression)
        {
            IList<Token> actual = parser.Parse(expression);
            List<Token> expected = new List<Token>();
            TokenOperand op1 = new TokenOperand();
            op1.Value = "6";
            DefaultTokenOperation oper = new DefaultTokenOperation();
            oper.Value = "/";
            TokenOperand op2 = new TokenOperand();
            op2.Value = "2";
            DefaultTokenOperation op3 = new DefaultTokenOperation();
            op3.Value = "^";
            TokenOperand op4 = new TokenOperand();
            op4.Value = "2";
            expected.Add(op1);
            expected.Add(oper);
            expected.Add(op2);
            expected.Add(op3);
            expected.Add(op4);
            Assert.AreEqual(expected, actual);

        }
    }
}
