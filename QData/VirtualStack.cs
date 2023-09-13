<<<<<<< HEAD
﻿using QuickTools.QCore;
using QuickTools.QIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QData
{


    /// <summary>
    /// this is a class that represent a variable wich contains it's name and value
    /// into an string 
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// Auto Generate the Ide using <see cref="IRandom.RandomInt"/>
        /// </summary>
        public int Id { get; set; } = IRandom.RandomInt(10000, 99999);
        /// <summary>
        /// Name of the Variable
        /// </summary>
        public string Name { get; set; } = null; 
        /// <summary>
        /// Contains the value of the variable
        /// </summary>
        public string Value { get; set; } = null;
        /// <summary>
        /// Contains the property that make the object to be treated as a contant
        /// </summary>
        public bool IsConstant { get; set; } = false;

        /// <summary>
        /// Defines if the variable is a function
        /// </summary>
        public bool IsFunction { get; set; } = false; 

        /// <summary>
        /// Returns the string value of the Object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ID: {this.Id} Name: {this.Name} Value: {this.Value}";
        }
    }

    /// <summary>
    /// This class provide a virtual way to store values of variables assing in a 
    /// format that gives access to the memory and could be modify in the run
    /// </summary>
    public class VirtualStack
    {
        /// <summary>
        /// By default the name is "Stack.dump"
        /// </summary>
        public string DumpFileName { get; set; } = "Stack.dump";
        private List<Variable> Variables { get; set; } = new List<Variable>();


        /// <summary>
        /// Gets the value from the value from the variable in the stack
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public Variable GetVariable(string variable)
        {
            foreach (Variable v in this.Variables)
            {
                if (v.Name == variable)
                {
                    return v;
                }
            }
            return null;
        }

        /// <summary>
        /// updates the value of the variable in the stack
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="newValue"></param>
        public void UpdateVariable(string variable, string newValue)
        {
            for (int item = 0; item<this.Variables.Count; item++)
            {
                if (this.Variables[item].Name == variable)
                {
                    this.Variables[item].Value = newValue;
                    break;
                }
                if (this.Variables[item].IsConstant == true)
                {
                    throw new Exception($"{variable} is a constant and the value can no be updated.");
                }
            }

        }

        /// <summary>
        /// Set the variable with the given value
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void SetVariable(string variable, string value)
        {
            if (GetVariable(variable) != null || variable == "")
            {
                //this.Dump();
                throw new Exception("Variable is already set");
            }
            this.Variables.Add(new Variable()
            {
                Name = variable,
                Value = value
            });

        }

        /// <summary>
        /// Set the variable with the given value
        /// </summary>
        /// <param name="variable"></param>
        public void SetVariable(Variable variable)
        {
            this.SetVariable(variable.Name, variable.Value); 
        }

        /// <summary>
        /// Set a constant value that can not be change allong the program life
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void SetConstant(string variable, string value)
        {
            if (GetVariable(variable) != null || variable != "")
            {
                //this.Dump();
                throw new Exception("Variable is already set");
            }
            this.Variables.Add(new Variable()
            {
                Name = variable,
                Value = value,
                IsConstant = true
            }) ;

        }

        /// <summary>
        /// Clear the stack 
        /// </summary>
        public void Flush()
        {
            Variables.Clear();
        }

        /// <summary>
        /// Creates a dump file with the information that is listed in the memory
        /// of the stack
        /// </summary>
        public void Dump()
        {
            StringBuilder variables = new StringBuilder();

            foreach (Variable v in Variables)
            {
                variables.Append($"{v.ToString()}\n");
            }
            variables.Append($"#This Dump file was generated on: {DateTime.Now}#");
            Writer.Write(this.DumpFileName, variables.ToString());
        }

    }
}
=======
﻿using QuickTools.QCore;
using QuickTools.QIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QData
{


    /// <summary>
    /// this is a class that represent a variable wich contains it's name and value
    /// into an string 
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// Auto Generate the Ide using <see cref="IRandom.RandomInt"/>
        /// </summary>
        public int Id { get; set; } = IRandom.RandomInt(10000, 99999);
        /// <summary>
        /// Name of the Variable
        /// </summary>
        public string Name { get; set; } = null; 
        /// <summary>
        /// Contains the value of the variable
        /// </summary>
        public string Value { get; set; } = null;
        /// <summary>
        /// Contains the property that make the object to be treated as a contant
        /// </summary>
        public bool IsConstant { get; set; } = false;

        /// <summary>
        /// Defines if the variable is a function
        /// </summary>
        public bool IsFunction { get; set; } = false; 

        /// <summary>
        /// Returns the string value of the Object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ID: {this.Id} Name: {this.Name} Value: {this.Value}";
        }
    }

    /// <summary>
    /// This class provide a virtual way to store values of variables assing in a 
    /// format that gives access to the memory and could be modify in the run
    /// </summary>
    public class VirtualStack
    {
        /// <summary>
        /// By default the name is "Stack.dump"
        /// </summary>
        public string DumpFileName { get; set; } = "Stack.dump";
        private List<Variable> Variables { get; set; } = new List<Variable>();


        /// <summary>
        /// Gets the value from the value from the variable in the stack
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public Variable GetVariable(string variable)
        {
            foreach (Variable v in this.Variables)
            {
                if (v.Name == variable)
                {
                    return v;
                }
            }
            return null;
        }

        /// <summary>
        /// updates the value of the variable in the stack
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="newValue"></param>
        public void UpdateVariable(string variable, string newValue)
        {
            for (int item = 0; item<this.Variables.Count; item++)
            {
                if (this.Variables[item].Name == variable)
                {
                    this.Variables[item].Value = newValue;
                    break;
                }
                if (this.Variables[item].IsConstant == true)
                {
                    throw new Exception($"{variable} is a constant and the value can no be updated.");
                }
            }

        }

        /// <summary>
        /// Set the variable with the given value
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void SetVariable(string variable, string value)
        {
            if (GetVariable(variable) != null || variable == "")
            {
                //this.Dump();
                throw new Exception("Variable is already set");
            }
            this.Variables.Add(new Variable()
            {
                Name = variable,
                Value = value
            });

        }

        /// <summary>
        /// Set the variable with the given value
        /// </summary>
        /// <param name="variable"></param>
        public void SetVariable(Variable variable)
        {
            this.SetVariable(variable.Name, variable.Value); 
        }

        /// <summary>
        /// Set a constant value that can not be change allong the program life
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void SetConstant(string variable, string value)
        {
            if (GetVariable(variable) != null || variable != "")
            {
                //this.Dump();
                throw new Exception("Variable is already set");
            }
            this.Variables.Add(new Variable()
            {
                Name = variable,
                Value = value,
                IsConstant = true
            }) ;

        }

        /// <summary>
        /// Clear the stack 
        /// </summary>
        public void Flush()
        {
            Variables.Clear();
        }

        /// <summary>
        /// Creates a dump file with the information that is listed in the memory
        /// of the stack
        /// </summary>
        public void Dump()
        {
            StringBuilder variables = new StringBuilder();

            foreach (Variable v in Variables)
            {
                variables.Append($"{v.ToString()}\n");
            }
            variables.Append($"#This Dump file was generated on: {DateTime.Now}#");
            Writer.Write(this.DumpFileName, variables.ToString());
        }

    }
}
>>>>>>> 97cf9074bcb98ed82b0e0545ffe3241572864f37
