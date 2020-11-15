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

        [HttpPost]
        public ActionResult SalvarPersonage([FromBody] PersonageDto dto)
        {
            var personage = new Personage(dto.Nome, dto.Sexo, dto.DataNascimento, dto.Latitude, dto.Longitude);
            _personagesCollection.InsertOne(personage);
            return StatusCode(201, "Personage adicinado com sucesso.");
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
    }
}
