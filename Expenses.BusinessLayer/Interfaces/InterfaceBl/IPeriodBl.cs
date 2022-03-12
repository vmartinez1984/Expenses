﻿using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces.InterfaceBl
{
    public interface IPeriodBl
    {
        List<PeriodDtoOut> Get(bool isActive = true);
        int Add(PeriodDtoIn item);
        void Update(PeriodDtoIn item, int id);
        PeriodDtoOut Get(int id);
        Task<PeriodDtoOut> GetFullAsync(int id);        
    }
}