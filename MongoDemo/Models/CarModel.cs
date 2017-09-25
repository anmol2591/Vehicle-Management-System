using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDemo.Models
{
    public class CarModel
    {
        [BsonId]

        public ObjectId Id { get; set; }
        [BsonElement("Carname")]

        public string Carname { get; set; }
        [BsonElement("Color")]

        public string Color { get; set; }
        [BsonElement("Price")]

        public int Price { get; set; }
        [BsonElement("Engineno")]
        public string Engineno { get; set; }
        [BsonElement("Registrationno")]

        public string Registrationno { get; set; }
        [BsonElement("RegistrationDate")]
        public string RegistrationDate { get; set; }
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("Chassisno")]
        public string Chassisno { get; set; }
    }
}