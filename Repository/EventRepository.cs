using System.Collections.Generic;
using TodoApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace TodoApi.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
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
                return db.Query<Event>("select * from [EVENT]").ToList();
            }
        }
    }
}