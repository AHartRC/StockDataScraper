#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockDataScraper.Extensions;

#endregion

namespace StockDataScraper.Helpers
{
    public static class JsonHelper
    {
        static JsonHelper()
        {
            GlobalSchemas = new Dictionary<string, Dictionary<string, object>>();
        }

        public static Dictionary<string, Dictionary<string, object>> GlobalSchemas { get; set; }

        public static object ProcessJsonSchema(string response)
        {
            if (response.IsNullOrWhiteSpace())
            {
                return null;
            }

            response = response.Replace("\r", "").Replace("\n", "").Trim();

            if (response.StartsWith("//"))
            {
                response = response.Trim('/', '[');
            }

            // Convert hex values (eg. "\x2F") to their string character equivalent (eg. "/")
            for (var i = 0; i < 128; i++)
            {
                var hexString = i.ToString("X").PadLeft(2, '0');
                var searchString = @"\x" + hexString;
                var charValue = Convert.ToInt32(hexString, 16);
                var character = char.ConvertFromUtf32(charValue);

                response = response.Replace(searchString, character == "\""
                    ? "'"
                    : character);
            }

            var token = JToken.Parse(response);

            var schema = ProcessJToken(token);

            AddToGlobalSchema(schema, "StockData");

            return schema;
        }

        private static Dictionary<string, object> ProcessJObject(JObject jObject)
        {
            return ProcessJObject(jObject.ToString());
        }

        private static Dictionary<string, object> ProcessJObject(string input)
        {
            //IDictionary<string, JToken> properties = JSchema.Parse(input).ExtensionData;
            IDictionary<string, JToken> properties = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(input);
            var fields = new Dictionary<string, object>();

            foreach (var property in properties)
            {
                var schema = ProcessJToken(property.Value);
                fields.Add(property.Key, schema);
            }

            return fields;
        }

        private static object ProcessJToken(JToken token)
        {
            if (token == null)
                return null;

