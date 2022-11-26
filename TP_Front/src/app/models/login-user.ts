export class LoginUser {
    UserName: string;
    password: string;

    constructor(UserName: string, password: string) {
        this.UserName = UserName;
        this.password = password;
    }
}
