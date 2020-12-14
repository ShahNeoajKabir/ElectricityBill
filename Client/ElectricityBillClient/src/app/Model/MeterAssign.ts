import { Customer } from './Customer';
import { MeterTable } from './MeterTable';

export class MeterAssign{
  MeterAssignId:number=0;
  CustomerId:number=0;
  MeterId:number=0;
  CreatedBy:string='';
  CreatedDate:Date|undefined;
  UpdatedBy:string='';
  UpdatedDate:Date|undefined;
  Status:number=0;
  // Customer: Customer = new Customer;
  // MeterTable: MeterTable = new MeterTable;
}
