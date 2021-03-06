﻿using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class BillTableBLLManager: IBillTableBLLManager
    {
        private readonly DatabaseContext _database;
        public BillTableBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        

        public List<BillTable> GetAll()
        {
            List<BillTable> bill = _database.BillTable.Select(t => new BillTable()
            {
                CreatedBy = t.CreatedBy,
                CreatedDate = t.CreatedDate,
                CurrentMonth = t.CurrentMonth,
                CurrentUnit = t.CurrentUnit,
                CustomerId = t.CustomerId,
                BillAmount = t.BillAmount,
                BillId = t.BillId,
                BillStatus = t.BillStatus,
                UpdatedBy = t.UpdatedBy,
                MeterId = t.MeterId,
                MeterReadingId = t.MeterReadingId,
                MeterReadingTable = t.MeterReadingTable,
                PreviousMonth = t.PreviousMonth,
                PreviousUnit = t.PreviousUnit,
                Payment = t.Payment,
                UpdatedDate = t.UpdatedDate,
                Status = t.Status,
                Year = t.Year
            }).ToList();
            List<BillTable> data = new List<BillTable>();
            foreach (var item in bill)
            {
                item.CustomerName = _database.Customer.Where(p => p.CustomerId == item.CustomerId).FirstOrDefault().CustomerName;
                item.MeterNumber = _database.MeterTable.Where(p => p.MeterId == item.MeterId).FirstOrDefault().MeterNumber;
                data.Add(item);
            }
            return data;
        }

        public List<BillTable> GetByCustomer(int userid)
        {
            var customer = _database.Customer.Where(p => p.UserId == userid && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefault();
            List<BillTable> bill = _database.BillTable.Where(p=>p.CustomerId== customer.CustomerId).Select(t => new BillTable()
            {
                CreatedBy = t.CreatedBy,
                CreatedDate = t.CreatedDate,
                CurrentMonth = t.CurrentMonth,
                CurrentUnit = t.CurrentUnit,
                CustomerId = t.CustomerId,
                BillAmount = t.BillAmount,
                BillId = t.BillId,
                BillStatus = t.BillStatus,
                UpdatedBy = t.UpdatedBy,
                MeterId = t.MeterId,
                MeterReadingId = t.MeterReadingId,
                MeterReadingTable = t.MeterReadingTable,
                PreviousMonth = t.PreviousMonth,
                PreviousUnit = t.PreviousUnit,
                Payment = t.Payment,
                UpdatedDate = t.UpdatedDate,
                Status = t.Status,
                Year = t.Year,
                
            }).ToList();
            List<BillTable> data = new List<BillTable>();
            foreach (var item in bill)
            {
                item.CustomerName = _database.Customer.Where(p => p.CustomerId == item.CustomerId).FirstOrDefault().CustomerName;
                item.MeterNumber = _database.MeterTable.Where(p => p.MeterId == item.MeterId).FirstOrDefault().MeterNumber;
                data.Add(item);
            }
            return data;
        }

        public async Task<BillTable> GetById(BillTable bill)
        {
            var res = await _database.BillTable.Where(e => e.BillId == bill.BillId).FirstOrDefaultAsync();
            return res;
        }

        //public List<BillTable> GetAll()
        //{

        //}
    }


    public interface IBillTableBLLManager
    {
        List<BillTable> GetAll();
        Task<BillTable> GetById(BillTable bill);
        public List<BillTable> GetByCustomer(int userid);
    }
}
