﻿using AutoMapper;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Dtos;
using Expenses.Core.Entities;
using Expenses.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class ApartBl : BaseBl, IApartBl
    {
        public ApartBl(IMapper mapper, IRepository unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<int> AddAsync(ApartDtoIn item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        //public async Task<List<ApartDto>> GetAsync(int? subcategoryId)
        //{
        //    List<ApartEntity> entities;
        //    List<ApartDto> list;
        //    const int AhorroN = 16;

        //    entities = await _unitOfWork.Apart.GetAsync(subcategoryId);
        //    list = _mapper.Map<List<ApartDto>>(entities);
        //    await SetCategoryNameAsync(list);
        //    if(subcategoryId == AhorroN)
        //        await SetApartN(list);

        //    return list;
        //}

        public async Task<PagerDto> GetAsync(PagerDto pagerDto)
        {
            List<ApartEntity> entities;
            List<ApartDto> list;
            PagerEntity pagerEntity;
            const string AhorroN = "16";

            pagerEntity = _mapper.Map<PagerEntity>(pagerDto);
            entities = await _unitOfWork.Apart.GetAsync(pagerEntity);
            list = _mapper.Map<List<ApartDto>>(entities);
            await SetCategoryNameAsync(list);
            if (pagerDto.SubcategoryId == AhorroN)
                await SetApartN(list);
            pagerDto = _mapper.Map<PagerDto>(pagerEntity);
            pagerDto.List = list;

            return pagerDto;
        }

        private async Task SetApartN(List<ApartDto> list)
        {
            List<ApartEntity> entities;
            List<ApartDto> dtos;

            entities = await _unitOfWork.Apart.GetAsync();
            entities = entities.Where(x=> x.IsApartN == true).ToList();
            dtos = _mapper.Map<List<ApartDto>>(entities);

            list.AddRange(dtos);
        }

        private async Task SetCategoryNameAsync(List<ApartDto> list)
        {
            List<SubcategoryEntity> subcategories;

            subcategories = await _unitOfWork.Subcategory.GetAsync();
            list.ForEach(apart =>
            {
                SubcategoryEntity subcategory;

                subcategory = subcategories.Where(x => x.Id == apart.SubcategoryId).FirstOrDefault();
                apart.SubcategoryName = subcategory.Name;
            });
        }

        public Task<ApartDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(ApartDtoIn item, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
