import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { EmployeeComponent } from './employee.component';

export const EMPLOYEE_ROUTES = [
  {
    path: '',
    component: EmployeeComponent,
    children: [{ path: 'add-employee', component: AddEmployeeComponent }],
  },
];
