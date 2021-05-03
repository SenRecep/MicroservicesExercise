using FreeCourse.Shared.ServicesLib.Core;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Models
{
    internal class Category:IModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        internal string Id { get; set; }
        internal string Name { get; set; }
    }
}
