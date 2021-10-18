import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import { CampusManagementService } from 'src/app/services/campus-management/campus-management.service';
import { Faculty } from 'src/app/services/campus-management/campus.types';
import { GenericNameAndIdType } from 'src/app/services/shared/shared.types';

@Component({
  selector: 'app-faculties',
  templateUrl: './faculties.component.html',
  styleUrls: ['./faculties.component.css']
})
export class FacultiesComponent implements OnInit {
  addForm: FormGroup;
  isAddModalVisible: boolean;

  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;

  isDeleteModalVisible: boolean;

  tableDataReady: boolean = false;
  loggedInUser: CurrentUser;
  itemToDelete: Faculty;

  listOfData: Faculty[] = [];
  listOfDisplayData: Faculty[] = [];

  listOfCampuses: GenericNameAndIdType[] = [];


  //Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: Faculty) => item.name.indexOf(this.searchValue) !== -1);
  }

  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _campusManagementService: CampusManagementService
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
      CampusId: ['', [Validators.required]],
    });
  }
  onAddSubmit(): void {
    if (this.addForm.valid) {

      this._campusManagementService.addFaculty(this.addForm.value, this.loggedInUser.UserName)
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
  onShowUpdateModal(element: Faculty): void {
    this.buildUpdateForm(element);
    this.isUpdateModalVisisble = true;
  }
  onCancelUpdate(): void {
    this.isUpdateModalVisisble = false;
  }
  private buildUpdateFormWithEmptyFields() {
    this.updateForm = this.fb.group({
      Name: ['', [Validators.required]],
      CampusId: ['', [Validators.required]],
      Id: ['']

    });
  }
  private buildUpdateForm(element: Faculty) {
    this.updateForm = this.fb.group({
      Name: [element.name, [Validators.required]],
      CampusId: [element.campusId, [Validators.required]],
      Id: [element.id]
    });
  }
  onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      let updateId = this.updateForm.get('Id').value as number;
      this._campusManagementService.updateFaculty(this.updateForm.value, this.loggedInUser.UserName, updateId)
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
      this._campusManagementService.deleteFaculty(this.loggedInUser.UserName, this.itemToDelete.id)
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
    this._campusManagementService.getAllFaculties()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.getAllLookupsFromServer();
          this.listOfData = event.body as Faculty[];
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

  private getAllCampuses() {
    this._campusManagementService.getAllCampuses()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.listOfCampuses = event.body as GenericNameAndIdType[];
          this.tableDataReady = true;
        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Campuses Error', error.error.message);
        })

  }

  private getAllLookupsFromServer() {
    this.getAllCampuses();
  }
}
