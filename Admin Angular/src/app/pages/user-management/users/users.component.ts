import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  validateForm!: FormGroup;
  isAddUserVisible: boolean;
  isUpdateUserVisible: boolean;
  isDeleteUserVisible: boolean;


  constructor(
    private fb: FormBuilder,
    private notification: NzNotificationService,
    ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      description: [null, [Validators.required]],
      name: [null, [Validators.required]],
      aType: [null, [Validators.required]],
      username: [null, [Validators.required]],
      surname: [null, [Validators.required]],
      email: [null, [Validators.required]],


    });
  }

  showAddUserModal(): void {
    this.isAddUserVisible = true;

  }

  handleOkAddUser(): void {
    this.isAddUserVisible = false;


  }

  handleCancelAddUser(): void {
    this.isAddUserVisible = false;


  }

  showUpdateUserModal(): void {
    this.isUpdateUserVisible = true;
  }

  handleOkUpdateUser(): void {
    this.isUpdateUserVisible = false;
  }

  handleCancelUpdateUser(): void {
    this.isUpdateUserVisible = false;
  }

  showDeleteUserModal(): void {
    this.isDeleteUserVisible = true;
  }

  handleOkDeleteUser(): void {
    this.isDeleteUserVisible = false;
    this.notification.create('success','','Successfully deleted user!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );


  }
  handleCancelDeleteUser(): void {
    this.isDeleteUserVisible = false;
  }


  confirm(): void {
    this.notification.create('success','','Successfully updated user!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isUpdateUserVisible = false;


  }

  confirmAdd(): void {
    this.notification.create('success','','Successfully added user!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isAddUserVisible = false;


  }



  listOfData: any[] = [
    {
      fullName: "John Doe",
      email: "johndoe@gmail.com",
      username: "12345678",
      role:"Student",
    },
   {    
    fullName: "Jim Doe",
    email: "jimdoe@gmail.com",
    username: "12345333",
    role:"Student",
 
    },
   
  ];
}
