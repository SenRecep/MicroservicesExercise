using System;

using FreeCourse.Shared.ServicesLib.Core;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace FreeCourse.Services.Catalog.Models
{
    internal class Course : IModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        internal string Id { get; set; }
        internal string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        internal decimal Price { get; set; }

        internal string Picture { get; set; }

        internal string Description { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        internal DateTime CreatedTime { get; set; }

        internal string UserId { get; set; }


        internal Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        internal string CategoryId { get; set; }

        [BsonIgnore]
        internal Category Category { get; set; }
    }
}
