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
// THE SOFTWARE.using System;
using System;
using System.IO;
using QuickTools.QCore;
using QuickTools.QConsole; 
namespace QuickTools.QIO
{
      /// <summary>
      /// Binary.
      /// </summary>
      public partial class Binary
      {


            /// <summary>
            /// Check if the file is biig
            /// </summary>
            /// <returns><c>true</c>, if big file was ised, <c>false</c> otherwise.</returns>
            /// <param name="file">File.</param>
            public static bool IsBigFile(string file)
            {
                  if (!File.Exists(file)) throw new FileNotFoundException(); 

                  try
                  {
                        File.ReadAllBytes(file);
                        return false; 
                  }
                  catch
                  {
                        return true;; 
                  }
            }


        /// <summary>
        /// Try to destroy the file but is not very effective
        /// for security reason please use another option "/>
        /// </summary>
        /// <param name="file"></param>
            public static void Destroy(string file)
        {
            long fileSize = 0;
            int size = 0;
            using(var _file = new FileStream(file, FileMode.Open)){
               if(_file.Length  == 0)
                {
                    fileSize = 1024; 
                }if(_file.Length > 0)
                {
                    fileSize = _file.Length;
                }
              
            }
              if(fileSize > int.MaxValue)
            {
                size = int.MaxValue; 
            }
              if(fileSize < int.MaxValue)
            {
                size = int.Parse(fileSize.ToString()); 
            }
            Binary.Writer(file, new byte[size]);
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            File.Delete(file); 
        }

            /// <summary>
            /// Copies the buffer and returns it 
            /// </summary>
            /// <returns>The buffer.</returns>
            /// <param name="buffer">Buffer.</param>
            /// <param name="from">From.</param>
            /// <param name="until">Until.</param>
            public static byte[] CopyBuffer(byte[] buffer , int from , int until)
                  {
                  if(from > until && until != from)
                        {
                        throw new Exception("The Start can not be greater nor equal than the Final point");
                        }
                  byte[] array = new byte[from + until];
                  for(int item = from ; item < until ; item++)
                        {
                        array[item] = buffer[item];
                        }
                  return array;
                  }


           // private static QProgressBar bar = new QProgressBar(); 
            /// <summary>
            /// Creates a file full of zeros of the given GB size 
            /// for what reason , i mean is here so just use it on what you consider the best 
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="GbSize">Gb size.</param>
            public static void CreateZeroFile(string fileName , int GbSize)
            {
            //throw new Exception("This Function has been disabled due to realabilty reasons");
            try
            {
                GC.Collect();
                using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {


                    int size = GbSize * 1024 * 1024 * 1024;
                    if (size > int.MaxValue)
                    {
                        size = int.MaxValue - 1;
                    }
                    byte[] buffer = new byte[size];
                    using (BinaryWriter binary = new BinaryWriter(stream))
                    {

                        Get.Wait($"Creatting {fileName} Size: [{Get.FileSize(size)}] Please Wait...", () =>
                        {
                            binary.Write(buffer, 0, buffer.Length);

                        });
                        Get.Ok();
                    }
                }
            }catch(Exception ex)
            {
                Get.Red($"Something Failed while creatting the Zero File more info: \n\n{ex}");
            }
        }
        /// <summary>
        /// Creates the zero file.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="GbSize">Gb size.</param>
        /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
        public static void CreateZeroFile(string fileName, int GbSize,bool allowDebugger)
        {
            Binary.CreateZeroFile(fileName, GbSize); 
        }

        /// <summary>
        /// Copies the binary file.
        /// </summary>
        /// <returns><c>true</c>, if binary file was copyed, <c>false</c> otherwise.</returns>
        /// <param name="srcfilename">Srcfilename.</param>
        /// <param name="destfilename">Destfilename.</param>
        public static bool CopyBinaryFile(string srcfilename, string destfilename)
            {
                  if (!File.Exists(srcfilename))
                  {
                        Console.WriteLine("Could not find the Source file");
                        return false;
                  }
                  Stream input = File.Open(srcfilename, FileMode.Open);
                  FileStream output = File.Open(destfilename, FileMode.Create);
                  BinaryReader binaryReader = new BinaryReader(input);
                  BinaryWriter binaryWriter = new BinaryWriter(output);
                  Binary binary = new Binary(); 
                  while (true)
                  {
                        byte[] buffer = new byte[10240];
                        int num = binaryReader.Read(buffer, 0, 10240);
                        if (num <= 0)
                        {
                              break;
                        }
                        binary.Buffer = buffer;
                        binaryWriter.Write(buffer, 0, num);
                        if (num < 10240)
                        {
                              break;
                        }
                  }
                  binaryReader.Close();
                  binaryWriter.Close();
                  return true;
            }


