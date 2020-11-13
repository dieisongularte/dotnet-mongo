using System;

namespace API.Models
{
    public class PersonageDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
