import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-maintenancerequest-type',
  templateUrl: './maintenancerequest-type.component.html',
  styleUrls: ['./maintenancerequest-type.component.css']
})
export class MaintenancerequestTypeComponent implements OnInit {
  validateForm: any;
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
      campus: [null, [Validators.required]],


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
    this.notification.create('success','','Successfully deleted maintenance request type!',
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
    this.notification.create('success','','Successfully updated maintenance request type!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isUpdateUserVisible = false;


  }

  confirmAdd(): void {
    this.notification.create('success','','Successfully added maintenance request type!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isAddUserVisible = false;

  }

  listOfData: any[] = [
    {
      role: "Electrical",
    },
    {

      role: "Plumbing",

    },


  ];
}
