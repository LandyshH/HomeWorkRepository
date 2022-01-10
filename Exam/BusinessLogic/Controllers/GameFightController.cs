using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Characters;
using BusinessLogic.FightLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Controllers
{
    [Route("[controller]")]
    public class GameFightController : ControllerBase
    {
        [HttpPost]
        [Route("Fight")]
        public FightResult Post([FromBody] Opponents opponents)
        {
            var fight = new Fight();
            
            var result = new FightResult
            {
                ActionsList = fight.FightProcess(opponents), 
                IsUserWon = fight.Winner == Winner.User
            };
            
            return result;
        }
    }
}