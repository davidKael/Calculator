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
            Calculator();
        }

    
        static void Calculator()
        {
            bool isApplicationRunning = true;

            if (userName == "")
            {
                SetUserName();
            }

            while (isApplicationRunning)
            {
                Console.WriteLine(line);
                Console.WriteLine("Press 'Space' to make a new calculation");
                Console.WriteLine("Press 'Enter' to show all previous calculations");
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

                    //Cancel
                    case ConsoleKey.Escape:
                        isApplicationRunning = false;
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }
        }


        static void SetUserName()
        {
            Console.WriteLine(line);
            Console.Write("Your name: ");
            userName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Hi there {userName}!");
        }


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


        static char GetOperatorInput()
        {
            string validOperators = "+-*/";

            while (true)
            {               
                Console.WriteLine(line);
                Console.Write("Choose operator ( + - * / ):  ");
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
            

        static string Calculate(double _input1, double _input2, char _operatorType)
        {     
            switch (_operatorType)
            {
                case '+':
                    return $"{_input1} {_operatorType} {_input2} = {_input1 + _input2}";
                        
                case '-':
                    return $"{_input1} {_operatorType} {_input2} = {_input1 - _input2}";                       
                       
                case '*':                     
                    return $"{_input1} {_operatorType} {_input2} = {_input1 * _input2}";                       

                case '/':
                    return _input2 == 0 ? $"{_input1} {_operatorType} {_input2} = 0" : $"{_input1} {_operatorType} {_input2} = {_input1 / _input2}";                        
                        
                default:
                    return "?";                                          
            }
        }


        static void ShowErrorMessage(string _inputType, int _index)
        {
            string message = $"{NrToPlacement(_index)} { _inputType} is not valid!!!";

            Console.Clear();
            Console.WriteLine(line);
            Console.WriteLine($"                    {message}");
        }


        static void DisplayUsersCalculations()
        {
            Console.WriteLine($"{userName}'s calculations: ");
            Console.WriteLine(line);

            foreach (string cal in usersCalculations)
            {
                Console.WriteLine(cal);
            }
        }


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
