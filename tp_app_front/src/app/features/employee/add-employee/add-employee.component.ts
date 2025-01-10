import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css',
})
export class AddEmployeeComponent {
  addEmployeeForm = this.fb.group({
    firstName: [''],
    lastName: [''],
    isActive: [true],
  });

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<AddEmployeeComponent>
  ) {}

  onSubmit() {
    this.dialogRef.close(this.addEmployeeForm.value);
  }
}
