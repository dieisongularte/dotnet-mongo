using System;
using API.Data.Collections;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonageController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Personage> _personagesCollection;

        public PersonageController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _personagesCollection = _mongoDB.DB.GetCollection<Personage>(typeof(Personage).Name.ToLower());
        }

        [HttpGet]
        public ActionResult ObterPersonages()
        {
            var personages = _personagesCollection.Find(Builders<Personage>.Filter.Empty).ToList();
            return Ok(personages);
        }

        [HttpGet("{id:length(24)}", Name = "GetPersonage")]
        public ActionResult<Personage> ObterPersonage(string id)
        {
            var personage = _personagesCollection.Find<Personage>(personage => personage.Id == id).FirstOrDefault();
            if (personage == null)
            {
                return NotFound();
            }
            return personage;
        }

        [HttpPost]
        public ActionResult SalvarPersonage([FromBody] PersonageDto dto)
        {
            var personage = new Personage(dto.Nome, dto.Sexo, dto.DataNascimento, dto.Latitude, dto.Longitude);
            _personagesCollection.InsertOne(personage);
            return StatusCode(201, "Personage adicinado com sucesso.");
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, PersonageDto personageIn)
        {
            var p = _personagesCollection.Find<Personage>(personage => personage.Id == id).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            var personage = new Personage(personageIn.Nome, personageIn.Sexo, personageIn.DataNascimento, personageIn.Latitude, personageIn.Longitude);
            personage.Id = id;
            _personagesCollection.ReplaceOne(personage => personage.Id == id, personage);
            return NoContent();
        }
    }
}
