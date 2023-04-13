using AutoMapper;
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
    public class BuyBl : BaseBl, IBuyBl
    {
        public BuyBl(IMapper mapper, IRepository unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<int> AddAsync(BuyDtoIn item)
        {
            BuyEntity entity;

            entity = _mapper.Map<BuyEntity>(item);
            entity.Id = await _unitOfWork.Buy.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
           await _unitOfWork.Buy.DeleteAsync(id);
        }

        public async Task<BuyDto> GetAsync(int id)
        {
            BuyEntity entity;
            BuyDto item;

            entity = await _unitOfWork.Buy.GetAsync(id);
            item = _mapper.Map<BuyDto>(entity);

            return item;
        }

        public async Task<List<BuyDto>> GetAsync()
        {
            List<BuyDto> list;
            List<BuyEntity> entities;
            TdcDto tdcDto;

            tdcDto = await GetTdcAsync(1);
            entities = await _unitOfWork.Buy.GetAsync();
            list = _mapper.Map<List<BuyDto>>(entities);
            list.ForEach(item =>
            {
                //Fecha de corte                
                item.DateCut = GetDateCut(tdcDto.DateCut.Day, item.DateRegistration);
                item.ListDatePays = GetListDatePays(item.DateCut, item.MonthsWhithoutInterest);

                //if (item.MonthsWhithoutInterest != 0)
                //{
                    DatePayDto datePay;

                    datePay = item.ListDatePays.Where(x => x.IsCurrent).FirstOrDefault();
                    if (datePay == null)
                    {
                        datePay = item.ListDatePays.FirstOrDefault();
                    }
                    item.DatePay = datePay.Date;
                    item.PayNumber = datePay.PayNumber;
                //}
                //else
                //{
                //    item.DatePay = new DateTime(item.DateCut.Year, item.DateCut.Month, item.DateCut.Day + 20);
                //}

                if (item.MonthsWhithoutInterest == 0)
                {
                    item.Pay = item.Amount;
                }
                else
                {
                    item.Pay = item.Amount / item.MonthsWhithoutInterest;
                }
            });

            return list;
        }

        private List<DatePayDto> GetListDatePays(DateTime dateCut, int monthsWhitoutInterest)
        {
            DateTime dateFirtsPay;
            List<DatePayDto> list;

            monthsWhitoutInterest = monthsWhitoutInterest == 0 ? 1 : monthsWhitoutInterest;
            dateFirtsPay = dateCut.AddDays(20);
            list = new List<DatePayDto>();
            for (int i = 0; i < monthsWhitoutInterest; i++)
            {
                list.Add(new DatePayDto
                {
                    Date = dateFirtsPay.AddMonths(i),
                    PayNumber = i + 1,
                    IsCurrent = dateFirtsPay.AddMonths(i).Month == DateTime.Now.Month && dateFirtsPay.AddMonths(i).Year == DateTime.Now.Year ? true : false,
                });
            }

            return list;
        }

        private DateTime GetDateCut(int day, DateTime dateRegistration)
        {
            DateTime dateCut;

            dateCut = new DateTime(dateRegistration.Year, dateRegistration.Month, day);

            if (dateRegistration >= dateCut)
            {
                return dateCut.AddMonths(1);
            }
            else
            {
                return dateCut;
            }
        }

        private async Task<TdcDto> GetTdcAsync(int tdcId)
        {
            TdcDto tdcDto;
            TdcEntity tdcEntity;

            tdcEntity = await _unitOfWork.Tdc.GetAsync(tdcId);
            tdcDto = new TdcDto
            {
                Id = tdcEntity.Id,
                DateCut = new DateTime(DateTime.Now.Year, DateTime.Now.Month, tdcEntity.DayCut),
                DatePay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, tdcEntity.DayCut + 20)
            };

            return tdcDto;
        }

        public Task UpdateAsync(BuyDtoIn item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
