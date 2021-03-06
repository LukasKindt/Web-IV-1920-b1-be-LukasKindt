﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monster.DTO_s;
using MonsterApi.Models;

namespace Monster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly IMonsterRepository _monsterRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IImageRepository _imageRepository;
        public MonsterController(IMonsterRepository context, ICustomerRepository customerRepository, IImageRepository imageRepository) {
            _monsterRepository = context;
            _customerRepository = customerRepository;
            _imageRepository = imageRepository;
        }

        /// <summary>
        /// Gets all Monsters
        /// </summary>
        /// <returns>All Monsters</returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<MonsterApi.Models.Monster> GetMonster(string name = null) {
            if (string.IsNullOrEmpty(name))
                return _monsterRepository.GetAll().OrderBy(p => p.Id);
            return _monsterRepository.GetBy(name);
        }

        /// <summary>
        /// Get the Monster with given id
        /// </summary>
        /// <param name="id">The id of the Monster</param>
        /// <returns>The Monster</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<MonsterApi.Models.Monster> GetMonster(int id) {
            MonsterApi.Models.Monster monster = _monsterRepository.GetBy(id);
            if (monster == null) { return NotFound(); }
            return monster;
        }

        [HttpGet("Favourites")]
        public IEnumerable<MonsterApi.Models.Monster> GetFavourites()
        {
            Customer customer = _customerRepository.GetBy(User.Identity.Name);
            return customer.FavouriteMonster;
        }

        /// <summary>
        /// Adds a Monster
        /// </summary>
        /// <param name="monster">The Monster</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<MonsterApi.Models.Monster> PostMonster(MonsterDTO monster) {
            MonsterApi.Models.Monster monsterToCreate = new MonsterApi.Models.Monster() { Name = monster.Name, Description = monster.Description, Attack = monster.Attack, Defense = monster.Defense, HealthPoints = monster.HealthPoints, Speed = monster.Speed };
            foreach (var m in monster.Moves) {
                monsterToCreate.AddMove(new Move(m.Name, m.PowerPoints, m.Accuracy, m.Effect, m.BasePower));
            }
            _monsterRepository.Add(monsterToCreate);
            _monsterRepository.SaveChanges();
            monster.id = monsterToCreate.Id;
            return CreatedAtAction(nameof(GetMonster), new { id = monsterToCreate.Id }, monster);
        }

        [HttpPost("addImage/{id}")]
        [AllowAnonymous]
        public ActionResult<String> AddImage(int id) {
            IFormFile files = Request.Form.Files[0];
            MonsterApi.Models.Monster monster = _monsterRepository.GetBy(id);

            if (files != null) {
                MemoryStream ms = new MemoryStream();
                files.CopyTo(ms);
                Image image = new Image
                {
                    ImageData = ms.ToArray(),
                    Monster = monster,
                    MonsterId = monster.Id
                };
                _imageRepository.addImage(image);
                _imageRepository.saveChanges();

                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("getImage/{id}")]
        [AllowAnonymous]
        public ActionResult<Image> GetImage(int id) {
            try
            {
                Image image = _imageRepository.GetByMonsterId(id);
                ImageDTO imageDTO = new ImageDTO
                {
                    ImageData = image.ImageData,
                    MonsterId = image.MonsterId
                };
                return Ok(imageDTO);
            }
            catch {
                return Ok(null);
            }
            //if (image == null) { return NotFound(); }
        }

        /// <summary>
        /// Puts a Monster at specific id
        /// </summary>
        /// <param name="id">The presumed id of the Monster</param>
        /// <param name="monster">The Monster</param>
        /// <returns>ActionResult</returns>
        [HttpPut("{id}")]
        //[AllowAnonymous]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PutMonster(int id, MonsterApi.Models.Monster monster) {
            if (id != monster.Id) { return BadRequest(); }
            _monsterRepository.Update(monster);
            _monsterRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Delete the Monster with given id
        /// </summary>
        /// <param name="id">the id of the Monster</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult DeleteMonster(int id) {
            MonsterApi.Models.Monster monster = _monsterRepository.GetBy(id);
            if (monster == null) { return NotFound(); }
            _monsterRepository.Delete(monster);
            _monsterRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Get the move with given id, given the Pokémon
        /// </summary>
        /// <param name="id">the id of the Pokémon</param>
        /// <param name="moveId">the id of the move</param>
        /// <returns>the move</returns>
        [HttpGet("{id}/moves/{moveId}")]
        [AllowAnonymous]
        public ActionResult<Move> GetMove(int id, int moveId) {
            if (!_monsterRepository.TryGetMonster(id, out var monster)) { return NotFound(); }
            Move m = monster.GetMove(moveId);
            if (m == null) { return NotFound(); }
            return m;
        }

    }

}