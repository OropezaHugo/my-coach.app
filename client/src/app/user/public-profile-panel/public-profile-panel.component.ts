import {Component, inject, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserModel} from '../../models/user.models';
import {PublicProfileComponent} from '../public-profile/public-profile.component';
import {FormControl, ReactiveFormsModule} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';

@Component({
  selector: 'app-public-profile-panel',
  imports: [
    PublicProfileComponent,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule
  ],
  templateUrl: './public-profile-panel.component.html',
  styleUrl: './public-profile-panel.component.scss'
})
export class PublicProfilePanelComponent implements OnInit{
  userService = inject(UserService)
  users: UserModel[] = []
  filteredUsers: UserModel[] = []
  filetByNameForm = new FormControl<string>('')
  ngOnInit() {
    this.userService.getStudents().subscribe({
      next: data => {
        this.users = data
        this.filterUsers()
      }
    })
  }

  filterUsers() {
    if (this.filetByNameForm.value !== undefined && this.filetByNameForm.value !== null) {
      this.filteredUsers = this.users.filter(user => user.name.toLowerCase().trim().includes(this.filetByNameForm.value!.toLowerCase().trim()))
    }
  }
}
