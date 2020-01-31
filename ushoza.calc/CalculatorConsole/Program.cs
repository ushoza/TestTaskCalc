﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ushoza.calc;

namespace ushoza.calc
{
    class Program
    {
        static void Main(string[] args)
        {
           
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите выражение:");
                    string forCalc = Console.ReadLine();
                    DefaultAlu alu = new DefaultAlu();
                    IGrammar grammar = new MathGrammar();
                    ITokensValidator validator = new DefaultValidator();
                    DefaultParser mathParser = new DefaultParser(grammar, validator);
                    List<Token> tokens = mathParser.Parse(forCalc);
                    Console.WriteLine("Результат: " + alu.Calc(tokens));
                }
                catch (ushoza.calc.Exceptions.CalcBadSyntaxException ex)
                {
                    Console.WriteLine("Синтаксическая ошибка");
                }
                catch (ushoza.calc.Exceptions.CalcException ex)
                {
                    Console.WriteLine("Ошибка в записи выражения");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message + " Stack: " + ex.StackTrace);
                }
                
            }
            
            
        }
    }
}
