using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJsonSerializerDeseri
{
    public static class CustomJson
    {
        public static string ToJson(this Object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            var json = "{";
            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value != null)
                {
                    json += $"\"{property.Name}\":\"{value}\",";
                }
            }
            json = json.Remove(json.Length - 1);
            json += "}";
            return json;
        }

        public static T FromJson<T>(this string json)
        {
            var obj = Activator.CreateInstance<T>();
            var properties = typeof(T).GetProperties();
            int index = 0;

            while (index < json.Length)
            {
                //Her propertynin adi ve deyerinin pozisiyasini tapir
                int nameStart = json.IndexOf('"', index) + 1;
                int nameEnd = json.IndexOf('"', nameStart);
                string propertyName = json.Substring(nameStart, nameEnd - nameStart);

                int valueStart = json.IndexOf(':', nameEnd) + 1;
                int valueEnd = json.IndexOfAny(new char[] { ',', '}' }, valueStart);
                string value = json.Substring(valueStart, valueEnd - valueStart).Trim();

                //Eger eded daxil olubsa onu ehate eden iki qat dirnaq isaresini goturur
                if (value.Length >= 2 && value[0] == '"' && value[value.Length - 1] == '"')
                {
                    value = value.Substring(1, value.Length - 2);
                }

                //Uygun propertyni tapir ve deyerini verir
                var property = properties.FirstOrDefault(p => p.Name == propertyName);
                if (property != null)
                {
                    // Convert the string value to the property type using ChangeType
                    object convertedValue = Convert.ChangeType(value, property.PropertyType);
                    property.SetValue(obj, convertedValue);
                }
                index = valueEnd + 1;
            }
            return obj;
        }

    }
}
