using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryApi.Controllers
{
    internal static class ControllerHelper
    {
        public static string SerializeEntity<TEntity>(TEntity entity) => JsonConvert.SerializeObject(entity);

        public static IEnumerable<string> SerializeEntities<TEntity>(IEnumerable<TEntity> entities) =>
            entities.Select(item => SerializeEntity(item)).ToArray();

        public static TEntity DeserializeEntity<TEntity>(string entity) => JsonConvert.DeserializeObject<TEntity>(entity);
    }
}
