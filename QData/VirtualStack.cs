using QuickTools.QCore;
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
        /// This inplementation was added to allwo the virtual stack
        /// to hold binary data insede of it aswell 
        /// </summary>
        public byte[] Buffer { get; set; } = new byte[0];
        /// <summary>
        /// Contains the property that make the object to be treated as a contant
        /// </summary>
        public bool IsConstant { get; set; } = false;

        /// <summary>
        /// Defines if the variable is a function
        /// </summary>
        public bool IsFunction { get; set; } = false;


        /// <summary>
        /// Identify that the current variable is empty
        /// </summary>
        public bool IsEmpty { get; set; } = true; 

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
        /// Gets the current varialble count and subtract 1 and returns the value of the Variables list
        /// </summary>
        /// <returns></returns>
        public int GetIndex() => this.Variables.Count-1;
   
        /// <summary>
        /// Returns the size of the current stack
        /// </summary>
        /// <returns></returns>
        public string VirtualStackSize()
        {
            long number = 0; 
            for(int v =0; v < this.Variables.Count; v++)
            {
                if(this.Variables[v].Buffer.Length != 0)
                {
                    number+=this.Variables[v].Buffer.Length;
				}
                if(this.Variables[v].Value !=null && this.Variables[v].Buffer.Length == 0)
                {
                    number+= Get.Bytes(this.Variables[v].Value).LongLength;
                }
            }
            return Get.FileSize(number);
        }

		/// <summary>
		/// finds if the given variable exist
		/// </summary>
		/// <param name="variable"></param>
		/// <returns></returns>
		public bool Exist(Variable variable)
        {
			foreach (Variable v in this.Variables)
			{
				if (v.Name == variable.Name)
				{
                    return true;
				}
			}
            return false;
		}

		/// <summary>
		/// Set the variable with the given value
		/// </summary>
		/// <param name="variable"></param>
		/// <exception cref="Exception"></exception>
		public void SetVariable(Variable variable)
        {
            if (this.Exist(variable)) throw new Exception($"Variable Already Set");
            this.Variables.Add(variable);
        }
        
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
            return new Variable() { };
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
                if (this.Variables[item].IsConstant == true)
                {
                    throw new Exception($"{variable} is a constant and the value can no be updated.");
                }
				if (this.Variables[item].Name == variable)
				{
					this.Variables[item].Value = newValue;
					break;
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
            if (!GetVariable(variable).IsEmpty || variable == "")
            {
                //this.Dump();
                throw new Exception("Variable is already set");
            }
            this.Variables.Add(new Variable()
            {
                Name = variable,
                Value = value,
                IsEmpty = false
            }) ;

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
                IsConstant = true,
                IsEmpty = false
            }) ;

        }


        /// <summary>
        /// Free the variable from  the virtual stack
        /// </summary>
        /// <param name="variable"></param>
        public void Free(string variable)
        {
            for(int v  = 0; v < this.Variables.Count; v++)
            {
                if (this.Variables[v].Name == variable)
                {
                    this.Variables.RemoveAt(v);
                    return; 
                }
            }
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