        /// <summary>
        /// Copies the binary file while runs a provided action Method to handle the current status of the transfer
        /// and the action method takes the current value and the goal value in it 
        /// </summary>
        /// <returns><c>true</c>, if binary file was copyed, <c>false</c> otherwise.</returns>
        /// <param name="srcfilename">Srcfilename.</param>
        /// <param name="destfilename">Destfilename.</param>
        /// <param name="Status">Status.</param>
        public static bool CopyBinaryFile(string srcfilename, string destfilename, Action<int,int> Status)
            {
                  if (!File.Exists(srcfilename))
                  {
                        Console.WriteLine("Could not find the Source file");
                        return false;
                  }
                  new FileInfo(srcfilename);
                  Stream input = File.Open(srcfilename, FileMode.Open);
                  FileStream output = File.Open(destfilename, FileMode.Create);
                  BinaryReader binaryReader = new BinaryReader(input);
                  BinaryWriter binaryWriter = new BinaryWriter(output);
                    int current, goal;
            current = 0; 
            goal = int.Parse(input.Length.ToString())-1; ; 
              
                  while (true)
                  {
                        byte[] buffer = new byte[10240];
                        int num = binaryReader.Read(buffer, 0, 10240);

                        if (num <= 0)
                        {
                              break;
                        }
                        binaryWriter.Write(buffer, 0, num);
                        if (num < 10240)
                        {
                              break;
                        }
                        Status(current,goal);
              
                    current++; 
                  }
                  binaryReader.Close();
                  binaryWriter.Close();
                  return true;
            }


        /// <summary>
        /// Copies the binary file.
        /// </summary>
        /// <returns><c>true</c>, if binary file was copyed, <c>false</c> otherwise.</returns>
        /// <param name="srcfilename">Srcfilename.</param>
        /// <param name="destfilename">Destfilename.</param>
        /// <param name="allowDebbuger">If set to <c>true</c> allow debbuger.</param>
        public static bool CopyBinaryFile(string srcfilename, string destfilename, bool allowDebbuger)
        {
            if (!File.Exists(srcfilename))
            {
                Console.WriteLine("Could not find the Source file");
                return false;
            }
            new FileInfo(srcfilename);
            Stream input = File.Open(srcfilename, FileMode.Open);
            FileStream output = File.Open(destfilename, FileMode.Create);
            BinaryReader binaryReader = new BinaryReader(input);
            BinaryWriter binaryWriter = new BinaryWriter(output);
            int current, goal;
            current = 0;
            goal = int.Parse(input.Length.ToString()) - 1; ;

            while (true)
            {
                
                byte[] buffer = new byte[10240];
                int num = binaryReader.Read(buffer, 0, 10240);

                if (num <= 0)
                {
                    break;
                }
                binaryWriter.Write(buffer, 0, num);
                if (num < 10240)
                {
                    break;
                }
                if (allowDebbuger) 
                {
                    Get.Yellow($"Copying... {srcfilename} to {destfilename} [{Get.Status(current,goal)}]"); 
                }


                current++;
            }
            binaryReader.Close();
            binaryWriter.Close();
            return true;
        }
        /// <summary>
        /// Copies the text file.
        /// </summary>
        /// <returns><c>true</c>, if text file was copyed, <c>false</c> otherwise.</returns>
        /// <param name="srcfilename">Srcfilename.</param>
        /// <param name="destfilename">Destfilename.</param>
        public static bool CopyTextFile(string srcfilename, string destfilename)
            {
                  if (!File.Exists(srcfilename))
                  {
                        Console.WriteLine("Could not find the Source file");
                        return false;
                  }
                  StreamReader streamReader = new StreamReader(srcfilename);
                  StreamWriter streamWriter = new StreamWriter(destfilename);
                  while (true)
                  {
                        char[] buffer = new char[1024];
                        int num = streamReader.Read(buffer, 0, 1024);
                        if (num <= 0)
                        {
                              break;
                        }
                        streamWriter.Write(buffer, 0, num);
                        if (num < 1024)
                        {
                              break;
                        }
                  }
                  streamReader.Close();
                  streamWriter.Close();
                  return true;
            }



           
            /// <summary>
            /// Moves the file.
            /// </summary>
            /// <returns><c>true</c>, if file was moved, <c>false</c> otherwise.</returns>
            /// <param name="pointA">Point a.</param>
            /// <param name="pointB">Point b.</param>
            public static bool MoveFile(string pointA, string pointB)
            {
                  bool wasSucessfull = true;
                  if (!File.Exists(pointA))
                  {
                        throw new FileNotFoundException("The file in point A was not founded: " + pointA);

                  }

                   byte[] a = Binary.Reader(pointA); 

                  Binary.Writer(pointB, a);

                  byte[] b = Binary.Reader(pointB);

                if(!CheckFileIntegrity(a, b))
                  {
                        throw new IOException("The File was moved but it is Curropted");
                  }
                    if(Get.HashCode(pointA) == Get.HashCode(pointB))
            {
                File.Delete(pointA);
                return wasSucessfull;
            }
            else
            {

                wasSucessfull = false; 
            }

            return wasSucessfull;
            }


