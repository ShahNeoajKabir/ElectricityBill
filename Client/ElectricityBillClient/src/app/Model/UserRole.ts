import { Role } from './Role';
import { User } from './User';

export class UserRole  {
           UserRoleId:number=0;
           RoleId:number=0;
           UserId:number=0;
           CreatedBy:string='';
           CreatedDate:Date|undefined;
           UpdatedBy:string='';
           UpdatedDate:Date|undefined;
           Status:number=0;
           Role:Role = new Role;
           User:User = new User;
}
