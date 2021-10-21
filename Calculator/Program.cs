using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {

        enum Pages {start, calculator, calculations}



        static void Main(string[] args)
        {
            
            List<string> usersCalculations = new List<string>();
            string userName = "";
            bool isCalculating = false;
            bool isApplicationRunning = true;


            while (isApplicationRunning)
            {
              

                if (userName == "")
                {
                    SetUserName();
                }

                StartMenu();

      
               
            }

            void SetUserName()
            {

                Console.Write("Your name: ");
                userName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Hi there {userName}!");

            }



            bool CreateCalculation()
            {

                Console.Clear();

                double[] calNrs = new double[2];
                char calOperator;
                string calculation;

                for (int i = 0; i < calNrs.Length; i++)
                {
                    if(GetNrInput(i + 1, out double _calNr))
                    {
                        calNrs[i] = _calNr;
                    }
                }

                if (GetOperatorInput(out calOperator))
                {
                    calculation = Calculate(calNrs[0], calNrs[1], calOperator);
                    usersCalculations.Add(calculation);
                }




                Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine(usersCalculations[usersCalculations.Count -1]);
                
                //no calculation is running
                return false;
            }

           
            bool GetNrInput(int _index, out double calNr)
            {              

                while (true)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Console.Write($"{GetNrEnd(_index)} number:   ");
                    string userInput = Console.ReadLine();
                    Console.Clear();

                    if (double.TryParse(userInput, out calNr))
                    {
                        //input is now valid and returned as double
                       
                        return true;                                                                                      
                    }
                    else
                    {     
                        //input not valid
                        ShowErrorMessage("Number", _index);                          
                    }
                }
            }

            bool GetOperatorInput(out char _calOp)
            {
                while (true)
                {
                    string validOperators = "+-*/";
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    Console.Write("Choose operator ( + - * / ):  ");
                    string userInput = Console.ReadLine();
                    Console.Clear();


                    if (char.TryParse(userInput, out _calOp) && validOperators.Contains(_calOp))
                    {
                        //calculation is now valid
                        return true;
                    }
                    else
                    {

                        ShowErrorMessage("Operator", 0);
                    }
                }
            }
            

            string Calculate(double _input1, double _input2, char _operatorType)
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


            void ShowErrorMessage(string _inputType, int _index)
            {

                string message = $"{GetNrEnd(_index)} { _inputType} is not valid!!!";
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine($"                    {message}");

            }

            void StartMenu()
            {

                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("Press 'Space' to make a new calculation");
                Console.WriteLine("Press 'Enter' to show all previous calculations");
                Console.WriteLine("Press 'Esc' to quit");
                ConsoleKeyInfo userKeyInput = Console.ReadKey();


                switch (userKeyInput.Key)
                {
                    //Again
                    case ConsoleKey.Spacebar:

                        CreateCalculation();
                        break;

                    //Display users calculations
                    case ConsoleKey.Enter:

                        Console.Clear();
                        Console.WriteLine($"{userName}'s calculations: ");
                        Console.WriteLine("---------------------------------------------------------------------------------");

                        foreach (string cal in usersCalculations)
                        {
                            Console.WriteLine(cal);
                        }

                        break;

                    //Cancel
                    case ConsoleKey.Escape:

                        isCalculating = false;
                        isApplicationRunning = false;
                        Console.Clear();
                        break;


                }

            }

            string GetNrEnd(int _nr)
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
}
