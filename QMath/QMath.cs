using QuickTools.QCore;
using QuickTools.QData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QMath
{



    /// <summary>
    /// QMath is a Class that provides auto calculations using plain text to make calculations
    /// </summary>
    public class QMath
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QMath.QMath"/> class.
        /// </summary>
        public QMath() { }
       // private bool HasSetter;
        private bool ActivePromp;
        private MiniDB VariablesDB;
      //  private MiniDB HistoryDB;
        /// <summary>
        /// Checks for Parentesis in the text given
        /// </summary>
        /// <returns><c>true</c>, if parentesis was hased, <c>false</c> otherwise.</returns>
        /// <param name="operation">Operation.</param>
        public bool HasParentesis(string operation) => operation.Contains("(") == true || operation.Contains(")") == true ? true : false;

        /// <summary>
        /// Checks for a Valids the parentesis.
        /// </summary>
        /// <returns><c>true</c>, if parentesis was valided, <c>false</c> otherwise.</returns>
        /// <param name="operation">Operation.</param>
        public bool ValidParentesis(string operation) => operation.Contains("(") && operation.Contains(")")  ? true : false;

        /// <summary>
        /// The value a.
        /// </summary>
        public double ValueA;

        /// <summary>
        /// The value b.
        /// </summary>
        public double ValueB;

        /// <summary>
        /// The current.
        /// </summary>
        public double Current;

        /// <summary>
        /// The total.
        /// </summary>
        public double Total;

        /// <summary>
        /// The create history.
        /// </summary>
        public bool CreateHistory;

        /// <summary>
        /// The history xml.
        /// </summary>
        public string HistoryXml = "Calculation_History.xml";


        /// <summary>
        /// Tos the string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="operation">Operation.</param>
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

        /// <summary>
        /// Ises the operator.
        /// </summary>
        /// <returns><c>true</c>, if operator was ised, <c>false</c> otherwise.</returns>
        /// <param name="ch">Ch.</param>
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

        /// <summary>
        /// Calculate the specified a, b and operation.
        /// </summary>
        /// <returns>The calculate.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="operation">Operation.</param>
        public static double  Calculate(double a,double b,string operation)
        {
            return new QMath().Calculate(a, b, operation[0]); 
        }

        /// <summary>
        /// Calculates the int.
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="operation">Operation.</param>
        public static int CalculateInt(double a, double b, string operation)
        {
            return int.Parse(new QMath().Calculate(a, b, operation[0]).ToString());   
        }

        /// <summary>
        /// Calculate the specified valueA, valueB and operation.
        /// </summary>
        /// <returns>The calculate.</returns>
        /// <param name="valueA">Value a.</param>
        /// <param name="valueB">Value b.</param>
        /// <param name="operation">Operation.</param>
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


        /// <summary>
        /// Parse the specified operation.
        /// </summary>
        /// <param name="operation">Operation.</param>
        public void Parse(string operation)
        {
           
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

        /// <summary>
        /// Sets the variable.
        /// </summary>
        /// <param name="variable">Variable.</param>
        /// <param name="value">Value.</param>
        public void SetVariable(object variable, object value)
        {

        }

        /// <summary>
        /// Gets the variable.
        /// </summary>
        /// <returns>The variable.</returns>
        /// <param name="variable">Variable.</param>
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
           // string a, b, z;
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

       /// <summary>
       /// Starts the promp.
       /// </summary>
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

        /// <summary>
        /// Solves the parentesis.
        /// </summary>
        /// <returns>The parentesis.</returns>
        /// <param name="operation">Operation.</param>
        public string SolveParentesis(string operation)
        {
           // string solved = null;

            throw new NotImplementedException("Yet not Develeloped!!!");

       
        }

    }
   
}
