//
// ${Melquiceded Balbi Villanueva}
//
// Author:
//       ${Melquiceded} <${melquiceded.balbi@gmail.com}>
//
// Copyright (c) ${2089} MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using QuickTools.QIO;
using QuickTools.QCore;
using QuickTools.QConsole;
using System.Threading;
using System.Diagnostics;
using System.Text;

namespace QScript.Interpreter
{
      public partial class QInterpreter
      {


            public void Parse()
            {
                  StringBuilder code = new StringBuilder(); 
                  foreach(string word in this.Arguments)
                  {
                        code.Append($"{word}"); 
                  }
                  BuildScript(code.ToString()); 
            }

            public string BuildScript(string code)
            {
                  this.Body = $"{this.Top} \n" +
                              $"\t\t\t\t\t\t {code} \n" +
                              $"{this.Button}" +
                                    $"/*This Code was auto injected :{DateTime.Now}: */";
                  return this.Body; 
            }

            private void Build()
            {
                  new Thread(() =>
                  {
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.FileName = "bash";
                        info.Arguments = $"{Get.Path}Build";
                        Process process = Process.Start(info);
                        //process.WaitForExit();
                  }).Start();
            }

            private void Run(string file)
            {
                  ProcessStartInfo info = new ProcessStartInfo();
                  info.FileName = "mono";
                  info.Arguments = $"{Get.Path}{file}";
                  Process process = Process.Start(info);
                  //process.WaitForExit();
            }


            public void Start()
            {

                  Get.Loop(() => {
                        Options options;
                        string[] list = { "Create QScript", "Run QScript", "Edit QScript", "Export QScript", "Export exe", "Exit" };
                        options = new Options(list);

                        switch (options.Pick())
                        {
                              case 0:
                                    this.Create();
                                    break;
                              case 1:
                                    this.Run();
                                    break;
                              case 2:
                                    this.Edit();
                                    break;
                              case 3:
                                    this.ExportScript();
                                    break;
                              case 4:
                                    this.ExportExe();
                                    break;
                              case 5:
                                    Environment.Exit(0);
                                    break;
                        }

                  });
            }


      

            private void ExportExe()
            {
                  throw new NotImplementedException();
            }

            private void ExportScript()
            {
                  throw new NotImplementedException();
            }

            private void Edit()
            {
                  throw new NotImplementedException();
            }

            private void Run()
            {
                  throw new NotImplementedException();
            }
            private void Create()
            {
                  string code, script, fileName;
                  CInput input = new CInput();
                  input.QInputInstanse.AllowDislayLabel = true;

                  fileName = Get.Input("Please type the name of the file NOT MANDATORY").Text;


                  if(fileName == "" || fileName == null)
                  {
                        fileName = $"QScript-{IRandom.Pin()}.cs"; 
                  }
                  if(!fileName.Contains(".cs"))
                  {
                        fileName += ".cs"; 
                  }

                 // Get.Yellow("Please Type Your code");

                  code = input.Read();
                  if(code == "")
                  {
                        Get.Red("This Does not look like valid C# code please try again");
                        this.Create(); 
                  }
                  if (!code.Contains(";"))
                  {
                        Get.Red("It looks like you are missing ';'  at the end of the statemets and they are required");
                        this.Create();
                  }

                  //Get.Wait(code); 
                  script = BuildScript(code);
                  Writer.Write(fileName, script);
                  Get.Green("Script Saved Sucessfully");
                  Get.Pink("Would you like to Write a new one?"); 
                 if(new Options(false).Pick() == 1){
                        this.Create(); 
                  }


            }
      }
}
