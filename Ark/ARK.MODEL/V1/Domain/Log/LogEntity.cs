using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ARK.MODEL.V1.Domain.Log
{
    public class LogEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ID { get; set; }

        [BsonElement("Request")]
        public string Request { get; set; }

        [BsonElement("Response")]
        public string Response { get; set; }

        [BsonElement("Exception")]
        public string Exception { get; set; }

        [BsonElement("CreateDate")]
        public int CreateDate { get; set; }

        [BsonElement("CreateUser")]
        public int CreateUser { get; set; }
    }
}