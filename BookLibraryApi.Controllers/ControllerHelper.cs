using Newtonsoft.Json;

namespace BookLibraryApi.Controllers
{
    internal static class ControllerHelper
    {
        public static string Serialize<TEntity>(TEntity entity) => JsonConvert.SerializeObject(entity);

        public static TEntity Deserialize<TEntity>(string entity) => JsonConvert.DeserializeObject<TEntity>(entity);
    }
}
