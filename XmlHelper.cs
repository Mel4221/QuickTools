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
using System.Xml;

namespace QuickTools
{
      /// <summary>
      /// This is a class that helps to make it easier to create
      /// and add content to the xml files 
      /// </summary>
      public class XmlHelper
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


            /// <summary>
            /// Set this instance.
            /// </summary>
            public void Set()
            {
                  /*
                  XmlWriterSettings settings = new XmlWriterSettings();
                  settings.Indent = true;
                  settings.IndentChars = ("    ");
                  settings.CloseOutput = true;
                  settings.OmitXmlDeclaration = true;
                  using (XmlWriter writer = XmlWriter.Create("books.xml", settings))
                  {
                        writer.WriteStartElement("book");
                        writer.WriteElementString("title", Get.TextInput());
                        writer.WriteElementString("author", Get.TextInput());
                        writer.WriteElementString("publisher", Get.TextInput());
                        writer.WriteElementString("price", Get.TextInput());
                        writer.WriteEndElement();
                        writer.Flush();
                  }

                  */
                  XmlReaderSettings settings = new XmlReaderSettings();
                  settings.DtdProcessing = DtdProcessing.Parse;
                  XmlReader reader = XmlReader.Create("books.xml", settings);
                  while (reader.Read())
                  {


                        Get.Wait(reader.ReadElementString("Item"));
                        //    Get.Green($"{reader.Name} {reader.Value} {XmlNodeType.Text}");

                       
                  }

            }
      }
}
