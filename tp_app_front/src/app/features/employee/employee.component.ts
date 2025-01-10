import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { Observable } from 'rxjs';
import { EmployeeService } from './services/employee.service';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { Employee } from './models/employee.interface';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
})
export class EmployeeComponent implements OnInit {
  public employees$: Observable<Employee[]>;
  public isLoading: boolean = true;

  constructor(
    private dialogRef: MatDialog,
    private employeeService: EmployeeService,
    private toastr: ToastrService
  ) {
    this.employees$ = this.employeeService.getAllEmployess();
  }

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.isLoading = true;
    this.employees$ = this.employeeService.getAllEmployess();
    this.employees$.subscribe({
      next: () => {
        this.isLoading = false;
      },
      error: (err: HttpErrorResponse) => {
        this.toastr.error('', 'Failed to load employees: ' + err.message, {
          closeButton: true,
        });
        this.isLoading = false;
      },
    });
  }

  addEmployee(): void {
    const dialogRef = this.dialogRef.open(AddEmployeeComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.isLoading = true;
        this.employeeService.createEmployee(result).subscribe({
          next: () => {
            this.toastr.success('', 'Employee added successfully', {
              closeButton: true,
            });
            this.loadEmployees();
          },
          error: (err: HttpErrorResponse) => {
            this.toastr.error('', 'Something went wrong: ' + err.message, {
              closeButton: true,
            });
          },
        });
      }
    });
  }
}
