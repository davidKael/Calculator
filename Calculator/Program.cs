using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static List<string> usersCalculations = new List<string>();
        static string userName = "";
        static string line = "------------------------------------------------------------------------------------";

        static void Main(string[] args)
        {
            AppNavigator();
        }
        

        /// <summary>
        /// Method that lets the user navigate through the app
        /// </summary>
        static void AppNavigator() 
        { 

            bool isApplicationRunning = true;

            if (userName.Length < 1)
            {
                SetUserName();
            }

            while (isApplicationRunning)
            {
                Console.WriteLine(line);
                Console.WriteLine("Press 'Space' to make a new calculation");
                Console.WriteLine("Press 'Enter' to show all previous calculations");
                Console.WriteLine("Press 'N' to change name");
                Console.WriteLine("Press 'Esc' to quit");
                ConsoleKeyInfo userKeyInput = Console.ReadKey();

                Console.Clear();
                switch (userKeyInput.Key)
                {
                    //Start calculate
                    case ConsoleKey.Spacebar:
                        CreateNewCalculation();
                        break;

                    //Display users calculations
                    case ConsoleKey.Enter:
                        DisplayUsersCalculations();
                        break;

                    //To change user's name
                    case ConsoleKey.N:
                        SetUserName();
                        break;

                    //Cancel
                    case ConsoleKey.Escape:
                        Console.WriteLine($"Ok Good Bye {userName}..");
                        isApplicationRunning = false;
                        break;

                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Method that makes the user save a name
        /// </summary>
        static void SetUserName()
        {
            while (true)
            {
                Console.WriteLine(line);
                Console.Write("Enter your name: ");
                userName = Console.ReadLine();
                Console.Clear();

                if(userName.Length > 0)
                {
                    break;
                }
                else
                {
                    ShowErrorMessage("Entered name", 0);
                }
            }

            Console.WriteLine($"Hi there {userName}!");
        }


        /// <summary>
        /// Method that controls the flow of how the user creates a new calculation
        /// </summary>
        static void CreateNewCalculation()
        {
            double[] calNrs = new double[2];

            for (int i = 0; i < calNrs.Length; i++)
            {
                calNrs[i] = GetNrInput(i + 1);
            }

            string calculation = Calculate(calNrs[0], calNrs[1], GetOperatorInput());
            usersCalculations.Add(calculation);

            Console.Clear();
            Console.WriteLine(line);
            Console.WriteLine(usersCalculations[usersCalculations.Count - 1]);
        }


        /// <summary>
        /// Method that asks for an input from the user and make sure it is a valid
        /// </summary>
        /// <param name="_index"></param>
        /// <returns>Verified number as a double</returns>
        static double GetNrInput(int _index)
        {
            while (true)
            {
                Console.WriteLine(line);
                Console.Write($"{NrToPlacement(_index)} number:   ");
                string userInput = Console.ReadLine();

                Console.Clear();
                if (double.TryParse(userInput, out double calNr))
                {
                    //input is valid            
                    return calNr;
                }
                else
                {
                    //input not valid
                    ShowErrorMessage("Number", _index);
                }
            }
        }


        /// <summary>
        /// Method that asks for an input from the user and make sure it is valid as an operator
        /// </summary>
        /// <returns>Verified operator as char</returns>
        static char GetOperatorInput()
        {
            string validOperators = "+-*/";

            while (true)
            {
                Console.WriteLine(line);
                Console.Write("Enter an operator | + | - | * | / |:  ");
                string userInput = Console.ReadLine();

                Console.Clear();
                if (char.TryParse(userInput, out char calOp) && validOperators.Contains(calOp))
                {
                    //input is valid
                    return calOp;
                }
                else
                {
                    //input not valid
                    ShowErrorMessage("Operator", 0);
                }
            }
        }


        /// <summary>
        /// Method that takes 3 arguments and turns them into a calulation
        /// </summary>
        /// <param name="_input1"></param>
        /// <param name="_input2"></param>
        /// <param name="_operatorType"></param>
        /// <returns>Calculation as a string</returns>
        static string Calculate(double _input1, double _input2, char _operatorType)
        {
            switch (_operatorType)
            {
                case '+':
                    return string.Format("{0} {1} {2} = {3}", _input1, _operatorType, _input2, _input1 + _input2);

                case '-':
                    return string.Format("{0} {1} {2} = {3}", _input1, _operatorType, _input2, _input1 - _input2);

                case '*':
                    return string.Format("{0} {1} {2} = {3}", _input1, _operatorType, _input2, _input1 * _input2);

                case '/':
                    return string.Format("{0} {1} {2} = {3}", _input1, _operatorType, _input2, _input2 == 0 ? 0 : _input1 / _input2);

                default:
                    return "?";
            }
        }


        /// <summary>
        /// Method used for showing the user that their input is invalid
        /// </summary>
        /// <param name="_inputType"></param>
        /// <param name="_index"></param>
        static void ShowErrorMessage(string _inputType, int _index)
        {
            string message = $"{NrToPlacement(_index)} { _inputType} is not valid!!!";

            Console.Clear();
            Console.WriteLine(line);
            Console.WriteLine($"                    {message}");
        }


        /// <summary>
        /// Method for displaying the user's previous calculations
        /// </summary>
        static void DisplayUsersCalculations()
        {
            Console.WriteLine($"{userName}'s calculations: ");
            Console.WriteLine(line);

            if(usersCalculations.Count > 0)
            {
                foreach (string cal in usersCalculations)
                {
                    Console.WriteLine(cal);
                }

            }
            else
            {
                Console.WriteLine("No calculations have been made...");
            }
 
        }


        /// <summary>
        /// Method that takes an int and returns it as a string to use in an order, for example 1 => "1st"
        /// </summary>
        /// <param name="_nr"></param>
        /// <returns>String</returns>
        static string NrToPlacement(int _nr)
        {
            switch (_nr)
            {
                case 0:
                    return "";

                case 1:
                    return $"{_nr}st";

                case 2:
                    return $"{_nr}nd";

                case 3:
                    return $"{_nr}rd";

                default:
                    return $"{_nr}th";
            }
        }
    }
}
