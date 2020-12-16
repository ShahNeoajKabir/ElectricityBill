using Context;
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
            List<BillTable> bill = _database.BillTable.ToList();
            return bill;
        }

        //public List<BillTable> GetAll()
        //{

        //}
    }


    public interface IBillTableBLLManager
    {
        List<BillTable> GetAll();
    }
}
