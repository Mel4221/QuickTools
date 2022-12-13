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
using System.IO; 
using System.Xml;
using System.Collections.Generic; 
namespace QuickTools
{
      /// <summary>
      /// QSettings helps to create a settings model based on xml 
      /// it actually works pretty well and it is very simple to use 
      /// </summary>
      public class QSettings
      {
            /// <summary>
            /// This contains the list of keys in the settings file 
            /// </summary>
            public List<string> Keys;

            /// <summary>
            /// This Will contain the values from the settings file 
            /// </summary>
            public List<string> Values;

            /// <summary>
            /// Gets or sets the name of the file.
            /// </summary>
            /// <value>The name of the file.</value>
            public string FileName { get; set; }

            /// <summary>
            /// Gets or sets the name of the element.
            /// </summary>
            /// <value>The name of the element.</value>
            public string ElementName { get; set; }

            /// <summary>
            /// Gets or sets the name of the group of tags in the settings 
            /// </summary>
            /// <value>The name of the group.</value>
            public string GroupName { get; set; }
            private XmlDocument Document;


            /// <summary>
            /// Create the specified settings file with the given name .
            /// </summary>
            /// <returns>The create.</returns>
            /// <param name="fileName">File name.</param>
            public bool Create(string fileName)
            {

                  if (File.Exists(fileName))
                  {
                        return false;
                  }
                  XmlWriterSettings settings = new XmlWriterSettings();
                  settings.Indent = true;
                  settings.IndentChars = ("    ");
                  settings.CloseOutput = true;
                  settings.OmitXmlDeclaration = true;

                  using (XmlWriter writer = XmlWriter.Create(fileName, settings))
                  {


                        writer.WriteStartElement(GroupName);

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                  }
                  return true;
            }


            /// <summary>
            /// Load to memory the xml file 
            /// </summary>
            public void Load()
            {
                  Keys = new List<string>();
                  Values = new List<string>();
                  using (XmlReader reader = XmlReader.Create(FileName))
                  {


                        while (reader.Read())
                        {


                              if ((reader.NodeType == XmlNodeType.Element) && reader.Name != "")//(reader.Name.IndexOf("DATE") == 0))
                              {
                                    if (reader.HasAttributes)
                                    {

                                          if (reader.GetAttribute(0).IndexOf("[") == 0 && reader.GetAttribute(0).IndexOf("]") > 0)
                                          {

                                                // Get.Green($"{reader.Name} {reader.GetAttribute(0)}");

                                                Keys.Add(reader.GetAttribute(0).Substring(reader.GetAttribute(0).IndexOf("[") + 1, reader.GetAttribute(0).IndexOf("]") - 1));
                                                Values.Add(reader.GetAttribute(0).Substring(reader.GetAttribute(0).IndexOf("]") + 1));

                                                //  Get.Blue($"Key: {key} Value:  {value}");

                                          }
                                    }

                              }


                        }
                  }



            }
            /// <summary>
            /// Add the specified key setting with the given  value.
            /// </summary>
            /// <param name="key">Key.</param>
            /// <param name="value">Value.</param>
            public void Add(string key, object value)
            {
                  //Get.Wait(this.GetSetting(key));
                  if (this.GetSetting(key) != null)
                  {
                        throw new Exception("This Key already exist");
                  }
                  Document = new XmlDocument();
                  Document.Load(FileName);
                  XmlNode root = Document.FirstChild;
                  XmlElement element = Document.CreateElement(ElementName);
                  element.SetAttribute(key, $"[{key}]{value}");
                  root.AppendChild(element);
                  Document.Save(FileName);
                  this.Load(); 
            }

            /// <summary>
            /// Get the setting value from the key 
            /// </summary>
            /// <returns>The setting.</returns>
            /// <param name="key">Key.</param>
            public string GetSetting(string key)
            {
                  this.Load();
                  string setting = null;

                  for (int value = 0; value < Keys.Count; value++)
                  {
                        if (Keys[value] == key)
                        {
                              return Values[value];
                        }
                  }

                  return setting;
            }

            /// <summary>
            /// Removes the setting from the setting file 
            /// </summary>
            /// <param name="key">Key.</param>
            public void RemoveSetting(string key)
            {

                  List<string> tempKeys = new List<string>();
                  List<string> tempValues = new List<string>();

                  XmlWriterSettings settings = new XmlWriterSettings();
                  settings.Indent = true;
                  settings.IndentChars = ("    ");
                  settings.CloseOutput = true;
                  settings.OmitXmlDeclaration = true;
                  this.Load();

                  using (XmlWriter writer = XmlWriter.Create(FileName, settings))
                  {
                        writer.WriteStartElement("Settings");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                  }

                  for (int value = 0; value < Keys.Count; value++)
                  {
                        if (Keys[value] != key)
                        {
                              tempKeys.Add(Keys[value]);
                              tempValues.Add(Values[value]);
                        }
                  }

                  Values = tempValues;
                  Keys = tempKeys;
                  this.Refresh();
            }

            /// <summary>
            /// Refresh the settings values
            /// </summary>
            public void Refresh()
            {
                  XmlWriterSettings settings = new XmlWriterSettings();
                  settings.Indent = true;
                  settings.IndentChars = ("    ");
                  settings.CloseOutput = true;
                  settings.OmitXmlDeclaration = true;

                  using (XmlWriter writer = XmlWriter.Create(FileName, settings))
                  {


                        writer.WriteStartElement("Settings");

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                  }

                  for (int value = 0; value < Keys.Count; value++)
                  {

                        Document = new XmlDocument();
                        Document.Load(FileName);
                        XmlNode root = Document.FirstChild;
                        XmlElement element = Document.CreateElement(ElementName);

                        element.SetAttribute(Keys[value], $"[{Keys[value]}]{Values[value]}");
                        root.AppendChild(element);
                        Document.Save(FileName);

                  }

                  this.Load();
            }

            /// <summary>
            /// Update the specified setting with the a new Value.
            /// </summary>
            /// <param name="setting">Setting.</param>
            /// <param name="newValue">New value.</param>
            public void Update(string setting, string newValue)
            {
                  this.Load();
                  for (int value = 0; value < Keys.Count; value++)
                  {
                        if (Keys[value] == setting)
                        {

                              Values[value] = newValue;
                              this.Refresh();
                              break;
                        }
                  }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSettings"/> class.
            /// The fallowing settings are applied as default : 
            /// FileName = "Settings.xml";
            /// ElementName = "Setting";
            /// GroupName = "Settings";
            /// </summary>
            public QSettings()
            {
                  FileName = "Settings.xml";
                  ElementName = "Setting";
                  GroupName = "Settings";
                  Create(FileName);


            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSettings"/> class.
            /// The settings will have to be manually ajusted 
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="groupName">Group name.</param>
            /// <param name="elementName">Element name.</param>
            public QSettings(string fileName, string groupName, string elementName)
            {
                  this.Create(fileName);
                  FileName = fileName;
                  ElementName = elementName;
                  GroupName = groupName;

            }



      }
}