import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {TrainingPlanRoutineContent} from '../../../models/training-plan.models';
import {UserModel} from '../../../models/user.models';
import {UserService} from '../../../services/user.service';
import {MatFormField, MatLabel, MatSuffix} from '@angular/material/form-field';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatInput} from '@angular/material/input';
import {MatDatepicker, MatDatepickerInput, MatDatepickerToggle} from '@angular/material/datepicker';
import {MatButton} from '@angular/material/button';
import {MAT_DATE_FORMATS, MAT_NATIVE_DATE_FORMATS, provideNativeDateAdapter} from '@angular/material/core';

@Component({
  selector: 'app-edit-user-profile-dialog',
  imports: [
    MatSuffix,
    MatButton,
    MatInput,
    MatDatepickerToggle,
    MatDatepicker,
    ReactiveFormsModule,
    MatDatepickerInput,
    MatLabel,
    MatFormField,
    MatDialogActions,
    MatDialogContent
  ],
  providers: [
    provideNativeDateAdapter(),
    {provide: MAT_DATE_FORMATS, useValue: MAT_NATIVE_DATE_FORMATS},
  ],
  templateUrl: './edit-user-profile-dialog.component.html',
  styleUrl: './edit-user-profile-dialog.component.scss'
})
export class EditUserProfileDialogComponent {
  dialogRef = inject(MatDialogRef<EditUserProfileDialogComponent>);
  data = inject<UserModel>(MAT_DIALOG_DATA);
  userService = inject(UserService)
  currentYear = new Date().getFullYear();

  minDate = new Date(this.currentYear - 100, 0,1);
  maxDate = new Date(this.currentYear - 12, 0, 1);
  userDataForm = new FormGroup({
    userName: new FormControl<string>(this.data.name, [Validators.required]),
    userBirthDate: new FormControl<Date>(new Date(this.data.birthday +  'T00:00:00'), [Validators.required]),
  })

  updateUserData() {
    if (this.userDataForm.value.userName !== undefined
      && this.userDataForm.value.userName !== null
    && this.userDataForm.value.userBirthDate !== undefined
    && this.userDataForm.value.userBirthDate !== null) {
      this.userService.updateUserData(this.data.id, {
        name: this.userDataForm.value.userName,
        birthday: this.userDataForm.value.userBirthDate.toISOString().split('T')[0],
        email: this.data.email,
        roleId: this.data.roleId,
        avatarUrl: this.data.avatarUrl,
        password: this.data.password
      }).subscribe({
        next: data => {
          this.dialogRef.close();
        }
      })
    }
  }
}