        /// <summary>
        /// Reader the specified file.
        /// </summary>
        /// <returns>The reader.</returns>
        /// <param name="file">File.</param>
        public static byte[] Reader(string file)
        {
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fs.Length];
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        reader.Read(bytes, 0, bytes.Length);

                        if(bytes.Length == 0)
                        {
                            return new byte[0];
                        }
                        else {
                            return bytes;
                        }

                    }
                }
            }
            catch
            {
                return new byte[0]; 
            }
        }


            /// <summary>
            /// Checks the file integrity.
            /// </summary>x`
            /// <returns><c>true</c>, if file integrity was checked, <c>false</c> otherwise.</returns>
            /// <param name="a">The alpha component.</param>
            /// <param name="b">The blue component.</param>
            public static bool CheckFileIntegrity(byte[] a, byte[] b)
            {
                  bool isSafe = true;
                  for (int i = 0; i < a.Length; i++)
                  {

                        if (a[i] != b[i])
                        {
                              return false;
                        }
                  }
                  return isSafe;
            }



            /// <summary>
            /// Checks the file integrity.
            /// </summary>
            /// <returns><c>true</c>, if file integrity was checked, <c>false</c> otherwise.</returns>
            /// <param name="fileA">File a.</param>
            /// <param name="fileB">File b.</param>
            public static bool CheckFileIntegrity(string fileA, string fileB)
            {
                  byte[] a = Binary.Reader(fileA);
                  byte[] b = Binary.Reader(fileB);
                  bool isSafe = true;

                  for (int i = 0; i < a.Length; i++)
                  {
                        if (a[i] != b[i])
                        {
                              return false;
                        }
                  }

                  return isSafe;
            }

            /// <summary>
            /// Writer the specified file and bytes.
            /// </summary>
            /// <param name="file">File.</param>
            /// <param name="bytes">Bytes.</param>
            public static void Writer(string file,byte[] bytes)
            {
        
                  using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                  {
                      using (BinaryWriter writer = new BinaryWriter(fs))
                      {

                           writer.Write(bytes, 0, bytes.Length);

                      }
                  }
            }

            /// <summary>
            /// Append the specified fileName, bytes and seek.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="bytes">Bytes.</param>
            /// <param name="seek">Seek.</param>
            public static void Append(string fileName, byte[] bytes,long seek) => Append(fileName,bytes,0,bytes.Length,seek,SeekOrigin.Begin);
            /// <summary>
            /// Append the specified fileName, bytes, index, count, seek and origin.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="bytes">Bytes.</param>
            /// <param name="index">Index.</param>
            /// <param name="count">Count.</param>
            /// <param name="seek">Seek.</param>
            /// <param name="origin">Origin.</param>
            public static void Append(string fileName,byte[] bytes ,int index,int count,long seek,SeekOrigin origin)
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    stream.Seek(seek,origin);
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(bytes,index, count);
                    }
                }
            }

        /// <summary>
        /// Write the specified file with the given  bytes,  from the given position  until the given position 
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="bytes">Bytes.</param>
        /// <param name="from">From.</param>
        /// <param name="until">Until.</param>
        public static void Write(string fileName ,byte[] bytes , int from , int until)
                 {
                  BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.Create,FileAccess.Write));
                  writer.Write(bytes , from , until);
                  }



            }

}
