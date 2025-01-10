import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Employee } from '../models/employee.interface';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css',
})
export class AddEmployeeComponent {
  addEmployeeForm = this.fb.group({
    id: [this.data?.id || null],
    firstName: [this.data?.firstName || ''],
    lastName: [this.data?.lastName || ''],
    isActive: [this.data?.isActive ?? true],
  });

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<AddEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Employee | null
  ) {}

  onSubmit() {
    this.dialogRef.close(this.addEmployeeForm.value);
  }
}
