using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTools.QCore;

namespace QuickTools.QConsole.Emulation
{
    public partial class QVim
    {
        

        private void Tabs()
        {
            this.CharsList.Add(' ');
            CursorPosition.X++;
            this.Column++;

            this.CharsList.Add(' ');
            CursorPosition.X++;
            this.Column++;

            this.CharsList.Add(' ');
            CursorPosition.X++;
            this.Column++;


        }

        private void Enter()
        {
            this.CharsList.Add('\n');
            CursorPosition.X = 0;
            CursorPosition.Y++;
            this.Row++; 
            this.ColumnsList.Add(this.Column); 
            this.Column = 0;
            Get.Write("\n");
        }
        private void BackSpace()
        {
            //try
            //{
            if(this.CharsList.Count != 0)
            {
                this.CharsList.RemoveAt(this.CharsList.Count - 1);
            }

            if (CursorPosition.X == 0 && CursorPosition.Y != 0)
            {
                // Get.Wait(CursorPosition.X);
                if(this.ColumnsList.Count != 0)
                {
                    // selecting the last one from the list of columns
                    //which means that will have the lastest length in the previus line 
                    CursorPosition.X = this.ColumnsList[this.ColumnsList.Count - 1];

                    
                    CursorPosition.Y--;
                    this.Row--;
 
                    Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
                    Get.Write($" ");
                    //after everythinng is needed to remove the lastest line just in case to do not get confuse
                    this.ColumnsList.Remove(this.ColumnsList.Count - 1);
                    return;

                }
             
            }
            else
            {
                //CursorPosition.X--;
                CursorPosition.X--;
                this.Column--; 
                Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
                Get.Write($" ");

            }



            //}
            //catch
            //{
            //    Console.Beep();
            //}
        }
        /// <summary>
        /// Exeute the given commmand 
        /// rmemeber adding the Execute case command here only will not automatically run it 
        /// you first have to add it to the KeyInfo
        /// for it to be added first as a condition then you can add it here  
        /// </summary>
        /// <param name="key"></param>
        public void ExeuteCommand(KeyInfo key)
        {
            string input = key.Key; 
            switch (input)
            {
                case "Enter":
                    this.Enter();
                    break;
                case "Escape":
                    this.EscapeKeyPressed = true; 
                    break;
                case "Tab":
                    this.Tabs();
                    break;
                case "Spacebar":
                    this.CharsList.Add(' ');
                    CursorPosition.X++;
                    this.Column++; 
                    break;
                case "Backspace":
                    this.BackSpace();
                    break;
                case "Delete":
                    break;
                case "Insert":
                    break;
                default:
                     break;
            }
        }



        /// <summary>
        /// Runs the action depending on the direction 
        /// </summary>
        /// <param name="key"></param>
        private void RunArrowsFunctions(KeyInfo key)
        {
            string input = key.ToString();
            switch (input)
            {
                case "LeftArrow":

                    break;
                case "RightArrow":

                    break;

                case "UpArrow":

                    break;
                case "DownArrow":

                    break;
            }
        }
    }
}
