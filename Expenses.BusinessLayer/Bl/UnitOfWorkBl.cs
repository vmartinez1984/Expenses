using Expenses.BusinessLayer.Interfaces;
using System;
using Microsoft.Extensions.Configuration;

namespace Expenses.BusinessLayer.Bl
{
    public class UnitOfWorkBl : IUnitOfWorkBl
    {
        private IConfiguration _configuration;

        public UnitOfWorkBl(IConfiguration configuration, ICategoryBl category)
        {
            _configuration = configuration;
            Category = category;
        }

        public ICategoryBl Category { get; }
    }
}