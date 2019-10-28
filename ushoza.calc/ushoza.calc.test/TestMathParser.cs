using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ushoza.calc.test
{
    [TestFixture]
    public class TestMathParser : TestParser
    {
        [SetUp]
        public override void Init()
        {
            parser = new MathParser();
        }

        [TestCase("^")]
        public void MustBeReturnRoof(string expression)
        {
            IList<Token> actual = parser.Parse(expression);
            List<Token> expected = new List<Token>();
            TokenOperation oper = new TokenOperation();
            oper.value = "^";
            expected.Add(oper);
            Assert.AreEqual(expected, actual);
        }
        [TestCase("2^3")]
            public void MustBeReturnList2step3(string expression)
        {
            IList<Token> actual = parser.Parse(expression);
            List<Token> expected = new List<Token>();
            TokenOperand op1 = new TokenOperand();
            op1.value = "2";
            TokenOperation oper = new TokenOperation();
            oper.value = "^";
            TokenOperand op2 = new TokenOperand();
            op2.value = "3";
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
            op1.value = "2";
            TokenOperation oper = new TokenOperation();
            oper.value = "^";
            TokenOperand op2 = new TokenOperand();
            op2.value = "3";
            TokenOperation op3 = new TokenOperation();
            op3.value = "+";
            TokenOperand op4 = new TokenOperand();
            op4.value = "4";
            TokenOperation op5 = new TokenOperation();
            op5.value = "-";
            TokenOperand op6 = new TokenOperand();
            op6.value = "2";
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
            op1.value = "2";
            TokenOperation oper = new TokenOperation();
            oper.value = "^";
            TokenBracket brOpen = new TokenBracket();
            brOpen.isOpened = true;
            brOpen.value = "(";
            TokenOperand op2 = new TokenOperand();
            op2.value = "3";
            TokenOperation op3 = new TokenOperation();
            op3.value = "+";
            TokenOperand op4 = new TokenOperand();
            op4.value = "4";
            TokenOperation op5 = new TokenOperation();
            op5.value = "-";
            TokenOperand op6 = new TokenOperand();
            op6.value = "2";
            TokenBracket brClose = new TokenBracket();
            brOpen.isOpened = false;
            brClose.value = ")";
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
    }
}
