import { Component } from '@angular/core';
import { EmployeeService } from './services/employee.service';
import { Subscription } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  private subscription: Subscription = new Subscription();
  constructor(private employeeService: EmployeeService) {}

  getAllEmployee() {
    this.subscription.add(
      this.employeeService.getAllEmployess().subscribe({
        next: (res) => {
          console.log(res);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        },
      })
    );
  }
}
