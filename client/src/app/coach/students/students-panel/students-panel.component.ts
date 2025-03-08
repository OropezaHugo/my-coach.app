import {Component, inject, OnInit} from '@angular/core';
import {UserService} from '../../../services/user.service';
import {UserModel} from '../../../models/user.models';
import {StudentCardComponent} from '../student-card/student-card.component';

@Component({
  selector: 'app-students-panel',
  imports: [
    StudentCardComponent
  ],
  templateUrl: './students-panel.component.html',
  styleUrl: './students-panel.component.scss'
})
export class StudentsPanelComponent implements OnInit {

  userService = inject(UserService)
  students: UserModel[] = []
  coaches: UserModel[] = []
  ngOnInit() {
    this.userService.getStudents().subscribe({
      next: data => {
        this.students = data
      }
    })
    this.userService.getCoaches().subscribe({
      next: data => {
        this.coaches = data
      }
    })
  }
}
