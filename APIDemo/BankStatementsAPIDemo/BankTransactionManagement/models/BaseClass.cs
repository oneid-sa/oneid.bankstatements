using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionManagement.models
{
    public class BaseClass
    {
        public void CopyObjectsUsingType(Type type, Object source, Object destination)
        {
            FieldInfo[] myObjectFields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
        }

        public T JSONToObject<T>(String JSON)
        {
            T objectFromJSON = JsonConvert.DeserializeObject<T>(JSON, new JsonSerializerSettings
            {

                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });

            return objectFromJSON;
        }

        public String JSONFromObject(Object ObjectToSerialise)
        {
            String JSON = JsonConvert.SerializeObject(ObjectToSerialise, new JsonSerializerSettings
            {

                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore

            });

            return JSON;
        }

        public String ToJSON()
        {
            String JSON = JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });

            return JSON;
        }
    }
}
