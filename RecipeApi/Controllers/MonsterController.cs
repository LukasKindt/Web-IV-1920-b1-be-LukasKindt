using System;
using System.Collections.Generic;
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
        public MonsterController(IMonsterRepository context, ICustomerRepository customerRepository) {
            _monsterRepository = context;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Gets all Pokémon
        /// </summary>
        /// <returns>All Pokémon</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<MonsterApi.Models.Monster> GetMonster() {
            return _monsterRepository.GetAll().OrderBy(p => p.Id);
        }

        /// <summary>
        /// Get the Pokémon with given id
        /// </summary>
        /// <param name="id">The id of the Pokémon</param>
        /// <returns>The Pokémon</returns>
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        /// Adds a Pokémon
        /// </summary>
        /// <param name="monster">The Pokémon</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<MonsterApi.Models.Monster> PostMonster(MonsterDTO monster) {
            MonsterApi.Models.Monster monsterToCreate = new MonsterApi.Models.Monster() { Name = monster.Name, Description = monster.Description };
            foreach (var m in monster.Moves) {
                monsterToCreate.AddMove(new Move(m.Name, m.PowerPoints, m.Accuracy, m.Effect, m.BasePower));
            }
            _monsterRepository.Add(monsterToCreate);
            _monsterRepository.SaveChanges();

            return CreatedAtAction(nameof(GetMonster), new { id = monsterToCreate.Id }, monster);
        }

        /// <summary>
        /// Puts a Pokémon at specific id
        /// </summary>
        /// <param name="id">The presumed id of the Pokémon</param>
        /// <param name="monster">The Pokémon</param>
        /// <returns>ActionResult</returns>
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PutMonster(int id, MonsterApi.Models.Monster monster) {
            if (id != monster.Id) { return BadRequest(); }
            _monsterRepository.Update(monster);
            _monsterRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Delete the Pokémon with given id
        /// </summary>
        /// <param name="id">the id of the Pokémon</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Move> GetMove(int id, int moveId) {
            if (!_monsterRepository.TryGetMonster(id, out var monster)) { return NotFound(); }
            Move m = monster.GetMove(moveId);
            if (m == null) { return NotFound(); }
            return m;
        }

    }

}