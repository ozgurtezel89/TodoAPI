using Microsoft.AspNetCore.Mvc;
using TodoApi.Repository;
using System.Linq;
using TodoApi.Models;
using System.Collections.Generic;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class EventsController : Controller 
    {
        #region Dependencies
            private readonly IEventRepository EventRepository;
        #endregion

        // Construction
        public EventsController(IEventRepository eventRepository)
        {
            this.EventRepository = eventRepository ?? throw new System.ArgumentNullException(nameof(eventRepository));
        }

        /// <summary>
        /// Gets a colleciton of Events
        /// </summary>      
        /// <response code="200">Returns list of events</response>  
        /// <response code="404">No events found</response> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetEvents()
        {
            IEnumerable<Event> events = this.EventRepository.GetAllEvents();

            if(!events.Any() || events == null )
            {
                return NotFound();
            }

            return Ok(events);
        }
    }
}