export interface UserDto{
    UserId: number;
    userName: string;
    firstName: string;
    lastName: string;
    roleNames: string[];
    isActive: boolean;
}

export interface UserVM{
    UserId: number;
    userName: string;
    firstName: string;
    lastName: string;
    roleIds: number[];
}


export interface CreateUserCommand {
    userName: string;
    firstName: string;
    lastName: string;
    roleIds: number[];
}

export interface UpdateUserCommand {
    userId:number;
    userName: string;
    firstName: string;
    lastName: string;
    roleIds: number[];
}


