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
             
        [Test]
        public void TestCalSimpleExpression()
        {
            List<Token> source = new List<Token>() { new TokenOperand() { value = "2"},
                                                     new TokenOperation () { value ="+"},
                                                     new TokenOperand() { value = "2"}
                                                   };
            Alu alu = new Alu();
            int actual = alu.Calc(source);
            int expected = 4;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestCalcComplexExpression()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { value = "2"},
                                                     new TokenOperation () { value ="+", Priority = 10},
                                                     new TokenOperand() { value = "3"},
                                                     new TokenOperation() { value = "*", Priority = 20},
                                                     new TokenOperand() { value = "8"},
                                                   };
            Alu alu = new Alu();
            int actual = alu.Calc(source);
            int expected = 26;
            Assert.AreEqual(expected, actual);
        }
       
        [Test]
        public void TestPolishNotation()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { value = "2"},
                                                     new TokenOperation () { value ="+", Priority = 10},
                                                     new TokenOperation() { value = "sin", Priority = 20},
                                                     new TokenOperand() { value = "90"},
                                                     new TokenOperation() { value = "-", Priority = 10},
                                                     new TokenOperand() { value = "1"}
                                                   };
            Alu alu = new Alu();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> actual = new Queue<Token>();
            alu.GetPolishNotation(source, temp, actual);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { value = "2" });
            expected.Enqueue(new TokenOperand() { value = "90" });
            expected.Enqueue(new TokenOperation() { value = "sin" });
            expected.Enqueue(new TokenOperation() { value = "+" });
            expected.Enqueue(new TokenOperand() { value = "1" });
            expected.Enqueue(new TokenOperation() { value = "-" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotation2()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { value = "2"},
                                                     new TokenOperation () { value ="+", Priority = 10},
                                                     new TokenOperand() { value = "3"},
                                                     new TokenOperation() { value = "*", Priority = 20},
                                                     new TokenOperand() { value = "90"},
                                                     new TokenOperation() { value = "-", Priority = 10},
                                                     new TokenOperand() { value = "1"}
                                                   };
            Alu alu = new Alu();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> actual = new Queue<Token>();
            alu.GetPolishNotation(source, temp, actual);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { value = "2" });
            expected.Enqueue(new TokenOperand() { value = "3" });
            expected.Enqueue(new TokenOperand() { value = "90" });
            expected.Enqueue(new TokenOperation() { value = "*" });
            expected.Enqueue(new TokenOperation() { value = "+" });
            expected.Enqueue(new TokenOperand() { value = "1" });
            expected.Enqueue(new TokenOperation() { value = "-" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotation3()
        {

            List<Token> source = new List<Token>() { new TokenOperand() { value = "2"},
                                                     new TokenOperation () { value ="+", Priority = 10},
                                                     new TokenOperand() { value = "3"},
                                                     new TokenOperation() { value = "*", Priority = 20},
                                                     new TokenOperand() { value = "8"},
                                                    };
            Alu alu = new Alu();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> actual = new Queue<Token>();
            alu.GetPolishNotation(source, temp, actual);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { value = "2" });
            expected.Enqueue(new TokenOperand() { value = "3" });
            expected.Enqueue(new TokenOperand() { value = "8" });
            expected.Enqueue(new TokenOperation() { value = "*" });
            expected.Enqueue(new TokenOperation() { value = "+" });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPolishNotationWithBreakets()
        {

            List<Token> source = new List<Token>() { new TokenBracket() { value = "(", isOpened = true, Priority = 5},
                                                     new TokenOperand() { value = "2"},
                                                     new TokenOperation () { value ="+", Priority = 10},
                                                     new TokenOperand() { value = "3"},
                                                     new TokenBracket() { value = ")", isOpened = false, Priority = 5},
                                                     new TokenOperation() { value = "*", Priority = 20},
                                                     new TokenOperand() { value = "8"},
                                                    };
            Alu alu = new Alu();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> actual = new Queue<Token>();
            alu.GetPolishNotation(source, temp, actual);
            Queue<Token> expected = new Queue<Token>();
            expected.Enqueue(new TokenOperand() { value = "2" });
            expected.Enqueue(new TokenOperand() { value = "3" });
            expected.Enqueue(new TokenOperation() { value = "+" });
            expected.Enqueue(new TokenOperand() { value = "8" });
            expected.Enqueue(new TokenOperation() { value = "*" });
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCalcSimpleWithBreakets()
        {

            List<Token> source = new List<Token>() { new TokenBracket() { value = "(", isOpened = true, Priority = 5},
                                                     new TokenOperand() { value = "2"},
                                                     new TokenOperation () { value ="+", Priority = 10},
                                                     new TokenOperand() { value = "3"},
                                                     new TokenBracket() { value = ")", isOpened = false, Priority = 5},
                                                     new TokenOperation() { value = "*", Priority = 20},
                                                     new TokenOperand() { value = "8"},
                                                    };
            Alu alu = new Alu();
            int actual = alu.Calc(source);
            int expected = 40;

            Assert.AreEqual(expected, actual);
        }
    }
}
