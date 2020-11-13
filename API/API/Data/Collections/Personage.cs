using System;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Collections
{
    public class Personage
    {
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
