using QuickTools.QCore;
using QuickTools.QData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QMath
{
    
    public class QMath
    {
        public QMath() { }
        private bool HasSetter;
        private bool ActivePromp;
        private MiniDB VariablesDB;
        private MiniDB HistoryDB;
        public bool HasParentesis(string operation) => operation.Contains("(") == true || operation.Contains(")") == true ? true : false;
        public bool ValidParentesis(string operation) => operation.Contains("(") && true || operation.Contains(")") == true ? true : false;
        public double ValueA;
        public double ValueB;
        public double Current;
        public double Total;
        public bool CreateHistory;
        public string HistoryXml = "Calculation_History.xml";


        public string ToString(char operation)
        {
            switch (operation)
            {
                case '+':
                    return "Adittion";
                case '-':
                    return "Subtraction";
                case '*':
                    return "Multiplication";
                case '/':
                    return "Division";
                case '^':
                    return "Exponential";
                case '!':
                    return "Factorial";
                case '%':
                    return "Porcent";
                case '=':
                    return "Assinging Variable";
                default:
                    return "Some Crazy Magic Thing";
            }
        }
        public bool IsOperator(char ch)
        {
            switch (ch)
            {
                case '%':
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                case '!':
                case '(':
                case '=':
                case ')':
                    return true;
                default:
                    return false;
            }
        }
        public static double  Calculate(double a,double b,string operation)
        {
            return new QMath().Calculate(a, b, operation[0]); 
        }
        public static int CalculateInt(double a, double b, string operation)
        {
            return int.Parse(new QMath().Calculate(a, b, operation[0]).ToString());   
        }
        public double Calculate(double valueA, double valueB, char operation)
        {
            double total = 0;
            double temp;
            switch (operation)
            {
                case '+':
                    total = valueA + valueB;
                    break;
                case '%':
                    // 20 % 1024  = 
                    // 20 * 100 / 1024 = X%
                    total = (valueA * valueB) / 100;
                    break;
                case '-':
                    total = valueA - valueB;
                    break;
                case '*':
                    total =  valueA * valueB;
                    break;
                case '/':
                    total = valueA / valueB;
                    break;
                case '^':
                    temp = valueA; // 2 ^ 4  = 2 * 2 = 4 * 2 = 8 * 2 = 16 
                    for (double exp = 0; exp < valueB - 1; exp++)
                    {
                        temp = temp * valueA;
                        Get.Green(temp);
                    }
                    total = temp;
                    break;
                case '!':
                    if (valueB == 0)
                    {
                        temp = 1;
                        for (double f = valueA; f > 1; f--)
                        {
                            temp = temp * f;
                            //for testing  Get.Green(temp); 
                        }
                        total = temp;
                    }
                    break;
            }


            return total;
        }

        public void Parse(string operation)
        {
            string current;
            bool isNext;
            isNext = false;
            current = "";
            for (int x = 0; x < operation.Length; x++)
            {
                switch (this.IsOperator(operation[x]))
                {
                    case true:

                        break;
                    case false:

                        break;
                    default:
                        Get.Wrong($"Impossible Operation At: {operation[x]} From: {operation}");
                        return;

                }

            }
        }

        private bool FunctionCheck(string input)
        {
            switch (input)
            {
                case "exit":
                case "clear":
                    return true;
                default:
                    return false;
            }
        }


        private void RunFunction(string input)
        {
            switch (input)
            {
                case "exit":
                    this.ActivePromp = false;
                    break;
                case "clear-history":
                    break;
                case "clear":
                    Get.Clear();
                    break;
            }
        }
        public void SetVariable(object variable, object value)
        {

        }
        public string GetVariable(object variable)
        {
            string value;
            value = null;
            this.VariablesDB = new MiniDB("VariableDB.xml");
            this.VariablesDB.Create();
            this.VariablesDB.Load();
            value = this.VariablesDB.GetKey(variable);
            if (value == null) throw new Exception($"Variable '{variable}' Not Found");
            return value;
        }
        private double CheckValue(string value)
        {
            double val = 0;
            switch (Get.IsNumber(value))
            {
                case true:
                    val = double.Parse(value);
                    break;
                case false:
                    val = double.Parse(this.GetVariable(value));
                    break;
            }

            return val;
        }
        private void ProcessAsSetter(string input)
        {
            //x = 22;
            //x = 2 + 2
            //x = b
            //x = b + z
            //x = 2 + b
            //x = a + b + z + N
            string[] opt = IConvert.TextToArray(input);
            string a, b, z;
            switch (opt.Length)
            {
                case 3:
                    break;
                case 5:
                    break;
                default:

                    break;
            }
        }
        public void StartPromp()
        {
            string input;
            string[] f;
            double a, b;
            char operation;
            this.ActivePromp = true;

            while (this.ActivePromp)
            {

                input = Get.Input("Calculate:").Text;

                if (input.Contains("="))
                {
                    //x = 2;
                    this.ProcessAsSetter(input);
                    return;
                }
                if (FunctionCheck(input))
                {
                    RunFunction(input);
                }
                if (!this.ActivePromp)
                {
                    return;
                }
                else
                {
                    try
                    {
                        f = IConvert.TextToArray(input);
                        a = this.CheckValue(f[0]);
                        b = this.CheckValue(f[2]);
                        operation = f[1][0];


                        Get.Blue($"Input: A: {a} B: {b} F: {this.ToString(operation)}");
                        Get.Yellow($"{a} {operation} {b}");
                        Get.Pink($"Total: {this.Calculate(a, b, operation)}");
                    }
                    catch (Exception e)
                    {
                        Get.Red($"Sys: {e.Message}");
                        Get.Yellow($"There was an error with your calculation:  {input}");
                    }
                }

            }


        }
        public string SolveParentesis(string operation)
        {
            string solved = null;



            return solved;
        }

    }
   
}
