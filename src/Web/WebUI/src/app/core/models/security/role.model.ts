export interface RoleDto{
    roleId:number;
    roleName:string;
    isActive: boolean;
}

export interface RoleVM{
    roleId:number;
    roleName:string;
}

export interface CreateRoleCommand{
    roleName:string;
}

export interface UpdateRoleCommand{ 
    roleId:number;
    roleName:string;
}



