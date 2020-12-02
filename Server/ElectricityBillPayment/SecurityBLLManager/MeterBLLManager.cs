﻿using Electricity.DAL;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityBLLManager
{
    public class MeterBLLManager : IMeterBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public MeterBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MeterTable AddMeter(MeterTable meter)
        {
            try
            {
                meter.CreatedBy = "Admin";
                meter.CreatedDate = DateTime.Now;
                 _dbContext.MeterTable.Add(meter);
                 _dbContext.SaveChanges();
                return meter;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MeterTable> GetAll()
        {
            var meterassignLiost = _dbContext.MeterAssign.Where(p => p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).Select(c=>c.MeterAssignId).ToArray();

            List<MeterTable> meter = _dbContext.MeterTable.Where(p => !p.MeterId.Equals(meterassignLiost) && p.Status == (int)Electricity.Common.Enum.Enum.Status.Active).ToList();
            return meter;
        }


        public MeterTable UpdateMeter(MeterTable meter)
        {
            try
            {
                
                    meter.UpdatedBy = "Admin";
                    meter.UpdatedDate = DateTime.Now;
                    _dbContext.MeterTable.Update(meter);
                     _dbContext.SaveChanges();
                    return meter;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MeterTable GetById(MeterTable meter)
        {
            return _dbContext.MeterTable.Find(meter.MeterId);
        }
    }


    public interface IMeterBLLManager
    {
        MeterTable AddMeter(MeterTable meter);
        List<MeterTable> GetAll();
        MeterTable UpdateMeter(MeterTable meter);
        MeterTable GetById(MeterTable meter);


    }
}
