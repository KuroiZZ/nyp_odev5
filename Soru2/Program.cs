using System;

namespace Workspace
{
    internal class Program
    {
        internal static void Main()
        {
            Rational rt1 = new Rational(154,217);

            Rational rt2 = new Rational(42,156);

            Rational rt3 = new Rational();
            rt3 = Operations.Add(rt1, rt2);
            Console.WriteLine("{0}/{1} + {2}/{3} = {4}/{5}",rt1.numerator,rt1.denominator,rt2.numerator,rt2.denominator,rt3.numerator,rt3.denominator);

            Rational rt4 = new Rational();
            rt4 = Operations.Substract(rt1, rt2);
            Console.WriteLine("{0}/{1} - {2}/{3} = {4}/{5}",rt1.numerator,rt1.denominator,rt2.numerator,rt2.denominator,rt4.numerator,rt4.denominator);

            Rational rt5 = new Rational();
            rt5 = Operations.Multiply(rt1, rt2);
            Console.WriteLine("{0}/{1} * {2}/{3} = {4}/{5}",rt1.numerator,rt1.denominator,rt2.numerator,rt2.denominator,rt5.numerator,rt5.denominator);

            Rational rt6 = new Rational();
            rt6 = Operations.Divide(rt1, rt2);
            Console.WriteLine("{0}/{1} / {2}/{3} = {4}/{5}",rt1.numerator,rt1.denominator,rt2.numerator,rt2.denominator,rt6.numerator,rt6.denominator);

            Operations.Display(rt6);
            Operations.DisplayFloatingPoint(rt6,3);


        }
        
    }

    internal class Rational
    {
        internal int numerator;

        internal int denominator;

        internal Rational()
        {}

        internal Rational(int numerator, int denominator)
        {
            if(numerator > denominator)
            {
                for(int i = 2; i<numerator; i++)
                {
                    if(numerator%i == 0 && denominator%i == 0)
                    {
                        numerator = numerator/i;
                        denominator = denominator/i;
                        i = 1;
                    }
                }
            }
            else if(numerator < denominator)
            {
                for(int i = 2; i<denominator; i++)
                {
                    if(numerator%i == 0 && denominator%i == 0)
                    {
                        numerator = numerator/i;
                        denominator = denominator/i;
                        i = 1;
                    }
                }  
            }

            this.numerator = numerator;
            this.denominator = denominator;
        }
    }

    internal class Operations
    {
        public static Rational Add(Rational number1, Rational number2)
        {
            int new_numerator;
            int new_denominator;

            int temp_number1_numerator = number1.numerator;
            int temp_number1_denominator = number1.denominator;

            int temp_number2_numerator = number2.numerator;
            int temp_number2_denominator = number2.denominator;
            

            if(number1.denominator == number2.denominator)
            {
                new_numerator = temp_number1_numerator + temp_number2_numerator;
                new_denominator = temp_number1_denominator;
            }
            else
            {
                temp_number1_numerator = temp_number1_numerator * temp_number2_denominator;
                temp_number2_numerator = temp_number2_numerator * temp_number1_denominator;
                int temp = temp_number1_denominator;
                temp_number1_denominator = temp_number1_denominator * temp_number2_denominator;
                temp_number2_denominator = temp_number2_denominator * temp;

                new_numerator = temp_number1_numerator + temp_number2_numerator;
                new_denominator = temp_number1_denominator;
            }

            Rational result = new Rational(new_numerator, new_denominator);

            return result;
        }

        
        public static Rational Substract(Rational number1, Rational number2)
        {
            int new_numerator;
            int new_denominator;

            int temp_number1_numerator = number1.numerator;
            int temp_number1_denominator = number1.denominator;

            int temp_number2_numerator = number2.numerator;
            int temp_number2_denominator = number2.denominator;
            

            if(number1.denominator == number2.denominator)
            {
                new_numerator = temp_number1_numerator - temp_number2_numerator;
                new_denominator = temp_number1_denominator;
            }
            else
            {
                temp_number1_numerator = temp_number1_numerator * temp_number2_denominator;
                temp_number2_numerator = temp_number2_numerator * temp_number1_denominator;
                int temp = temp_number1_denominator;
                temp_number1_denominator = temp_number1_denominator * temp_number2_denominator;
                temp_number2_denominator = temp_number2_denominator * temp;

                new_numerator = temp_number1_numerator - temp_number2_numerator;
                new_denominator = temp_number1_denominator;
            }

            Rational result = new Rational(new_numerator, new_denominator);

            return result;
        }
        
        
        public static Rational Multiply(Rational number1, Rational number2)
        {
            int new_numerator;
            int new_denominator;

            new_numerator = number1.numerator * number2.numerator;
            new_denominator = number1.denominator * number2.denominator;

            
            Rational result = new Rational(new_numerator, new_denominator);

            return result;
        }

        

        public static Rational Divide(Rational number1, Rational number2)
        {
            int new_numerator;
            int new_denominator;

            new_numerator = number1.numerator * number2.denominator;
            new_denominator = number1.denominator * number2.numerator;

            
            Rational result = new Rational(new_numerator, new_denominator);

            return result;
        }

        
        public static void Display(Rational number)
        {
            Console.WriteLine("{0}/{1}",number.numerator,number.denominator);
        }

        public static void DisplayFloatingPoint(Rational number, int precisionLimit)
        {
            double result = (double)  ((double)number.numerator/(double) number.denominator);
            
            Console.WriteLine("{0}/{1} = {2}",number.numerator,number.denominator,Math.Round(result, precisionLimit));
        }
        
    }
}