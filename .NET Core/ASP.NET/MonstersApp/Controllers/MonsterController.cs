using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonstersApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonstersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        #region FIELDS
        /// <summary>
        /// Service for retriving/ adding data to database/ file.
        /// </summary>
        private readonly MonsterService service;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Constructor (passing the Monster service).
        /// </summary>
        /// <returns></returns>
        public MonsterController(MonsterService service) => this.service = service;
        #endregion

        #region METHODS
        /// <summary>
        /// Set the respone for the GET request.
        /// .../api/Monster/{name}
        /// </summary>
        /// <returns></returns>
        [HttpGet("{name}")]
        public Monster GetMonster(String name) => service.GetMonster(name);

        /// <summary>
        /// Set the response for DELETE request.
        /// .../api/Monster/{name}
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete("{name}")]
        public string DeleteMonster(String name) => service.DeleteByName(name);

        /// <summary>
        /// Set the response for POST request.
        /// .../api/Monster
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddMonster([FromBody] Monster monster) => service.AddMonster(monster);

        /// <summary>
        /// Set the reposne for PUT request.
        /// .../api/Monster/{name}
        /// </summary>
        /// <param name="name"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
        [HttpPut("{name}")]
        public string UpdateMonster(string name, [FromBody] Monster monster) => service.UpdateMonster(name, monster);
        #endregion
    }
}
