using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class MyAllTasks : Controller
    {
        private readonly IDailyTasksRepository dailyTasksRepository;

        // constructer MyAllTasks repository
        public MyAllTasks(IDailyTasksRepository dailyTasksRepository)
        {
            this.dailyTasksRepository = dailyTasksRepository ?? throw new ArgumentNullException(nameof(dailyTasksRepository));
        }

        /// <summary>
        /// Gets a colleciton of my all tasks
        /// </summary>      
        /// <response code="200">Returns list of tasks</response>  
        /// <response code="404">No tasks found</response>  
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var myDailyTasks = this.dailyTasksRepository.GetMyDailyTasksPlease();
            
            if(!myDailyTasks.Any())
            {
                // sends a 404 not found result
                return NotFound();
            }

            return Ok(myDailyTasks);
        }
    }
}