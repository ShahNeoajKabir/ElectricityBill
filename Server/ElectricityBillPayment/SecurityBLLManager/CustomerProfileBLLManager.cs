using Context;
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
    public class CustomerProfileBLLManager: ICustomerProfileBLLManager
    {
        private readonly DatabaseContext _database;
        public CustomerProfileBLLManager(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<VMProfile>ViewProfile(int UserId)
        {
            try
            {

                
                var customer = _database.Customer.Where(p => p.UserId == UserId).FirstOrDefault();
                var meterassign = _database.MeterAssign.Where(p => p.CustomerId == customer.CustomerId && p.Status==(int)Common.Electricity.Enum.Enum.Status.Active).FirstOrDefault();
                var meter = _database.MeterTable.Where(p => p.MeterId == meterassign.MeterId).FirstOrDefault();
                VMProfile vMProfile = new VMProfile()
                {
                    CustomerId=customer.CustomerId,
                    CustomerName=customer.CustomerName,
                    Email=customer.Email,
                    Image=customer.Image,
                    MeterNumber=meter.MeterNumber,
                    MobileNo=customer.MobileNo,
                    ZoneName=_database.Zone.FirstOrDefault(p=>p.ZoneId==customer.ZoneId).ZoneName

                };
                return vMProfile;





            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


    public interface ICustomerProfileBLLManager
    {
        Task<VMProfile> ViewProfile(int UserId);
    }
}
