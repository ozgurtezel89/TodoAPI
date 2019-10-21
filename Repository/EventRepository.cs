using System.Collections.Generic;
using TodoApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Data.SqlClient;

namespace TodoApi.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        
        int AddEvent(Event myEvent);
    }

    public class EventRepository : IEventRepository
    {
        #region Dependencies#
            private readonly IConfiguration configuration;
        #endregion

        // Constructor
        public EventRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // Database Connection property
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(this.configuration.GetConnectionString("DevelopmentDatabaseConnection"));

            }
        }

        public IEnumerable<Event> GetAllEvents()
        {
            using(var db = Connection)
            {
                string qry ="select * from [Event] e join EventLocation el on e.Id = el.Id";

                var eventEntry = Connection.Query<Event, EventLocation, Event>(
                        sql: qry,
                        (EventEntry, EventLocation) =>
                        {
                            EventEntry.EventLocation = EventLocation;
                            return EventEntry;
                        },
                        splitOn: "Id");

                return eventEntry;
            }
        }

        public int AddEvent(Event myEvent)
        {
            if(myEvent == null)
            {
                throw new ArgumentNullException(nameof(myEvent));
            }

            using(var db = Connection)
            {
                return db.Execute("insert into [Event] ( EventLocationId, EventName, EventDate, DateCreated) values (@eventLocationId, @eventName, @eventDate, @dateCreated)", new { eventLocationId = myEvent.EventLocationId, eventName = myEvent.EventName, eventDate = myEvent.EventDate, dateCreated = myEvent.DateCreated });
            }
        }
    }
}