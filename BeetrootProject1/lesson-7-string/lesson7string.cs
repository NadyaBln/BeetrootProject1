using System;
using System.Linq;
using System.Text;

namespace lesson_7_string
{
    class lesson7string
    {
        static void Main(string[] args)
        {

            //classwork 16 feb 2022

            string name = "Serhii";
            string nameTwo = "Alex";

            //template
            string placeholder = "Hello {0} and {1}";

            Console.WriteLine("Hello " + name);                                             //Hello Serhii
            Console.WriteLine($"Hello {name} and {nameTwo}");                               //Hello Serhii and Alex

            //use when we have some template
            Console.WriteLine(string.Format("Hello {0}", name));                           //Hello Serhii
            Console.WriteLine(string.Format("Hello {0} and {1}", name, nameTwo));          //Hello Serhii and Alex
            Console.WriteLine(string.Format(placeholder, name, nameTwo));                   //Hello Serhii and Alex


            var oneString = $"Hello, {name} and {nameTwo}";
            char symbol = oneString[0];

            Console.WriteLine(symbol);                                                      //H
            Console.WriteLine(char.IsLetter(symbol));                                       //true
            Console.WriteLine(char.IsDigit(symbol));                                        //false
            Console.WriteLine(char.IsUpper(symbol));                                        //true


            Console.WriteLine(oneString.Contains('q'));                                     //false
            Console.WriteLine(oneString.Contains("hii"));                                   //true

            Console.WriteLine(oneString.EndsWith("lex"));                                   //true
            Console.WriteLine(oneString.StartsWith("Al"));                                  //true

            var helloPlaceholder = "!Hello ";
            var index = helloPlaceholder.IndexOf(' ');                                      //5

            Console.WriteLine(helloPlaceholder.Insert(index + 1, name));                    //true
            Console.WriteLine($"Hello {name}".Replace(name, nameTwo));                     //true


            Console.WriteLine(helloPlaceholder.PadLeft(40));                                //add spaces before 

            Console.WriteLine(helloPlaceholder.PadLeft(40).Trim());                         //delete all spaces

            Console.WriteLine(helloPlaceholder.ToLower());
            Console.WriteLine(helloPlaceholder.ToUpper());

            Console.WriteLine(helloPlaceholder.CompareTo("sddsd"));
            Console.WriteLine("Compare");
            Console.WriteLine(string.Compare("sddsd", "ddd"));                              //1
            Console.WriteLine(string.Compare("sddsd", "sddsd"));                            //0
            Console.WriteLine("sddsd" == "sddsd");                                          //true
            Console.WriteLine("sddsd" != "sddsd");                                          //false

            Console.WriteLine("Hello " + name);

            // show digits from 0 to 999 with spaces. var 1
            var emptyString = string.Empty;
            const int N = 1000;
            int i = 0;
            for (i = 0; i < N; i++)
            {
                emptyString += $" {i}";
            }


            // show digits from 0 to 999 with spaces. var 2
            var stringBuilder = new StringBuilder();

            for (i = 0; i < N; i++)
            {
                stringBuilder.AppendFormat(" {0}", i);
            }

            Console.WriteLine(emptyString);
            Console.WriteLine(stringBuilder.ToString());


            //change register of text which player enters
            Console.WriteLine("Enter string");
            string input = Console.ReadLine();
            string output = string.Empty;

            foreach (var item in input)
            {
                output += char.IsLower(item)
                ? char.ToUpper(item)
                : char.ToLower(item);
            }
            Console.WriteLine(output);


            //------------------------------------------------------------------------------
            //Homework 17 feb 2022

            Console.WriteLine("Enter string A and B");
            string inputStringA = Console.ReadLine();
            string inputStringB = Console.ReadLine();

            Console.WriteLine($"Are strings A and B equal: {Compare(inputStringA, inputStringB)}");
            Console.WriteLine($"Amount of symbols in string A: {Analyze(inputStringA)}");
            Console.WriteLine($"Alphabetical sorting of string A: {Sort(inputStringA)}");
            Console.WriteLine($"Duplicate chars: {Duplicate(inputStringA)}");

        }


        static bool Compare(string A, string B)
        {
            bool result = true;
            for (int i = 0; i < B.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (B[i] != A[j] | B.Length != A.Length)
                    {
                        return false;
                    } 
                }
            }
            return result;
        }


        static int Analyze(string A)
        {
            string trimmed = A.Replace(" ", "");
            return trimmed.Length;
        }


        static string Sort(string A)
        {
            string trimmed = A.Replace(" ", "");
            var B = trimmed.ToArray();

            for (int i = 0; i < B.Length; i++)
            {

                for (int j = 0; j < B.Length - 1; j++)
                {

                    if (B[j] > B[j + 1])
                    {

                        char temp = B[j];
                        B[j] = B[j + 1];
                        B[j + 1] = temp;
                    }
                }
            }
            return new string(B);
        }

        static string Duplicate(string A)
        {
            string output = string.Empty;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (i != j && A[i] == A[j] && !output.Contains(A[i]))
                    {
                        output += A[i];
                    }
                }
            }
            return output;
        }

    }

}


