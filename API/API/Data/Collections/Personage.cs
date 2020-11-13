using System;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API.Data.Collections
{
    public class Personage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Personage(string nome, string sexo, DateTime dataNascimento, double latitude, double longitude)
        {
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Localizacao = new GeoJson2DGeographicCoordinates(latitude, longitude);
        }
    }
}
