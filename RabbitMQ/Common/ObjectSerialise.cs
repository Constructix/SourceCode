using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Common
{
    public static class ObjectSerialise
    {
        public static byte[] Serialize(this Object obj)
        {
            if (obj == null)
                return null;

            var json = JsonConvert.SerializeObject(obj);
            return Encoding.Default.GetBytes(json);
        }


        public static object DeSerialize(this byte[] arrBytes, Type type)
        {


            string bytesAsString = Encoding.Default.GetString(arrBytes);

            return JsonConvert.DeserializeObject(bytesAsString, type);
        }

        public static string DeSerializeText(this byte[] arrBytes)
        {
            return Encoding.Default.GetString(arrBytes);
        }
    }
}