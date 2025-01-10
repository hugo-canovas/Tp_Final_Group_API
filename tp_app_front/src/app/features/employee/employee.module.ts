import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { RouterModule } from '@angular/router';
import { EMPLOYEE_ROUTES } from './employee.routes';
import { AddEmployeeComponent } from './add-employee/add-employee.component';

@NgModule({
  declarations: [EmployeeComponent, AddEmployeeComponent],
  imports: [RouterModule.forChild(EMPLOYEE_ROUTES)],
})
export class EmployeeModule {}
