import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AdministrationService } from 'src/app/services/administration/administration.service';
import { UserRole } from 'src/app/services/administration/administration.types';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';

@Component({
  selector: 'app-user-roles',
  templateUrl: './user-roles.component.html',
  styleUrls: ['./user-roles.component.css']
})
export class UserRolesComponent implements OnInit {
  addRoleForm: FormGroup;
  isAddRoleVisible: boolean;

  isUpdateUserRoleVisible: boolean;
  updateRoleForm: FormGroup;

  isDeleteUserRoleVisible: boolean;

  tableDataReady: boolean = false;
  loggedInUser: CurrentUser;
  userRoleToDelete: UserRole;

  listOfData: UserRole[] = [];
  listOfDisplayData: UserRole[] = [];

  //Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: UserRole) => item.name.indexOf(this.searchValue) !== -1);
  }

  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _administrationService: AdministrationService
  ) {
    this.getUserDetails();
    this.getAllRoles();
  }

  ngOnInit(): void {
    this.buildAddRoleForm();
    this.buildUpdateRoleFormWithEmptyFields();
  }

  //Add Operations
  onShowAddRoleModal(): void {
    this.isAddRoleVisible = true;
  }
  handleOkAddUser(): void {
    this.isAddRoleVisible = false;
  }
  onCancelAddRole(): void {
    this.isAddRoleVisible = false;
  }
  private buildAddRoleForm() {
    this.addRoleForm = this.fb.group({
      Name: ['', [Validators.required]],
      Description: ['', [Validators.required]]
    });
  }
  onAddUserRole(): void {
    if (this.addRoleForm.valid) {

      this._administrationService.addUserRole(this.addRoleForm.value, this.loggedInUser.UserName)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRoles();
            this.onCancelAddRole();
            this.tableDataReady = true;
            this._nzNotificationService.success("Add Success", "New User Role Added");

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Add User Role Error', error.error.message);
          })
    }
  }

  //Update Operations
  onOpenUpdateUserRoleModal(element: UserRole): void {
    this.buildUpdateRoleForm(element);
    this.isUpdateUserRoleVisible = true;
  }
  onCancelUserRoleUpdate(): void {
    this.isUpdateUserRoleVisible = false;
  }
  private buildUpdateRoleFormWithEmptyFields() {
    this.updateRoleForm = this.fb.group({
      Name: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      Id: ['']

    });
  }
  private buildUpdateRoleForm(role: UserRole) {
    this.updateRoleForm = this.fb.group({
      Name: [role.name, [Validators.required]],
      Description: [role.description, [Validators.required]],
      Id: [role.id]
    });
  }
  onUpdateUserRole(): void {
    if (this.updateRoleForm.valid) {
      let updateId = this.updateRoleForm.get('Id').value as string;
      this._administrationService.updateUserRole(this.updateRoleForm.value, this.loggedInUser.UserName, updateId)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRoles();
            this.onCancelUserRoleUpdate();
            this.tableDataReady = true;
            this._nzNotificationService.success("Update Success", "User Role Updated");
          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Update User Role Error', error.error.message);
          })
    }
  }

  //Delete Oprations
  onOpenDeleteUserRoleModal(item: UserRole): void {
    this.isDeleteUserRoleVisible = true;
    this.userRoleToDelete = item;
  }
  onDeleteUserRole(): void {
    this.isDeleteUserRoleVisible = false;
    if (this.userRoleToDelete != null) {
      this._administrationService.deletetUserRole(this.loggedInUser.UserName, this.userRoleToDelete.id)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {

            this.getAllRoles();
            this._nzNotificationService.success('Delete Sucess', "Delete User Role");

            this.tableDataReady = true;

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Delete User Roles Error', error.error.message);
          })
    }


  }
  onCancelDeleteUserRole(): void {
    this.isDeleteUserRoleVisible = false;
  }

  //Get & Helper Operations
  private getAllRoles() {
    this._administrationService.getAllUserRoles()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {

          this.listOfData = event.body as UserRole[];
          this.listOfDisplayData = [...this.listOfData];

          this.tableDataReady = true;

        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get User Roles Error', error.error.message);
        })

  }
  private getUserDetails() {
    this.loggedInUser = this._authService.currentUser;
  }

}
