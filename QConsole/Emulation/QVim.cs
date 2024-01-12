using System;
using System.Text;
using System.IO;
using QuickTools.QIO;
using QuickTools.QCore;
using QuickTools.QColors;
using QuickTools.QData;
using QuickTools.QNet;
using QuickTools.QSecurity;
using QuickTools.QSecurity.FalseIO;
using QuickTools.QConsole;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Threading;
namespace QuickTools.QConsole.Emulation
{

    /// <summary>
    /// QVim is a atempt to create a simpler version of vim on c#
    /// </summary>
    public partial class QVim
    {






        /// <summary>
        /// Capture this instance.
        /// </summary>
        /// <returns>The capture.</returns>
        public KeyInfo Capture()
        {
            Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
            Get.Title($"X: {CursorPosition.X} Y: {CursorPosition.Y} CharCount: {this.CharsList.Count} Columns: {this.Column} Rows: {this.Row}");
            var obj = Console.ReadKey();
            return new KeyInfo()
            {
                Key = obj.Key.ToString(),
                KeyChar = obj.KeyChar,
                Modifiers = obj.Modifiers.ToString()
            };
        }

     

        /// <summary>
        /// Evaluates the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public void EvaluateKey(KeyInfo key)
        {
            //Get.Wait(key.ToString());
            ////Get.Green(key.ToString());
            ////Get.Yellow(this.HasControl(key));
            if (this.HasArrows(key))
            {
                // process the arrow direction depending on the direction 
                this.RunArrowsFunctions(key);

                return;
            }
            if (this.HasCommand(key))
            {
                //has command process the command 
                this.ExeuteCommand(key);
                return;
            }
            if (this.HasControl(key))
            {
                // the key has a controll being precess so it want's a function

                return;
            }
            if (this.HasShiftAndControl(key))
            {
                // if it has precess the shift and control is also a function 
                //this.CharsList.Add(key.KeyChar);
                return;
            }
            if (this.HasSimbol(key))
            {
                //add the given simbol no matter if it was pressed with a mofifier or not 
                this.CharsList.Add(key.KeyChar);
                CursorPosition.X++;
                this.Column++;
                return;
            }
            if (!this.HasSimbol(key) && this.HasShift(key))
            {
                // add the letter on capital  if has a modifier like shift 
                this.CharsList.Add(key.KeyChar);
                CursorPosition.X++;
                this.Column++;
                return;
            }     
            else
            {
                //add the lower case letter
                this.CharsList.Add(key.KeyChar);
                CursorPosition.X++;
                this.Column++;
            }


        }
        /// <summary>
        /// Start this instance.
        /// </summary>
        public void Start()
        {


            while (this.EscapeKeyPressed != true)
            {
                KeyInfo key = this.Capture();
                this.EvaluateKey(key);
            }

            //while (true)
            //{
            //    TextReader input = Console.In;
            //    TextWriter tOut = Console.Out;



            //    input.Read();
            //tOut.WriteLine("Hola Mundo!");
            ////tOut.Write("What is your name: ");
            //String name = tIn.ReadLine();

            //tOut.WriteLine("Buenos Dias, {0}!", name);
            //}



        }
    }
}
