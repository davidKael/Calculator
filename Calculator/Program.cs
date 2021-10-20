using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {





        static void Main(string[] args)
        {
            string userName = "";
            List<string> usersCalculations = new List<string>();

            bool isInNavigation = false;
            bool isApplicationRunning = true;



            while (isApplicationRunning)
            {


                if (GetUserCalculation(out double calNr1, out double calNr2, out char operatorType))
                {
                    string calculation = GetCalculation(calNr1, calNr2, operatorType);
                    usersCalculations.Add(calculation);
                    Console.WriteLine(calculation);
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }



                isInNavigation = true;
                

                while (isInNavigation)
                {

                    Console.WriteLine("'Enter' to make a new calculation");
                    Console.WriteLine("'Space' to show all previous calculations");
                    Console.WriteLine("'Esc' to quit");
                    Navigation(Console.ReadKey());
                }

            }

            void SetUserName()
            {

                Console.Write("Your name: ");
                userName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Hi there {userName}!");

            }



            bool GetUserCalculation(out double calNr1, out double calNr2, out char operatorType)
            {

                Console.Clear();

                if(userName == "")
                {

                    SetUserName();

                }

                while (true)
                {

                    Console.Write("Enter first number:  ");
                    string userInput = Console.ReadLine();



                    if (double.TryParse(userInput, out calNr1))
                    {

                        //first number is now valid
                        break;

                    }


                    else
                    {

                        ShowErrorMessage("First number");
                    }

                }




                while (true)
                {

                    Console.Write("Enter second number:  ");
                    string userInput = Console.ReadLine();

                    if (double.TryParse(userInput, out calNr2))
                    {
                        //second number is now valid
                        break;

                    }


                    else
                    {

                        ShowErrorMessage("Second number");
                    }

                }


                
                while (true)
                {

                    Console.Write("Enter which operator ( + - * / ):  ");
                    string userInput = Console.ReadLine();

                    if (char.TryParse(userInput, out operatorType) && IsCharValidAsOperator(operatorType))
                    {
                        //operator is now valid
                        break;
                    }


                    else
                    {

                        ShowErrorMessage("Operator"); 
                    }
                }


                Console.Clear();

                return true;
            }





            string GetCalculation(double _input1, double _input2, char _operatorType)
            {
                

                switch (_operatorType)
                {
                    case '+':
                        return $"{_input1} {_operatorType} {_input2} = {_input1 + _input2}";
                       
                    case '-':
                        return $"{_input1} {_operatorType} {_input2} = {_input1 - _input2}";
                       
                    case '*' or 'x':
                        _operatorType = '*';
                        return $"{_input1} {_operatorType} {_input2} = {_input1 * _input2}";

                    case '/':   
                        return _input2 == 0 ? $"{_input1} {_operatorType} {_input2} = 0" : $"{_input1} {_operatorType} {_input2} = {_input1 / _input2}";
                        

                    default:
                        return  "?";
                      

                }

              
            }

            bool IsCharValidAsOperator(char _operatorType)
            {

                return _operatorType == '+' || _operatorType == '-' || _operatorType == '*' || _operatorType == 'x' || _operatorType == '/';
            }


            void ShowErrorMessage(string _reason)
            {
                Console.Clear();
                Console.WriteLine(_reason + " is not valid");
            }

            void Navigation(ConsoleKeyInfo _key)
            {


                switch (_key.Key)
                {

                    //Again
                    case ConsoleKey.Enter:
                        isInNavigation = false;
                        break;
                    
                    //Cancel
                    case ConsoleKey.Escape:
                        isInNavigation = false;
                        isApplicationRunning = false;
                        Console.Clear();
                        break;

                    //Display users calculations
                    case ConsoleKey.Spacebar:
                        Console.Clear();

                        Console.WriteLine($"{userName}'s calculations: ");
                        Console.WriteLine("---------------------------------------------------------------------------------");

                        foreach (string cal in usersCalculations)
                        {
                            Console.WriteLine(cal);
                        }
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        break;


                }

            }
        }

    }
}
