﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ushoza.calc.test
{
    
    [TestFixture]
    public class TestAlu
    {
        string dec_sep = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        [Test]
        public void TestCalSimpleExpression()
        {
            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "2"}
                                                   };
            DefaultAlu alu = new DefaultAlu();
            decimal actual = alu.Calc(source);
            decimal expected = 4;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestCalSimpleExpressionDecimal()
        {
            
            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"+dec_sep+"2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "2"+dec_sep+"3"}
                                                   };
            DefaultAlu alu = new DefaultAlu();
            decimal actual = alu.Calc(source);
            decimal expected = 4.5M;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestCalcComplexExpression()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new DefaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "8"},
                                                   };
            DefaultAlu alu = new DefaultAlu();
            decimal actual = alu.Calc(source);
            decimal expected = 26;
            Assert.AreEqual(expected, actual);
        }
       
        

        [Test]
        public void TestPolishNotationSimple2Plus3Mult90Minus1()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new DefaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "90"},
                                                     new DefaultTokenOperation() { Value = "-"},
                                                     new TokenOperand() { Value = "1"}
                                                   };
            DefaultAlu alu = new DefaultAlu();
            Stack<Token> temp = new Stack<Token>();
            DefaultPolNotationConverter converter = new DefaultPolNotationConverter();
            Queue<Token> actual = converter.Convert(source);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new TokenOperand() { Value = "3" });
            expected.Enqueue(new TokenOperand() { Value = "90" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "*" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "+" });
            expected.Enqueue(new TokenOperand() { Value = "1" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "-" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotation2plus3Mult8()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new DefaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "8"},
                                                    };
            DefaultAlu alu = new DefaultAlu();
            Stack<Token> temp = new Stack<Token>();
            DefaultPolNotationConverter converter = new DefaultPolNotationConverter();
            Queue<Token> actual = converter.Convert(source);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new TokenOperand() { Value = "3" });
            expected.Enqueue(new TokenOperand() { Value = "8" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "*" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "+" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotationWithBreakets()
        {

            List<Token> source = new List<Token>() { new TokenBracket() { Value = "("},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new TokenBracket() { Value = ")"},
                                                     new DefaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "8"},
                                                    };
            DefaultAlu alu = new DefaultAlu();
            Stack<Token> temp = new Stack<Token>();
            DefaultPolNotationConverter converter = new DefaultPolNotationConverter();
            Queue<Token> actual = converter.Convert(source);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new TokenOperand() { Value = "3" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "+" });
            expected.Enqueue(new TokenOperand() { Value = "8" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "*" });
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalcSimpleWithBreakets()
        {

            List<Token> source = new List<Token>() { new TokenBracket() { Value = "("},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new TokenBracket() { Value = ")"},
                                                     new DefaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "8"},
                                                    };
            DefaultAlu alu = new DefaultAlu();
            decimal actual = alu.Calc(source);
            decimal expected = 40;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalcSimpleWithBreakets2()
        {

            List<Token> source = new List<Token>() {
                                                     new TokenOperand(){ Value = "3"},
                                                     new DefaultTokenOperation(){ Value = "+"},
                                                     new TokenOperand(){ Value = "2"},
                                                     new DefaultTokenOperation(){ Value = "*"},
                                                     new TokenBracket() { Value = "("},
                                                     new TokenOperand() { Value = "3"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "4"},
                                                     new TokenBracket() { Value = ")"},

                                                    };
            DefaultAlu alu = new DefaultAlu();
            decimal actual = alu.Calc(source);
            decimal expected = 17;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalcExpressionWithExpMustbe1and5()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "6"},
                                                     new DefaultTokenOperation () { Value ="/"},
                                                     new TokenOperand() { Value = "2"},
                                                     new MathTokenOperation() { Value = "^"},
                                                     new TokenOperand() { Value = "2"},
                                                   };
            DefaultAlu alu = new DefaultAlu();
            decimal actual = alu.Calc(source);
            decimal expected = 1.5M;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalcExpressionWithExpMustbe274()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "6"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "2"},
                                                     new MathTokenOperation() { Value = "^"},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="*"},
                                                     new TokenBracket(){ Value = "("},
                                                     new TokenOperand() { Value = "8"},
                                                     new MathTokenOperation() { Value = "^"},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new TokenBracket(){ Value = ")"}
                                                   };
            DefaultAlu alu = new DefaultAlu();
            decimal actual = alu.Calc(source);
            decimal expected = 274;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalcExpressionMustbe198()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "6"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="*"},
                                                     new TokenBracket(){ Value = "("},
                                                     new TokenOperand() { Value = "8"},
                                                     new DefaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new TokenBracket(){ Value = ")"}
                                                   };
            DefaultAlu alu = new DefaultAlu();
            decimal actual = alu.Calc(source);
            decimal expected = 82;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotationWithBreaketsBrecketsInTheMiddle()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new MathTokenOperation () { Value ="^"},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation() { Value = "*"},
                                                     new TokenBracket(){ Value = "("},
                                                     new TokenOperand() { Value = "8"},
                                                     new MathTokenOperation() { Value = "^"},
                                                     new TokenOperand() { Value = "2"},
                                                     new DefaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new TokenBracket(){ Value = ")"}
                                                   };
            DefaultAlu alu = new DefaultAlu();
            DefaultPolNotationConverter converter = new DefaultPolNotationConverter();
            Queue<Token> actual = converter.Convert(source);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new MathTokenOperation() { Value = "^" });
            expected.Enqueue(new TokenOperand() { Value = "8" });
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new MathTokenOperation() { Value = "^" });
            expected.Enqueue(new TokenOperand() { Value = "3" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "+" });
            expected.Enqueue(new DefaultTokenOperation() { Value = "*" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSimpleNegativeExpression()
        {
            string sourceStr = "-3+2*(2-1)";
            IGrammar grammar = new MathGrammar();
            ITokensValidator validator = new DefaultValidator();
            DefaultParser parser = new DefaultParser(grammar, validator);
            List<Token> source = parser.Parse(sourceStr);
            DefaultAlu defaultAlu = new DefaultAlu();
            decimal actual = defaultAlu.Calc(source);
            decimal expected = -1M;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestSimpleNegativeExpressionLong()
        {
            string sourceStr = "-3/2-4+(-5/2)";
            IGrammar grammar = new MathGrammar();
            ITokensValidator validator = new DefaultValidator();
            DefaultParser parser = new DefaultParser(grammar, validator);
            List<Token> source = parser.Parse(sourceStr);
            DefaultAlu defaultAlu = new DefaultAlu();
            decimal actual = defaultAlu.Calc(source);
            decimal expected = -8M;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestMathCalc()
        {
            string sourceStr = "2^3*5";
            IGrammar grammar = new MathGrammar();
            ITokensValidator validator = new DefaultValidator();
            DefaultParser parser = new DefaultParser(grammar, validator);
            List<Token> source = parser.Parse(sourceStr);
            DefaultAlu defaultAlu = new DefaultAlu();
            decimal actual = defaultAlu.Calc(source);
            decimal expected = 40;
            Assert.AreEqual(expected, actual);

        }
    }
}
