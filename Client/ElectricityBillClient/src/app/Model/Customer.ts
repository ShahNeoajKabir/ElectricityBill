import { Zone } from './Zone';

export class Customer{
  CustomerId:number=0;
  UserId:number=0;
  ZoneId:number=0;
  CustomerName:string='';
  FatherName:string='';
  MotherName:string='';
  Email:string='';
  Password:string=''
  MobileNo:string=''
  DateOfBirth:Date|undefined;
  Gender:number=0;
  Religion:number=0;
  Nationality:number=0;
  BloodGroup:number=0;
  Address:string='';
  CustomerType:number=0;
  Latitude=0;
  Longitude=0;
  CreatedBy:string='';
  CreatedDate:Date|undefined;
  UpdatedBy:string='';
  UpdatedDate:Date|undefined;
  Status:number=0;
  Image:string='';

}

export class CustomerLocation{
  Latitude=0;
  Longitude=0;
}
