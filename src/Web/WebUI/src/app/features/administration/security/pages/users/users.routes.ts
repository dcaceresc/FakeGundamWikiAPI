import { Routes } from "@angular/router";
import { UsersComponent } from "./users.component";
import { AddUserComponent } from "./add-user/add-user.component";
import { UpdateUserComponent } from "./update-user/update-user.component";

export const routes: Routes = [
    {path: '',component:UsersComponent},
    {path: 'create',component:AddUserComponent},
    {path: 'edit/:id',component:UpdateUserComponent},
];