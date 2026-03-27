using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuickTools.QData
{

  
    /// <summary>
    /// Pretty much this is the class that gives us access to the 
    /// basic functions from the Newtonsoft and it was named NJson
    /// due to the name given to the DLL or library
    /// </summary>
    public class NJson
    {
        /// <summary>
        /// Builder.
        /// </summary>
        public class Builder
        {
            //string jsonString = "{\"name\":\"John\", \"age\":30, \"city\":\"New York\"}";
            private StringBuilder Json { get; set; } 
            /// <summary>
            /// Gets or sets the file path.
            /// </summary>
            /// <value>The file path.</value>
            public string FilePath { get; set; }

            /// <summary>
            /// Add the specified key and value to the json buffer
            /// </summary>
            /// <param name="key">Key.</param>
            /// <param name="value">Value.</param>
            public void Add(string key, string value)
            {
                this.Add(new Key() { Name=key,Value=value});
            }

            /// <summary>
            /// Add the specified key and value to the json buffer
            /// </summary>
            /// <param name="key">Key.</param>
            public void Add(Key key)
            {
                this.Json.Append("\""+key.Name+"\""+":"+"\""+key.Value+"\"");
            }
            /// <summary>
            /// Gets the json.
            /// </summary>
            /// <returns>The json.</returns>
            public string GetJson()
            {
                this.Json.Append("}");
                return this.Json.ToString();
            }
            /// <summary>
            /// Build the specified filePath.
            /// </summary>
            /// <param name="filePath">File path.</param>
            public void Build(string filePath)
            {
                this.FilePath = filePath;
                this.Build();
            }
            /// <summary>
            /// Build this instance.
            /// </summary>
            public void Build()
            {
                JObject jsonObject = JObject.Parse(this.Json.ToString());
                File.WriteAllText(this.FilePath, jsonObject.ToString());

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QData.NJson.Builder"/> class.
            /// </summary>
            public Builder()
            {
                this.Json = new StringBuilder();
                this.Json.Append("{");
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QData.NJson.Builder"/> class.
            /// </summary>
            public Builder(string filePath)
            {
                this.Json = new StringBuilder();
                this.Json.Append("{");
                this.FilePath = filePath;
            }


        }
        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <returns>The keys.</returns>
        /// <param name="property">Property.</param>
        public List<Key> GetKeys(object property)
        {
            JObject jsonObject = JObject.Parse(property.ToString());
            List<Key> keys = new List<Key>();
            foreach (var prop in jsonObject.Properties())
            {
                keys.Add(new Key() { Name = prop.Name, Value = prop.Value.ToString() });
            }
            return keys;
        }



        /*
                
            foreach (JProperty property in jsonObject.Properties())
        {
            string propertyName = property.Name;
            JToken propertyValue = property.Value;

        */
        private readonly string _filePath;
        /// <summary>
        /// The json object.
        /// </summary>
        public JObject JsonObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QData.NJson"/> class.
        /// </summary>
        /// <param name="filePath">File path.</param>
        public NJson(string filePath)
        {
            _filePath = filePath;
            LoadJson();
        }

        /// <summary>
        /// Loads the json.
        /// </summary>
        private void LoadJson()
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                JsonObject = JObject.Parse(jsonString);
            }
            else
            {
                JsonObject = new JObject(); // Create an empty JObject if file does not exist
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="path">Path.</param>
        public JToken GetValue(string path)
        {
            return JsonObject.SelectToken(path);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="value">Value.</param>
        public void SetValue(string path, JToken value)
        {
            var token = JsonObject.SelectToken(path);
            if (token != null)
            {
                token.Replace(value);
            }
            else
            {
                // Add new property to the JSON object
                var parentPath = GetParentPath(path);
                var propertyName = GetPropertyName(path);

                var parentToken = JsonObject.SelectToken(parentPath) as JObject;
                if (parentToken != null)
                {
                    parentToken[propertyName] = value;
                }
                else
                {
                    // If the parent path does not exist, create it
                    var newParent = new JObject { [propertyName] = value };
                    var pathParts = parentPath.Split('.');
                    var currentObject = JsonObject;

                    for (int i = 0; i < pathParts.Length; i++)
                    {
                        if (i == pathParts.Length - 1)
                        {
                            currentObject[pathParts[i]] = newParent;
                        }
                        else
                        {
                            if (currentObject[pathParts[i]] == null)
                            {
                                currentObject[pathParts[i]] = new JObject();
                            }
                            currentObject = (JObject)currentObject[pathParts[i]];
                        }
                    }
                }
            }
            SaveJson();
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="newValue">New value.</param>
        public void UpdateValue(string path, JToken newValue)
        {
            var token = JsonObject.SelectToken(path);
            if (token != null)
            {
                token.Replace(newValue);
                SaveJson();
            }
            else
            {
                throw new Exception("Path not found in JSON.");
            }
        }

        /// <summary>
        /// Saves the json.
        /// </summary>
        private void SaveJson()
        {
            string jsonString = JsonObject.ToString(Formatting.Indented);
            File.WriteAllText(_filePath, jsonString);
        }

        private string GetParentPath(string path)
        {
            var lastDotIndex = path.LastIndexOf('.');
            return lastDotIndex == -1 ? "" : path.Substring(0, lastDotIndex);
        }

        private string GetPropertyName(string path)
        {
            var lastDotIndex = path.LastIndexOf('.');
            return lastDotIndex == -1 ? path : path.Substring(lastDotIndex + 1);
        }
    }

    /*
    class Program
    {
        static void Main()
        {
            string filePath = "data.json";
            var manager = new JsonFileManager(filePath);

            // Set a value
            manager.SetValue("user.name", "mario");

            // Update a value
            manager.UpdateValue("user.name", "luigi");

            // Get a value
            var value = manager.GetValue("user.name");
            Console.WriteLine($"User name: {value}");
        }
    }

    */
}