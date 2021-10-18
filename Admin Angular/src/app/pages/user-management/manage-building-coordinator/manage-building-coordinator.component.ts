import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AdministrationService } from 'src/app/services/administration/administration.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import { ResidenceManagementService } from 'src/app/services/residence-management/residence-management.service';
import { Residence } from 'src/app/services/residence-management/residence-management.types';
import { GenericNameAndIdType } from 'src/app/services/shared/shared.types';
import { UserManagementService } from 'src/app/services/users-management/user-management.service';
import { BuildingCoordinator } from 'src/app/services/users-management/users-management.types';
@Component({
  selector: 'app-manage-building-coordinator',
  templateUrl: './manage-building-coordinator.component.html',
  styleUrls: ['./manage-building-coordinator.component.css']
})
export class ManageBuildingCoordinatorComponent implements OnInit {

  addForm: FormGroup;
  isAddModalVisible: boolean;

  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;

  isDeleteModalVisible: boolean;

  tableDataReady: boolean = false;
  addFormDone: boolean = true;
  loggedInUser: CurrentUser;
  itemToDelete: Residence;

  listOfData: BuildingCoordinator[] = [];
  listOfDisplayData: BuildingCoordinator[] = [];

  listOfResidences: Residence[] = [];

  selectedCampus;
  selectedResidenceType;

 //Search Operations
 searchValue = '';
 visible = false;
 reset(): void {
   this.searchValue = '';
   this.search();
 }
 search(): void {
   this.visible = false;
   this.listOfDisplayData = this.listOfData.filter((item: BuildingCoordinator) => item.username.indexOf(this.searchValue) !== -1);
 }


  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _residenceManagementSerice: ResidenceManagementService,
    private _userManagementService:UserManagementService
  ) {
     this.getUserDetails();
    this.getAllRecords(); }

  ngOnInit(): void {
    this.buildAddForm();
    this.buildUpdateFormWithEmptyFields();
  }
  //Add Operations
  onShowAddModal(): void {
    this.isAddModalVisible = true;
  }
  onCancelAdd(): void {
    this.isAddModalVisible = false;
  }
  private buildAddForm() {
    this.addForm = this.fb.group({
      Username: ['', [Validators.required]],
      Name: ['', [Validators.required]],
      Surname: ['', [Validators.required]],
      EmailAddress: ['', [Validators.required]],
      PhoneNumber: ['', [Validators.required]],
      ResidenceId: ['', [Validators.required]],
    });
  }


  onAddSubmit(): void {
    if (this.addForm.valid) {

      this._userManagementService.addBuildingCoordinator(this.addForm.value, this.loggedInUser.UserName)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
            this.addFormDone = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelAdd();
            this.tableDataReady = true;
            this.addFormDone = true;

            this._nzNotificationService.success("Add Success", "New BuildingCoordinator Added");

          }
        },
          error => {
            this.tableDataReady = true;
            this.addFormDone = true;
            this._nzNotificationService.error('Add Error', error.error.message);
          })
    }
  }

   //Update Operations
   onShowUpdateModal(element: Residence): void {
    this.buildUpdateForm(element);
    this.isUpdateModalVisisble = true;
  }
  onCancelUpdate(): void {
    this.isUpdateModalVisisble = false;
  }
  private buildUpdateFormWithEmptyFields() {
    this.updateForm = this.fb.group({
      Name: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      Id: ['']

    });
  }
  private buildUpdateForm(role: Residence) {
    this.updateForm = this.fb.group({
      Name: [role.name, [Validators.required]],
      Id: [role.id]
    });
  }

  onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      let updateId = this.updateForm.get('Id').value as number;
      this._residenceManagementSerice.updateResidence(this.updateForm.value, this.loggedInUser.UserName, updateId)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelUpdate();
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
  onShowDeleteModal(item: Residence): void {
    this.isDeleteModalVisible = true;
    this.itemToDelete = item;
  }

  onDeleteSubmit(): void {
    this.isDeleteModalVisible = false;
    if (this.itemToDelete != null) {
      this._residenceManagementSerice.deleteResidence(this.loggedInUser.UserName, this.itemToDelete.id)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {

            this.getAllRecords();
            this._nzNotificationService.success('Delete Sucess', "Delete Record");

            this.tableDataReady = true;

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Delete Error', error.error.message);
          })
    }


  }

  onCalcenDelete(): void {
    this.isDeleteModalVisible = false;
  }
  //Get & Helper Operations
  private getAllRecords() {
    this._userManagementService.getAllBuildingCoordinators()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.getAllLookupsFromServer();
          this.listOfData = event.body as BuildingCoordinator[];
          this.listOfDisplayData = [...this.listOfData];
          this.tableDataReady = true;

        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Records Error', error.error.message);
        })

  }
  private getUserDetails() {
    this.loggedInUser = this._authService.currentUser;
  }

  onResendAccountCreatedNotification(element:BuildingCoordinator){
    this._userManagementService.resendBuildingCoordinatorAccountCreatedNotification(element.id)
    .subscribe(event => {
      if (event.type === HttpEventType.Sent) {
        this.tableDataReady = false;
      }
      if (event.type === HttpEventType.Response) {
        this.getAllLookupsFromServer();
        this._nzNotificationService.success('Sent Success', "Notification Sent Successfuly");
      }
    },
      error => {
        this.tableDataReady = true;
        this._nzNotificationService.error('Get Records Error', error.error.message);
      })
  }
  private getAllResidences() {
    this._residenceManagementSerice.getAllResidences()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.listOfResidences = event.body as Residence[];
          this.tableDataReady = true;
        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Campuses Error', error.error.message);
        })

  }
  private getAllLookupsFromServer() {
    this.getAllResidences();
  }


}
