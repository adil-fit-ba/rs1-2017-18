using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace eUniverzitet.Web.Helper
{
    public static class SessionExtension
    {
        // preuzeto https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?tabs=aspnetcore2x
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            return session.GetString(key) == null
                ? default(T)
                : JsonConvert.DeserializeObject<T>(session.GetString(key));
        }
    }
}
