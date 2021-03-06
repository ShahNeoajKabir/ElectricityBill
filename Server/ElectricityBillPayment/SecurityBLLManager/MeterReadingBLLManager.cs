﻿using Context;
using Microsoft.EntityFrameworkCore;
using ModelClass.DTO;
using ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager
{
    public class MeterReadingBLLManager: IMeterReadingBLLManager
    {
        private readonly DatabaseContext _database;
        public MeterReadingBLLManager(DatabaseContext database)
        {
            _database = database;
        }


        public async Task<MeterReadingTable> AddMeterReading(VMAddMeterReading VmMeter , int ReaderId)
        {
            MeterReadingTable meterReadingTable = new MeterReadingTable();
            //Customer customer = new Customer();
            //MeterTable meter = new MeterTable();
            
            try
            {
                //ReaderId = 1;
                var customer = await _database.Customer.Where(p => p.MobileNo == VmMeter.MobileNo).FirstOrDefaultAsync();
                var readerzone = await _database.ZoneAssign.Where(p => p.UserId == ReaderId).FirstOrDefaultAsync();
                if (readerzone.ZoneId != customer.ZoneId)
                {
                    throw new Exception("You are not eligible for this zone");
                }
                var meternumber = await _database.MeterTable.Where(p => p.MeterNumber == VmMeter.MeterNumber).FirstOrDefaultAsync();
                if(customer!=null && meternumber != null)
                {
                    
                    var res = await _database.MeterAssign.Where(p => p.CustomerId == customer.CustomerId && p.MeterId==meternumber.MeterId && p.Status==(int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefaultAsync();
                    _database.Database.BeginTransaction();
                    meterReadingTable = new MeterReadingTable()
                    {
                        MeterId = meternumber.MeterId,
                        CustomerId = customer.CustomerId,
                        MeterAssignId = res.MeterAssignId,
                        Status = res.Status,
                        CurrentUnit = VmMeter.CurrentUnit,
                        
                        CreatedDate = DateTime.Now

                    };
                    await _database.MeterReadingTable.AddAsync(meterReadingTable);
                    await _database.SaveChangesAsync();
                    if (meterReadingTable.MeterReadingId > 0)
                    {
                        int bill=await GenerateBill(meterReadingTable, VmMeter, customer.CustomerType);
                        if (bill > 0)
                        {
                            _database.Database.CommitTransaction();
                        }
                        

                    }
                    

                    


                }
                else
                {
                    throw new Exception("Mobile No Or Meter Number Not Matched");
                }

                return meterReadingTable;
            }
            catch (Exception ex)
            {
                _database.Database.RollbackTransaction();
                throw;
            }
        }
        private async Task<int> GenerateBill(MeterReadingTable meterReadingTable, VMAddMeterReading VmMeter , int CustomerType)
        {
            BillTable bill = new BillTable();
            var unit =await _database.UnitPrice.Where(p => p.CustomerType == CustomerType && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefaultAsync();
            var Prvmonthbill = await _database.BillTable.Where(p => p.CustomerId == meterReadingTable.CustomerId && p.MeterId == meterReadingTable.MeterId).OrderBy(p=>p.CreatedDate).LastOrDefaultAsync();
            if (Prvmonthbill != null )
            {
                var usesunit = meterReadingTable.CurrentUnit - Prvmonthbill.CurrentUnit;
                if (usesunit < 0)
                {
                    throw new Exception("Something is wrong");
                }
                else {
                    if (usesunit <= 75)
                    {
                        var CalBillAmount = unit.UnitperPrice * usesunit;

                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = (int)Common.Electricity.Enum.Enum.BillStatus.UnPaid,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = Prvmonthbill.CurrentUnit,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = Prvmonthbill.CurrentMonth,
                            CreatedDate = DateTime.Now
                        };
                    }
                    else if (usesunit <= 200)
                    {
                        var unitprice = unit.UnitperPrice + 1;
                        var CalBillAmount = unitprice * usesunit;
                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = (int)Common.Electricity.Enum.Enum.BillStatus.UnPaid,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = Prvmonthbill.CurrentUnit,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = Prvmonthbill.CurrentMonth,
                            CreatedDate = DateTime.Now
                        };
                    }
                    else if (usesunit <= 400)
                    {
                        var unitprice = unit.UnitperPrice + 2;
                        var CalBillAmount = unitprice * usesunit;
                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = (int)Common.Electricity.Enum.Enum.BillStatus.UnPaid,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = Prvmonthbill.CurrentUnit,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = Prvmonthbill.CurrentMonth,
                            CreatedDate = DateTime.Now
                        };
                    }
                    else if (usesunit <= 600)
                    {
                        var unitprice = unit.UnitperPrice + 3;
                        var CalBillAmount = unitprice * usesunit;
                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = (int)Common.Electricity.Enum.Enum.BillStatus.UnPaid,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = Prvmonthbill.CurrentUnit,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = Prvmonthbill.CurrentMonth,
                            CreatedDate = DateTime.Now
                        };
                    }
                    else if (usesunit >600)
                    {
                        var unitprice = unit.UnitperPrice + 5;
                        var CalBillAmount = unitprice * usesunit;
                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = (int)Common.Electricity.Enum.Enum.BillStatus.UnPaid,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = Prvmonthbill.CurrentUnit,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = Prvmonthbill.CurrentMonth,
                            CreatedDate = DateTime.Now
                        };
                    }

                }



            }
            else
            {
                var usesunit = meterReadingTable.CurrentUnit-0;
                if (usesunit < 0)
                {
                    throw new Exception("Something is wrong please try again");
                }
                else
                {
                    if (usesunit <= 75)
                    {
                        var CalBillAmount = unit.UnitperPrice * usesunit;

                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = 1,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = 0,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = 0,

                            CreatedDate = DateTime.Now
                        };
                    }
                    else if (usesunit <= 200)
                    {
                        var unitprice = unit.UnitperPrice + 1;
                        var CalBillAmount = unitprice * usesunit;
                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = 1,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = 0,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = 0,

                            CreatedDate = DateTime.Now
                        };
                    }
                    else if (usesunit <= 400)
                    {
                        var unitprice = unit.UnitperPrice + 2;
                        var CalBillAmount = unitprice * usesunit;
                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = 1,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = 0,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = 0,

                            CreatedDate = DateTime.Now
                        };
                    }
                    else if (usesunit <= 600)
                    {
                        var unitprice = unit.UnitperPrice + 3;
                        var CalBillAmount = unitprice * usesunit;
                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = 1,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = 0,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = 0,

                            CreatedDate = DateTime.Now
                        };
                    }
                    else if (usesunit > 600)
                    {
                        var unitprice = unit.UnitperPrice + 5;
                        var CalBillAmount = unitprice * usesunit;
                        bill = new BillTable()
                        {
                            CurrentMonth = VmMeter.Month,
                            CurrentUnit = VmMeter.CurrentUnit,
                            CustomerId = meterReadingTable.CustomerId,
                            MeterId = meterReadingTable.MeterId,
                            BillStatus = 1,
                            BillAmount = CalBillAmount,
                            MeterReadingId = meterReadingTable.MeterReadingId,
                            PreviousUnit = 0,
                            Status = 1,
                            Year = VmMeter.Year,
                            PreviousMonth = 0,

                            CreatedDate = DateTime.Now
                        };
                    }
                }
               

                
            }
            await _database.BillTable.AddAsync(bill);
            await _database.SaveChangesAsync();
            return bill.BillId;
        }

        public List<MeterReadingTable> GetAll(int roleid)
        {
            List<MeterReadingTable> meter = new List<MeterReadingTable>();
            if (roleid == (int)Common.Electricity.Enum.Enum.Role.MeterReader)
            {
                var zone = _database.ZoneAssign.Where(p => p.UserId == roleid && p.Status==1).FirstOrDefault();
                var userList = _database.Customer.Where(p => p.ZoneId == zone.ZoneId).Select(c=>c.CustomerId).ToArray();
                 meter = _database.MeterReadingTable.Where(p =>userList.Contains(p.CustomerId) && p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(t => new MeterReadingTable()
                {
                    CreatedBy = t.CreatedBy,
                    CreatedDate = t.CreatedDate,
                    Status = t.Status,
                    MeterId = t.MeterId,
                    CustomerId = t.CustomerId,
                    MeterAssignId = t.MeterAssignId,
                    CurrentUnit = t.CurrentUnit
                    

                }).ToList();
                //var useridList=userList.
            }
            else
            {
                 meter = _database.MeterReadingTable.Where(p => p.Status == (int)Common.Electricity.Enum.Enum.Status.Active).Select(t => new MeterReadingTable()
                {
                    CreatedBy = t.CreatedBy,
                    CreatedDate = t.CreatedDate,
                    Status = t.Status,
                    MeterId = t.MeterId,
                    CustomerId = t.CustomerId,
                    MeterAssignId = t.MeterAssignId,
                    CurrentUnit = t.CurrentUnit

                }).ToList();
               
            }
           
            return meter;
        }

        public async Task<MeterReadingTable>UpdateMeterReading(MeterReadingTable meter)
        {
            try
            {
                
                var res = await _database.MeterReadingTable.Where(p => p.MeterReadingId == meter.MeterReadingId).AsNoTracking().FirstOrDefaultAsync();
                if (res != null)
                {
                    
                    meter.UpdatedDate = DateTime.Now;
                    _database.MeterReadingTable.Update(meter);
                    await _database.SaveChangesAsync();
                }

                return meter;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<MeterReadingTable> GetById(MeterReadingTable meter)
        {
            var res = await _database.MeterReadingTable.Where(p => p.MeterReadingId == meter.MeterReadingId).FirstOrDefaultAsync();
            return res;
        }

        //public async Task<List<MeterReadingTable>> Search(string UserName)
        //{
        //    var search = await _database.MeterReadingTable.Where(c => c.MeterAssignId.Contains(UserName)).ToListAsync();
        //    return search;
        //}


    }

    public interface IMeterReadingBLLManager
    {
        Task<MeterReadingTable> AddMeterReading(VMAddMeterReading VmMeter, int ReaderId);
        List<MeterReadingTable> GetAll(int userid);
        Task<MeterReadingTable> UpdateMeterReading(MeterReadingTable meter);
        Task<MeterReadingTable> GetById(MeterReadingTable meter);
    }
}
