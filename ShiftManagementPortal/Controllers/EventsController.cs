using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShiftManagementPortal.API.Models;
using ShiftManagementPortal.Core.Domain.Model;
using ShiftManagementPortal.Core.Domain.Rules.Exceptions;
using ShiftManagementPortal.Core.Repository;
using ShiftManagementPortal.Infrastructure.Constants;
using ShiftManagementPortal.UI.ViewModel.Event;

namespace ShiftManagementPortal.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class EventsController : BaseController
    {
        private readonly IVenueRepository _venueRepository;

        public EventsController(IVenueRepository venueRepository, ILogger<BaseController> logger, IMapper mapper)
            : base(logger, mapper)
        {
            _venueRepository = venueRepository;
        }
        // GET: api/Events
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET: api/Events/5
        [Authorize]
        [HttpGet("{id}", Name = EventConstants.GET_EVENT_BY_ID)]
        [ProducesResponseType(typeof(EventListItemViewModel), 200)]
        [ProducesResponseType(typeof(ApiMessageModel), 404)]
        [ProducesResponseType(typeof(ApiMessageModel), 500)]
        public IActionResult Get(long id)
        {
            var evnt = new Event
            {
                Id = 12345,
                Name = "Mas Domnik 2015",
                Description = "The most pulsating stuff",
                Date = new DateTime(2018, 02, 24)
            };
            return Ok(Mapper.Map<EventListItemViewModel>(evnt));
        }
        
        // POST: api/Events
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]string value)
        {
            return null;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
