using System;
using System.IO;
using QuickTools.QCore;
using System.Linq;
using QuickTools.QConsole;
using System.Text;

namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {

        public void SoftLoad()
        {
            if (!File.Exists(this.FileName)) throw new FileNotFoundException(this.FileName);
            using (FileStream stream = new FileStream(this.FileName, FileMode.Open))
            {
                long current, goal, virtual_current, attemps;
                int length, number_length;
                byte[] buffer;
                goal = stream.Length;
                current = 0;
                number_length = 0;
                attemps = 0;
                this.StreamLength = stream.Length;
                QProgressBar bar = new QProgressBar();
                StringBuilder key = new StringBuilder();
                ClownKey clownKey = new ClownKey();
                while (current < goal)
                {
                    stream.Seek(current, SeekOrigin.Begin);
                    BinaryReader reader = new BinaryReader(stream);
                    if (this.FailSafe == goal)
                    {
                        attemps++;
                        Get.Red($"FailSafe Trigered..: Attempting: {attemps}/{this.MaxAttemps}");
                        if (attemps == this.MaxAttemps) break;
                    }
                    if (this.FailSafe != goal)
                    {
                        this.FailSafe = goal;
                    }

                    length = AdjustedLength();
                    buffer = new byte[length];

                    reader.Read(buffer, 0, buffer.Length);
                    for (int key_index = 0; key_index < length; key_index++)
                    {
                        char ch = IConvert.ToString(new byte[] { buffer[key_index] })[0];
                        if (ch == '[')
                        {
                            clownKey.Name = key.ToString();
                            key.Clear();
                        }
                        if (ch == ']')
                        {
                            //Get.Wait(key.ToString());
                            number_length = key.Length;
                            clownKey.length = long.Parse(key.ToString());


                            clownKey.Value = null;
                            key.Clear();
                            /*
                                either the god or the devil,
                                either works , or kills everything    
                                1 2 3 4 = 4

                            */
                            /*
                                if is added too mutch it could reatch the 
                                bouderies of the inner loop which could
                                f things up , so is required to 
                                set the 'b' value to it's end since
                                the limit is not here any more 
                                it is up to the 'current' variable
                                to set the new start point                                       
                             */
                            //get the length of the current value + 4 
                            // which would be 'n']\n in
                            // example1: lastnumber]nextline
                            // example2: [1234]abcd\n
                            int value_length = int.Parse((clownKey.length).ToString());
                            //jump to [length] or [value_length]
                            key_index += value_length > length ? length : value_length;
                            //Get.Red(key_index);
                            key_index += this.NewLineLength();
                            //Get.Red(key_index);
                            /*
                                so i don't understand how this works , it was purely written by me
                                no AI which could at least made it better since i could at least
                                blame it on AI , BUT  it is just what it is 
                                so the idea is that.                                        
                                the loop is moving foward when it ecounters they Key_index
                                that it thinks that it should be biger than the actual buffer
                                that it handles it will try to exit the loop and continues
                                with the next interaction , and at this level 
                                clownkeys.index is being set with the current index of the loop
                                and is being subtracted the length of the length,
                                new line becaus in windows it could be 2 not 1
                                and a -1 to skip the squeare bracket ']' 
                            */
                            clownKey.Index = ((key_index) - (value_length - this.NewLineLength())) - 1;
                            //Get.Red(key_index);


                            virtual_current = clownKey.Name.Length +
                                  clownKey.length +
                                  number_length + 2 + this.NewLineLength();
                            //to 25

                            /*
                                clownKey.Index = current +
                                   key_index +
                                   clownKey.Name.Length +
                                   number_length ;
                            */

                            current += virtual_current;



                            this.TextStatus = ($"CURRENT: {current} GOAL: {goal} {Get.Status(current, goal)} KEY_INDEX: {key_index} VCURRENT: [{virtual_current}]");
                            this.Keys.Add(clownKey);
                            //this.Keys.ForEach(item => Get.Cyan(item));
                            if (this.AllowDebugger) Get.Cyan($"{clownKey} >>> CURRENT: {current} GOAL: {goal} {Get.Status(current, goal)} KEY_INDEX: {key_index} VCURRENT: [{virtual_current}]");

                            // Get.WaitTime(1000);
                            clownKey = new ClownKey();

                            //break;
                        }
                        if (ch != '[' && ch != ']' && ch != '\n')
                        {
                            key.Append(ch);
                        }
                    }
                    //bar.Label = "Processing...";
                    //bar.Display(Get.Status(current,goal)); 

                    //current += length; 
                }


            }
        }


    }
}
