﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AppAdmin.Infrastructure
{
    public static class SessionExtentions
    {
        public static void SetJson(this ISession session,string key,object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJSon<T>(this ISession session,string key)
        {
            var data = session.GetString(key);

            return data == null ?
                default(T) : JsonConvert.DeserializeObject<T>(data);
        }
             
    }
}
