﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Customer
    {
        public Customer(){
            }
        public int CustomerId { get; set; }
        public int? UserId { get; set; }
        public int ZoneId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public int Religion { get; set; }
        public int Nationality { get; set; }
        public int BloodGroup { get; set; }
        public string Address { get; set; }
        public int CustomerType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }
        public string Image { get; set; }
        public  ICollection<MeterAssign> MeterAssign { get; set; }
        

    }

    public class CustomerSearch
    {
        public string Search { get; set; }
    }
}
