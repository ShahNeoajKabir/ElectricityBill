export enum Gender {
  Male= 1,
  Female= 2,
  Select= -1
}
export enum Status {
  Active= 1,
  Inactive= 2,
  Delete= 3

}

export enum CustomerType{

  Business=1,
  Economi=2,
  House=3

}

export enum Religion{

  Muslim = 1,
  Hindhu = 2,
  Cristian = 3,
  Budho=4

}
export enum UserType {
  Admin= 1,
  CoOrdinator= 2,
  Customer= 3,
  MeterReader= 4,
  SuperAdmin= -1

}
export enum ErrorCode {
  INTERNAL_SERVER_ERROR = 500,
  BAD_REQUEST = 400,
  NOT_FOUND = 404,
  UNAUTHENTICATE = 401,
  UNAUTHORIZED = 403,
  TOKEN_EXPIRED = 402,
  SESSION_EXPIRED = 419,
  MISSING_TOKEN = 417,
  INVALID_TOKEN_FORMAT = 406
}