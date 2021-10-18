import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AdministrationService } from 'src/app/services/administration/administration.service';
import { StudentRole } from 'src/app/services/administration/administration.types';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import { CampusManagementService } from 'src/app/services/campus-management/campus-management.service';
import { Faculty } from 'src/app/services/campus-management/campus.types';
import { ResidenceManagementService } from 'src/app/services/residence-management/residence-management.service';
import { Residence } from 'src/app/services/residence-management/residence-management.types';
import { GenericNameAndIdType } from 'src/app/services/shared/shared.types';

@Component({
  selector: 'app-student-roles',
  templateUrl: './student-roles.component.html',
  styleUrls: ['./student-roles.component.css']
})
export class StudentRolesComponent implements OnInit {
  addForm: FormGroup;
  isAddModalVisible: boolean;

  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;

  isDeleteModalVisible: boolean;

  tableDataReady: boolean = false;
  loggedInUser: CurrentUser;
  itemToDelete: Faculty;

  listOfData: StudentRole[] = [];
  listOfDisplayData: StudentRole[] = [];

  listOfResidences: Residence[] = [];


  //Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: StudentRole) => item.name.indexOf(this.searchValue) !== -1);
  }

  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _campusManagementService: CampusManagementService,
    private _residenceManagementService:ResidenceManagementService,
    private _administrationService:AdministrationService
  ) {
    this.getUserDetails();
    this.getAllRecords();
  }

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
      Name: ['', [Validators.required]],
      ResidenceId: ['', [Validators.required]],
    });
  }
  onAddSubmit(): void {
    if (this.addForm.valid) {

      this._administrationService.addStudentRole(this.addForm.value, this.loggedInUser.UserName)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelAdd();
            this.tableDataReady = true;
            this._nzNotificationService.success("Add Success", "New record Added");

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Add Error', error.error.message);
          })
    }
  }

  //Update Operations
  onShowUpdateModal(element: StudentRole): void {
    this.buildUpdateForm(element);
    this.isUpdateModalVisisble = true;
  }
  onCancelUpdate(): void {
    this.isUpdateModalVisisble = false;
  }
  private buildUpdateFormWithEmptyFields() {
    this.updateForm = this.fb.group({
      Name: ['', [Validators.required]],
      ResidenceId: ['', [Validators.required]],
      Id: ['']
    });
  }
  private buildUpdateForm(element: StudentRole) {
    this.updateForm = this.fb.group({
      Name: [element.name, [Validators.required]],
      ResidenceId: [element.residenceId, [Validators.required]],
      Id: [element.id]
    });
  }
  onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      let updateId = this.updateForm.get('Id').value as number;
      this._administrationService.updateStudentRole(this.updateForm.value, this.loggedInUser.UserName, updateId)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelUpdate();
            this.tableDataReady = true;
            this._nzNotificationService.success("Update Success", "Record Updated");
          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Update  Error', error.error.message);
          })
    }
  }

  //Delete Oprations
  onShowDeleteModal(item: Faculty): void {
    this.isDeleteModalVisible = true;
    this.itemToDelete = item;
  }
  onDeleteSubmit(): void {
    this.isDeleteModalVisible = false;
    if (this.itemToDelete != null) {
      this._administrationService.deleteStudentRole(this.loggedInUser.UserName, this.itemToDelete.id)
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
    this._administrationService.getAllStudentRoles()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.getAllLookupsFromServer();
          this.listOfData = event.body as StudentRole[];
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

  private getAllResidences() {
    this._residenceManagementService.getAllResidences()
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
          this._nzNotificationService.error('Get Residences Error', error.error.message);
        })

  }

  private getAllLookupsFromServer() {
    this.getAllResidences();
  }
}
