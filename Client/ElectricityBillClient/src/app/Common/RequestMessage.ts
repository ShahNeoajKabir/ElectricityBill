export class RequestMessage {
  UserId: string;
  SessionId: number;
  Content: string;
  UserTypeId: number;

  constructor(UserID: string, SessionId: number, reqBody: any, UserTypeId: number) {
      this.UserId = UserID;
      this.SessionId = SessionId;
      this.Content = JSON.stringify(reqBody);
      this.UserTypeId = UserTypeId;
  }
}
