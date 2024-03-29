﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace Expenses.Repository.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration _configuration;
        const string DefaultConnection = "MySql";
        protected readonly string _stringConnection;
        protected readonly IDbConnection _dbConnection;
        public const string LastId = "SELECT LAST_INSERT_ID();";

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection= configuration.GetConnectionString(DefaultConnection);
            _dbConnection = new MySqlConnection(_stringConnection);
        }
    }
}
