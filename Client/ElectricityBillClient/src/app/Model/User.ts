export class User{
    UserId: number=0;
    UserName: string='';
    Email: string='';
    Password: string='';
    MobileNo: string='';
    UserTypeName: string='';
    UserTypeId: number=0;
    Gender:number=0;
    CreatedBy: string='';
    CreatedDate: Date |undefined;
    UpdatedBy: string='';
    UpdatedDate: Date|undefined;
    Status: number=0;
    Image:string='';
    ZoneId:number;
    Role:number;
}

export class VmUsers{
    UserId: number=0;
    UserName: string='';
    Email: string='';
    MobileNo: string='';
    Status: number=0;
    RoleName:number;
}
