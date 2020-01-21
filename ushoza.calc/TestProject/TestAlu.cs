using NUnit.Framework;
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
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "2"}
                                                   };
            Alu alu = new Alu();
            decimal actual = alu.Calc(source);
            decimal expected = 4;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestCalSimpleExpressionDecimal()
        {
            
            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"+dec_sep+"2"},
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "2"+dec_sep+"3"}
                                                   };
            Alu alu = new Alu();
            decimal actual = alu.Calc(source);
            decimal expected = 4.5M;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestCalcComplexExpression()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new DafaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "8"},
                                                   };
            Alu alu = new Alu();
            decimal actual = alu.Calc(source);
            decimal expected = 26;
            Assert.AreEqual(expected, actual);
        }
       
        [Test]
        public void TestPolishNotation()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new DafaultTokenOperation() { Value = "sin"},
                                                     new TokenOperand() { Value = "90"},
                                                     new DafaultTokenOperation() { Value = "-"},
                                                     new TokenOperand() { Value = "1"}
                                                   };
            Alu alu = new Alu();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> actual = new Queue<Token>();
            alu.GetPolishNotation(source, temp, actual);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new TokenOperand() { Value = "90" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "sin" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "+" });
            expected.Enqueue(new TokenOperand() { Value = "1" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "-" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotation2()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new DafaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "90"},
                                                     new DafaultTokenOperation() { Value = "-"},
                                                     new TokenOperand() { Value = "1"}
                                                   };
            Alu alu = new Alu();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> actual = new Queue<Token>();
            alu.GetPolishNotation(source, temp, actual);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new TokenOperand() { Value = "3" });
            expected.Enqueue(new TokenOperand() { Value = "90" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "*" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "+" });
            expected.Enqueue(new TokenOperand() { Value = "1" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "-" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotation3()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { Value = "2"},
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new DafaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "8"},
                                                    };
            Alu alu = new Alu();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> actual = new Queue<Token>();
            alu.GetPolishNotation(source, temp, actual);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new TokenOperand() { Value = "3" });
            expected.Enqueue(new TokenOperand() { Value = "8" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "*" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "+" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotationWithBreakets()
        {

            List<Token> source = new List<Token>() { new TokenBracket() { Value = "(", isOpened = true},
                                                     new TokenOperand() { Value = "2"},
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new TokenBracket() { Value = ")", isOpened = false},
                                                     new DafaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "8"},
                                                    };
            Alu alu = new Alu();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> actual = new Queue<Token>();
            alu.GetPolishNotation(source, temp, actual);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { Value = "2" });
            expected.Enqueue(new TokenOperand() { Value = "3" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "+" });
            expected.Enqueue(new TokenOperand() { Value = "8" });
            expected.Enqueue(new DafaultTokenOperation() { Value = "*" });
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalcSimpleWithBreakets()
        {

            List<Token> source = new List<Token>() { new TokenBracket() { Value = "(", isOpened = true},
                                                     new TokenOperand() { Value = "2"},
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "3"},
                                                     new TokenBracket() { Value = ")", isOpened = false},
                                                     new DafaultTokenOperation() { Value = "*"},
                                                     new TokenOperand() { Value = "8"},
                                                    };
            Alu alu = new Alu();
            decimal actual = alu.Calc(source);
            decimal expected = 40;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalcSimpleWithBreakets2()
        {

            List<Token> source = new List<Token>() {
                                                     new TokenOperand(){ Value = "3"},
                                                     new DafaultTokenOperation(){ Value = "+"},
                                                     new TokenOperand(){ Value = "2"},
                                                     new DafaultTokenOperation(){ Value = "*"},
                                                     new TokenBracket() { Value = "(", isOpened = true},
                                                     new TokenOperand() { Value = "3"},
                                                     new DafaultTokenOperation () { Value ="+"},
                                                     new TokenOperand() { Value = "4"},
                                                     new TokenBracket() { Value = ")", isOpened = false},

                                                    };
            Alu alu = new Alu();
            decimal actual = alu.Calc(source);
            decimal expected = 17;

            Assert.AreEqual(expected, actual);
        }
    }
}
