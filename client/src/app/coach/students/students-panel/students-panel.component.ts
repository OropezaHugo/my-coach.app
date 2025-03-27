import {Component, inject, OnInit} from '@angular/core';
import {UserService} from '../../../services/user.service';
import {UserModel} from '../../../models/user.models';
import {StudentCardComponent} from '../student-card/student-card.component';
import {FormControl, FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';

@Component({
  selector: 'app-students-panel',
  imports: [
    StudentCardComponent,
    FormsModule,
    MatFormField,
    MatInput,
    MatLabel,
    ReactiveFormsModule
  ],
  templateUrl: './students-panel.component.html',
  styleUrl: './students-panel.component.scss'
})
export class StudentsPanelComponent implements OnInit {

  userService = inject(UserService)
  filteredStudents: UserModel[] = []
  filteredCoaches: UserModel[] = []
  students: UserModel[] = []
  coaches: UserModel[] = []

  filetByNameForm = new FormControl<string>('')
  ngOnInit() {
    this.userService.getStudents().subscribe({
      next: data => {
        this.students = data
        console.log(data)
        this.filterByName()
      }
    })
    this.userService.getCoaches().subscribe({
      next: data => {
        this.coaches = data
        this.filterByName()
      }
    })
  }

  filterByName() {
    if (this.filetByNameForm.value !== undefined && this.filetByNameForm.value !== null) {
      this.filteredStudents = this.students.filter(user => user.name.toLowerCase().trim().includes(this.filetByNameForm.value!.toLowerCase().trim()))
      this.filteredCoaches = this.coaches.filter(user => user.name.toLowerCase().trim().includes(this.filetByNameForm.value!.toLowerCase().trim()))
    }
  }

  filterByAge() {
    //TODO: filter by users age using their birthdate
  }
}
