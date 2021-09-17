using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletMiddleware.CheckData
{
    public static class JsonHelper
    {
        private static readonly JsonSerializer JsonSerializer = new JsonSerializer();
        public static string Serialize(object obj)
        {
            IsoDateTimeConverter isoDateTimeConverter = new IsoDateTimeConverter();
            isoDateTimeConverter.DateTimeFormat = ("yyyy-MM-dd HH:mm:ss");
            return JsonConvert.SerializeObject(obj, new JsonConverter[]
            {
                isoDateTimeConverter
            });
        }
        public static System.Collections.Generic.IList<string> SerializeObjects(System.Collections.Generic.IList<object> objects)
        {
            if (objects == null || objects.Count == 0)
            {
                return null;
            }
            System.Collections.Generic.IList<string> list = new System.Collections.Generic.List<string>();
            foreach (object current in objects)
            {
                list.Add(JsonHelper.Serialize(current));
            }
            return list;
        }
        public static object Deserialize(string json)
        {
            System.IO.StringReader stringReader = new System.IO.StringReader(json);
            return JsonHelper.JsonSerializer.Deserialize(new JsonTextReader(stringReader));
        }
        public static System.Collections.Generic.IList<object> DeserializeJsons(System.Collections.Generic.IList<string> jsonList)
        {
            if (jsonList == null || jsonList.Count == 0)
            {
                return null;
            }
            System.Collections.Generic.IList<object> list = new System.Collections.Generic.List<object>();
            foreach (string current in jsonList)
            {
                list.Add(JsonHelper.Deserialize(current));
            }
            return list;
        }
        public static TObj Deserialize<TObj>(string json) where TObj : class
        {
            System.IO.StringReader stringReader = new System.IO.StringReader(json);
            return JsonHelper.JsonSerializer.Deserialize(new JsonTextReader(stringReader), typeof(TObj)) as TObj;
        }
        public static TObj DeserializeOnly<TObj>(string json)
        {
            System.IO.StringReader stringReader = new System.IO.StringReader(json);
            return (TObj)((object)JsonHelper.JsonSerializer.Deserialize(new JsonTextReader(stringReader), typeof(TObj)));
        }
        public static JObject DeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject(json) as JObject;
        }
        public static JArray DeserializeArray(string json)
        {
            return JsonConvert.DeserializeObject(json) as JArray;
        }

    }
}