            switch (token.Type)
            {
                case JTokenType.Object:
                    var jObject = (JObject) token;
                    var objectResult = ProcessJObject(jObject);
                    return objectResult;
                case JTokenType.Array:
                    var array = (JArray) token;
                    var arrayResult = array.Select(ProcessJToken);
                    return arrayResult;
                case JTokenType.Property:
                    var property = (JProperty) token;
                    var propertyResult = ProcessJToken(property.Value);
                    return propertyResult;
                case JTokenType.Raw:
                case JTokenType.Uri:
                case JTokenType.Comment:
                case JTokenType.Constructor:
                case JTokenType.None:
                case JTokenType.Undefined:
                    return JTokenType.String;
                case JTokenType.Null:
                    return null;
                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.String:
                case JTokenType.Boolean:
                case JTokenType.Date:
                case JTokenType.Bytes:
                case JTokenType.Guid:
                case JTokenType.TimeSpan:
                    return token.Type;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void AddToGlobalSchema(object schema, string name)
        {
            if (schema == null)
                return;

            name = name.IfNullOrWhiteSpace("JsonObject");

            if (!GlobalSchemas.ContainsKey(name))
            {
                GlobalSchemas.Add(name, new Dictionary<string, object>());
            }

            var globalSchema = GlobalSchemas[name] ?? new Dictionary<string, object>();

            var isArray = schema is IEnumerable<object>;
            var isModel = schema is Dictionary<string, object>;

            if (isArray)
            {
                // Array
                var objects = schema as IEnumerable<object>;

                foreach (var obj in objects)
                {
                    AddToGlobalSchema(obj, name);
                }
            }
            else if (isModel)
            {
                // Object
                var fields = (Dictionary<string, object>) schema;

                foreach (var field in fields)
                {
                    if (field.Key.IsNullOrWhiteSpace() || field.Value == null)
                        continue;

                    var ismodel = field.Value is Dictionary<string, object>;
                    var isarray = field.Value is IEnumerable<object>;

                    var fieldName = field.Key + (isarray ? "Array" : "");
                    var isnew = !globalSchema.ContainsKey(fieldName);

                    if (isnew)
                    {
                        if (ismodel)
                        {
                            globalSchema.Add(fieldName, fieldName);
                            AddToGlobalSchema(field.Value as Dictionary<string, object>, field.Key);
                        }
                        else if (isarray)
                        {
                            globalSchema.Add(fieldName, string.Format("Collection<{0}>", field.Key));

                            var objects = ((IEnumerable<object>) field.Value).ToArray();

                            if (!objects.Any())
                                continue;

                            foreach (var obj in objects)
                            {
                                AddToGlobalSchema(obj, field.Key);
                            }
                        }
                        else
                        {
                            globalSchema.Add(field.Key, field.Value);
                        }
                    }
                    else
                    {
                        if (ismodel)
                        {
                            if (!globalSchema[fieldName].Equals(fieldName))
                            {
                                globalSchema[fieldName] = fieldName;
                            }
                            AddToGlobalSchema(field.Value as Dictionary<string, object>, fieldName);
                        }
                        else if (isarray)
                        {
                            if (!globalSchema[fieldName].Equals(string.Format("Collection<{0}>", field.Key)))
                            {
                                globalSchema[fieldName] = string.Format("Collection<{0}>", field.Key);
                            }

                            var objects = ((IEnumerable<object>) field.Value).ToArray();

                            foreach (var obj in objects)
                            {
                                AddToGlobalSchema(obj, field.Key);
                            }
                        }
                        else
                        {
                            if (!globalSchema[fieldName].Equals(field.Value))
                            {
                                globalSchema[fieldName] = field.Value;
                            }
                        }
                    }
                }

                GlobalSchemas[name] = globalSchema;
            }
            else
            {
                // ?
                Debug.WriteLine(schema);
            }
        }

        public static string OutputGlobalSchema()
        {
            if (GlobalSchemas == null || !GlobalSchemas.Any())
                return null;

            var output = "";
            foreach (var schema in GlobalSchemas)
            {
                output += string.Format("public class {0}\r\n{{", schema.Key);
                var schemaValue = schema.Value
                    .OrderBy(o => o.Value.ToString().StartsWith("Collection"))
                    .ThenBy(t => t.Value.ToString())
                    .ThenBy(t => t.Key);

                foreach (var field in schemaValue)
                {
                    var fieldName = field.Key;
                    var fieldValue = field.Value.ToString();

                    switch (fieldValue)
                    {
                        case "String":
                            fieldValue = "string";
                            break;
                        case "Integer":
                            fieldValue = "int?";
                            break;
                        case "Decimal":
                            fieldValue = "decimal?";
                            break;
                        case "Float":
                            fieldValue = "float?";
                            break;
                        case "Date":
                            fieldValue = "DateTime?";
                            break;
                        case "TimeSpan":
                            fieldValue = "TimeSpan?";
                            break;
                        case "Boolean":
                            fieldValue = "bool?";
                            break;
                        case "Bytes":
                            fieldValue = "byte[]";
                            break;
                    }

                    if (fieldName.EndsWith("Array") || fieldValue.StartsWith("Collection"))
                    {
                        fieldName = fieldName.Replace("Array", "");
                        var modelName = fieldValue.Replace("Collection", "").Trim('<', '>');

                        var isValueArray = !GlobalSchemas.ContainsKey(modelName);

                        if (fieldValue.StartsWith("Collection") && isValueArray)
                        {
                            output += string.Format("\r\n\t[JsonProperty(PropertyName=\"{0}\")]", fieldName);
                            output += string.Format("\r\n\tpublic string V_{0} {{ get; set; }}", fieldName);
                            output +=
                                string.Format(
                                    "\r\n\r\n\t[NotMapped]\r\n\tpublic string[] V_{0}Values {{ get {{ return V_{0}.Split(','); }} set{{ V_{0} = string.Join(\", \", value); }} }}\r\n",
                                    fieldName);
                        }
                        else
                        {
                            output += string.Format("\r\n\t[JsonProperty(PropertyName=\"{0}\")]", fieldName);
                            output += string.Format("\r\n\tpublic {0} V_{1} {{ get; set; }}\r\n", fieldValue, field.Key);
                        }
                    }
                    else
                    {
                        output += string.Format("\r\n\t[JsonProperty(PropertyName=\"{0}\")]", fieldName);
                        output += string.Format("\r\n\tpublic {0} V_{1} {{ get; set; }}\r\n", fieldValue, field.Key);
                    }
                }

                output += "}\r\n";
            }

            return output;
        }
    }
}