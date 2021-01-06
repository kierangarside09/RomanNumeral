using System;
using System.Linq;

namespace RomanNumeral
{
    class Program
    {
        static int Val(char a)
        {
            if(a == 'I')
            {
                return 1;
            }
            if(a == 'V')
            {
                return 5;
            }
            if (a == 'X')
            {
                return 10;
            }
            if (a == 'L')
            {
                return 50;
            }
            if (a == 'C')
            {
                return 100;
            }
            if (a == 'D')
            {
                return 500;
            }
            if (a == 'M')
            {
                return 1000;
            }
            return 0;
        }
        static void Main(string[] args)
        { 
            
            bool exit = false;
            while(exit == false)
            {
                int selection = 0;
                Console.WriteLine("If you wish to convert from Roman numerals to base 10 enter 1. \r\n" +
                "Else if you would like to convert from base 10 to Roman Numerals press 2. \r\n ");
                selection = Convert.ToInt16(Console.ReadLine());
                if (selection == 1) 
                { 
                    Console.WriteLine();
                    RomanToInt();
                }
                else if(selection == 2)
                {
                    Console.WriteLine();
                    IntToRoman();
                }
                else
                {
                    Console.WriteLine("Incorrect input please enter a selection\r\n");
                }
            }
            
        }

        static void RomanToInt()
        {
            string Roman;
            int Total = 0,Length;
            bool exit = false,check = true;
            while (exit == false)
            {
                Total = 0;
                check = true;
                Console.WriteLine("Enter Roman Numerals you wish to convert. or enter E to leave");
                Roman = Console.ReadLine();
                Length = Roman.Length;
                int[] RomanInts = new int[Length];
                int b = -1;
                if (Roman != "E")
                {
                    foreach (char a in Roman)
                    {
                        b++;
                        if (a != 'M' && a != 'D' && a != 'C' && a != 'L' && a != 'X' && a != 'V' && a != 'I')
                        {
                            Console.WriteLine("Not a valid Entry \r\nEnter Again.");
                            check = false;
                            break;
                        }
                        RomanInts[b] = Val(a);
                    }
                    if (check == true)
                    {
                        for (int i = 0; i <= Length - 1; i++)
                        {
                            if (i + 1 < Length)
                            {
                                if (RomanInts[i] >= RomanInts[i + 1])
                                {
                                    Total = Total + RomanInts[i];
                                }
                                else
                                {
                                    Total = Total + RomanInts[i + 1] - RomanInts[i];
                                    i++;
                                }
                            }
                            else
                            {
                                Total = Total + RomanInts[i];
                            }
                        }
                        Console.WriteLine("The total of the roman numeral is: " + Total.ToString());
                    }

                }
                else
                    exit = true;
            }
      
        }
        static void IntToRoman()
        {
            bool exit = false;
            while (exit == false)
            {
                int num = 0;
                string Roman = "";
                int Amt, Rem, catcher = 0;
                Console.WriteLine("Enter Roman Numerals you wish to convert. Or enter 0 to leave");
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid Entry try again.");
                    catcher = 1;

                }
                if (num != 0 && catcher == 0)
                {
                    Console.WriteLine(num);
                    if (num >= 1000)
                    {
                        Amt = num / 1000;
                        num = num % 1000;
                        Roman = Roman + (String.Concat(Enumerable.Repeat("M", Amt)));
                    }
                    if (num >= 500)
                    {
                        if (num < 900)
                        {
                            Amt = num / 500;
                            num = num % 500;
                            Roman = Roman + (String.Concat(Enumerable.Repeat("D", Amt)));
                        }
                        else
                        {
                            Roman = Roman + "CM";
                            num = num % 500;
                        }
                    }
                    if (num >= 100)
                    {
                        if (num < 400)
                        {
                            Amt = num / 100;
                            num = num % 100;
                            Roman = Roman + (String.Concat(Enumerable.Repeat("C", Amt)));
                        }
                        else
                        {
                            Roman = Roman + "CD";
                            num = num % 100;
                        }
                    }
                    if (num >= 50)
                    {
                        if (num < 90)
                        {
                            Amt = num / 50;
                            num = num % 50;
                            Roman = Roman + (String.Concat(Enumerable.Repeat("L", Amt)));
                        }
                        else
                        {
                            Roman = Roman + "XC";
                            num = num % 50;
                        }
                    }
                    if (num >= 10)
                    {
                        if (num < 40)
                        {
                            Amt = num / 10;
                            num = num % 10;
                            Roman = Roman + (String.Concat(Enumerable.Repeat("X", Amt)));
                        }
                        else
                        {
                            Roman = Roman + "XL";
                            num = num % 10;
                        }
                    }
                    if (num >= 5)
                    {
                        if (num < 9)
                        {
                            Amt = num / 5;
                            num = num % 5;
                            Roman = Roman + (String.Concat(Enumerable.Repeat("V", Amt)));
                        }
                        else
                        {
                            Roman = Roman + "IX";
                            num = 0;
                        }
                    }
                    Console.WriteLine("Bllallaaa  " + num);
                    if (num >= 1)
                    {
                        if (num < 4)
                        {
                            Amt = num / 1;
                            Roman = Roman + (String.Concat(Enumerable.Repeat("I", Amt)));
                        }
                        else
                        {
                            Roman = Roman + "IV";
                        }
                    }
                    Console.WriteLine("Your Roman numeral is: " + Roman + "\r\n");
                }
                else if(catcher == 1)
                {
                    exit = false;
                }           
                else
                    exit = true;
            }
        }
    }
}
