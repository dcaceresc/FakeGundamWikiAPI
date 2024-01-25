import { Routes } from "@angular/router";
import { RolesComponent } from "./roles.component";
import { AddRoleComponent } from "./add-role/add-role.component";
import { UpdateRoleComponent } from "./update-role/update-role.component";

export const routes: Routes = [
    {path: '', component: RolesComponent},
    {path: 'create', component: AddRoleComponent},
    {path: 'edit/:id', component: UpdateRoleComponent},
];