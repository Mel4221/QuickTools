using System;
using System.Text; 
using System.Collections.Generic;
namespace QuickTools
{
      /// <summary>
      /// This is a class that allows a console application to take multiple lines of text respecting the spaces and simbols
      /// </summary>
      public partial class CInput
      {

            private List<string> ContentList = new List<string>();
            /// <summary>
            /// The margin.
            /// </summary>
            public int Margin = 1;

            /// <summary>
            /// The cursor simbol.
            /// </summary>
            public char CursorSimbol = '|';

            /// <summary>
            /// The display input.
            /// </summary>
            public Action<object> DisplayInput;

            /// <summary>
            /// The input display.
            /// </summary>
            public Action<object> InputDisplay;

            /// <summary>
            /// Text this instance.
            /// </summary>
            /// <returns>The text.</returns>
            public string Text()
            {
                  StringBuilder str = new StringBuilder();
                  for (int ch = 0; ch < ContentList.Count; ch++)
                  {
                        str.Append(ContentList[ch]);
                  }
                  return str.ToString();
            }


            /// <summary>
            /// Parse the specified keyInput.
            /// </summary>
            /// <param name="keyInput">Key input.</param>
            public void Parse(QInput.KeyInfo keyInput)
            {
                  string key, modif, cha;

                  key = keyInput.Key.ToString();
                  modif = keyInput.Modifiers.ToString();
                  cha = keyInput.KeyChar.ToString();

                  if (modif == "0")
                  {
                        switch (key)
                        {
                              case "LeftArrow":
                              case "RightArrow":
                              case "UpArrow":
                              case "DownArrow":
                                    //ArrowsHandeler(key);
                                    break;
                              case "Spacebar":
                                    ContentList.Add("\t");
                                    this.X = this.ContentList.Count;
                                    break;
                              case "Backspace":
                                    if (ContentList.Count > 0) ContentList.RemoveAt(ContentList.Count - 1);
                                    break;


                              default:

                                    ContentList.Add(cha);
                                    this.X = this.ContentList.Count;
                                    Console.Title = Text();
                                    break;
                        }
                        return;
                  }
                  else
                  {
                        ContentList.Add(key);
                        this.X = this.ContentList.Count;
                        return;
                  }
            }

            private string Tabs(int tabs)
            {
                  StringBuilder tabsList = new StringBuilder();
                  for (int i = 0; i < tabs; i++)
                  {
                        tabsList.Append("\t");
                  }
                  return tabsList.ToString();
            }

            /// <summary>
            /// The QInput instanse.
            /// </summary>
            public QInput QInputInstanse = new QInput();
           

            /// <summary>
            /// Read this instance.
            /// </summary>
            /// <returns>The read.</returns>
            public string Read()
            {

                  QInputInstanse.ReadingCallBack = (item) => {
                        this.Parse(item);
                        Get.Clear();

                        this.DisplayInput(this.Text());
                        return null;
                  };
                  QInputInstanse.Start();
                  return this.Text();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Input"/> class.
            /// </summary>
            public CInput()
            {
                  //Get.Green(" "+this.Text()+""); 
                  this.DisplayInput = (content) => {
                        Get.Green($"{Tabs(Margin)}{content}{this.CursorSimbol}{Tabs(Margin)}");
                  };
            }
      }
}