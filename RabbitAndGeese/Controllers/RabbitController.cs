using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitAndGeese.DataAccess;
using RabbitAndGeese.Models;

namespace RabbitAndGeese.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitController : ControllerBase
    {
        private RabbitStorage _storage;

        public RabbitController()
        {
            _storage = new RabbitStorage();
        }
        [HttpPost]
        public void AddACustomer(Rabbit rabbit)
        {
            //var storage = new RabbitStorage();
            _storage.Add(rabbit);
        }

        [HttpPut("{id}/geese")]
        // adding a goose to exising rabbit customer
        // the id must match the parameter. LETTER TO LETTER
        public IActionResult AddGooseToRabbit(int id, Goose goose)
        {
            //var storage = new RabbitStorage();
            var rabbit = _storage.GetById(id);

            if (rabbit == null) return NotFound();

            rabbit.OwnedGeese.Add(goose);
            return Ok();
        }

        [HttpPut("{id}/saddles")]
        public IActionResult ProcureGooseSaddle(int id, Saddle saddle)
        {
            //var storage = new RabbitStorage();
            var rabbit = _storage.GetById(id);

            if (rabbit == null) return NotFound();

            rabbit.OwnedSaddles.Add(saddle);
            return Ok();
        }

    }
}