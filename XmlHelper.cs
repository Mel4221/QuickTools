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
using System.Collections.Generic;
using System.Xml;

namespace QuickTools
{

       class XmlHelper
      {

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.XmlHelper"/> class.
            /// </summary>
            public XmlHelper()
            {

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.XmlHelper"/> class.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="tagName">Tag name.</param>
            /// <param name="element">Element.</param>
            public XmlHelper(object fileName, object tagName, object element)
            {

            }




            public void Create(string xmlFile,string elementName)
            {
                  if(xmlFile == "" || elementName == "")
                  {
                        throw new InvalidOperationException(); 
                  }

                  using (XmlWriter writer = XmlWriter.Create(xmlFile))
                  {
                     

                        writer.WriteStartElement(elementName);
                        //writer.WriteAttributeString("name", "Melvin");
                        //writer.WriteStartElement("hash");
                        //writer.WriteAttributeString("value", IRandom.RandomText(100));
                        //writer.WriteEndElement(); 
                        writer.WriteEndElement();
                        writer.Flush();
                  }
            }


            /// <summary>
            /// Create the specified xmlFile, elementName, atributeName and atributeValue.
            /// </summary>
            /// <param name="xmlFile">Xml file.</param>
            /// <param name="elementName">Element name.</param>
            /// <param name="atributeName">Atribute name.</param>
            /// <param name="atributeValue">Atribute value.</param>
            public void Create(string xmlFile, string elementName,string atributeName , string atributeValue)
            {
                  if (xmlFile.IndexOf("xml") <= 0)
                  {
                        throw new InvalidOperationException();
                  }
                  if (xmlFile == "" || elementName == "" || atributeName == "" || atributeValue =="")
                  {
                        throw new InvalidOperationException();
                  }

                  using (XmlWriter writer = XmlWriter.Create(xmlFile))
                  {


                        writer.WriteStartElement(elementName);
                        writer.WriteAttributeString(atributeName,atributeValue);
                        //writer.WriteStartElement("hash");
                        //writer.WriteAttributeString("value", IRandom.RandomText(100));
                        //writer.WriteEndElement(); 
                        writer.WriteEndElement();
                        writer.Flush();
                  }
            }



            public void CreateWithListString(string xmlFile, List<string> elementName, List<string>  atributeName, List<string> atributeValue)
            {
                  if (xmlFile.IndexOf("xml") <= 0)
                  {
                        throw new InvalidOperationException();
                  }
                  if (xmlFile == "" || elementName.Count == 0 || atributeName.Count == 0 || atributeValue.Count == 0)
                  {
                        throw new InvalidOperationException();
                  }

                  for (int val = 0; val < elementName.Count; val++)
                  {


                        using (XmlWriter writer = XmlWriter.Create(xmlFile))
                        {


                              writer.WriteStartElement(elementName[val]);
                              writer.WriteAttributeString(atributeName[val], atributeValue[val]);
                              //writer.WriteStartElement("hash");
                              //writer.WriteAttributeString("value", IRandom.RandomText(100));
                              //writer.WriteEndElement(); 
                              writer.WriteEndElement();
                              writer.Flush();
                        }
                  }

            }


            public void RemoveElement(string fileName,string element)
            {
                  string value = null;
                  List<string> elements = new List<string>();
                  List<string> atributes = new List<string>();
                  List<string> values = new List<string>();
                  int indexer = 0; 

                  if (fileName.IndexOf("xml") <= 0)
                  {
                        return;
                  }
                  using (XmlReader reader = XmlReader.Create(fileName))
                  {
                        while (reader.Read())
                        {

                              // elements.Add(x)

                              
                              if ((reader.NodeType == XmlNodeType.Element) && reader.Name != element)
                              {

                                    elements.Add(reader.Name); 
                                    if (reader.HasAttributes)
                                    {
                                         // atributes.Add(reader.GetAttribute().GetType());
                                          indexer++; 
                                          //value = reader.GetAttribute(atribute);
                                    }
                              }




                        }
                  }
            }



            private XmlReaderSettings settings = new XmlReaderSettings(); 


            /// <summary>
            /// Gets the atribute value.
            /// </summary>
            /// <returns>The atribute value.</returns>
            /// <param name="fileName">File name.</param>
            /// <param name="element">Element.</param>
            /// <param name="atribute">Atribute.</param>
            public string GetAtributeValue(string fileName,string element,string atribute)
            {
                  string value = null; 
                  if(fileName.IndexOf("xml") <= 0 )
                  {
                        return null; 
                  }


                  this.settings.ConformanceLevel = ConformanceLevel.Fragment;

                  using (XmlReader reader = XmlReader.Create(fileName,this.settings))
                  {
                       

                        while (reader.Read())
                        {

                              Get.Green(reader.Name + " " + reader.GetAttribute(atribute)); 

                              if ((reader.NodeType == XmlNodeType.Element) && reader.Name == element)
                              {
                                    if (reader.HasAttributes)
                                    {
                                        value = reader.GetAttribute(atribute); 
                                    }
                              }




                        }
                  }


                  return value; 
            }

            /// <summary>
            /// Set this instance.
            /// </summary>
            public void Set()
            {

                  XmlWriterSettings settings = new XmlWriterSettings();
                  settings.Indent = true;
                  settings.IndentChars = ("    ");
                  settings.CloseOutput = true;
                  settings.OmitXmlDeclaration = true;

                  using (XmlWriter writer = XmlWriter.Create("data.xml", settings))
                  {
                     
                        writer.WriteStartElement("DATA");
                        writer.WriteStartAttribute("date",DateTime.Now.ToString());
                        writer.WriteEndAttribute();
                        writer.WriteElementString("user", "Melvin");
                        writer.WriteEndElement();
                        writer.Flush();
                  }

                

            }

           public void GetSetting()
            {
                  XmlReaderSettings settings = new XmlReaderSettings();
                  settings.DtdProcessing = DtdProcessing.Parse;
                  XmlReader reader = XmlReader.Create("books.xml", settings);
                  while (reader.Read())
                  {


                        //Get.Wait(reader.ReadElementString("Item"));
                        //    Get.Green($"{reader.Name} {reader.Value} {XmlNodeType.Text}");


                  }
            }
      }
}
