using System.Collections.Generic;
using TodoApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace TodoApi.Repository
{
    public interface IEventRepository
    {
        IEnumerable<EventEntry> GetAllEvents();
        
        int AddEvent(EventEntry myEvent);
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

        public IEnumerable<EventEntry> GetAllEvents()
        {
            using(var db = Connection)
            {
                return db.Query<EventEntry>("select * from [EVENT]").ToList();
            }
        }

        public int AddEvent(EventEntry myEvent)
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