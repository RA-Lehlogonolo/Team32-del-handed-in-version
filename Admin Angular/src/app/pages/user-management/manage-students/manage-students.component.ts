import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import { CampusManagementService } from 'src/app/services/campus-management/campus-management.service';
import { Faculty } from 'src/app/services/campus-management/campus.types';
import { ResidenceManagementService } from 'src/app/services/residence-management/residence-management.service';
import { Residence } from 'src/app/services/residence-management/residence-management.types';
import { UserManagementService } from 'src/app/services/users-management/user-management.service';
import { HouseParent, Student } from 'src/app/services/users-management/users-management.types';

export interface LevelOfStudy {
  label: string;
  value: string;
}

export interface Gender {
  label: string;
  value: string;
}
export interface AssignedToRoom {
  label: string;
  value: string;
}


@Component({
  selector: 'app-manage-students',
  templateUrl: './manage-students.component.html',
  styleUrls: ['./manage-students.component.css']
})
export class ManageStudentsComponent implements OnInit {
  addForm: FormGroup;
  isAddModalVisible: boolean;

  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;

  isDeleteModalVisible: boolean;

  tableDataReady: boolean = false;
  addFormDone: boolean = true;
  loggedInUser: CurrentUser;
  itemToDelete: Residence;

  listOfData: Student[] = [];
  listOfDisplayData: Student[] = [];

  listOfResidences: Residence[] = [];
  listOfFaculties: Faculty[] = [];


  listOfLevelOfStudies: LevelOfStudy[] = [
    { label: "Undergrad - 1", value: "Undergrad - 1" },
    { label: "Undergrad - 2", value: "Undergrad - 2" },
    { label: "Undergrad - 3", value: "Undergrad - 3" },
    { label: "Undergrad - 4", value: "Undergrad - 4" },
    { label: "Undergrad - 5", value: "Undergrad - 5" },
    { label: "Undergrad - 6", value: "Undergrad - 6" },
    { label: "Honours", value: "Honours" },
    { label: "PostGrad: Masters", value: "PostGrad: Masters" },
    { label: "PostGrad: PhD", value: "PostGrad: PhD" },
  ]

  listOfGenders: Gender[] = [
    { label: "Male", value: "Male" },
    { label: "Female", value: "Female" },
  ]

  listOfAssignedToRoom: AssignedToRoom[] = [
    { label: "false", value: "false" },
  
  ]
  


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
    this.listOfDisplayData = this.listOfData.filter((item: Student) => item.studentNumber.indexOf(this.searchValue) !== -1);
  }

  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _residenceManagementSerice: ResidenceManagementService,
    private _campusManagementService: CampusManagementService,
    private _userManagementService: UserManagementService
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
      StudentNumber: ['', [Validators.required]],
      Name: ['', [Validators.required]],
      Surname: ['', [Validators.required]],
      EmailAddress: ['', [Validators.required]],
      PhoneNumber: ['', [Validators.required]],
      ResidenceId: ['', [Validators.required]],
      FacultyId: ['', [Validators.required]],
      LevelOfStudy: ['', [Validators.required]],
      Gender: ['', [Validators.required]],
      AssignedToRoom: ['', [Validators.required]],
    });
  }
  onAddSubmit(): void {
    let providedUsername = this.addForm.get("StudentNumber").value as string;
    let formatedEmailFromStudentNumber = providedUsername + "@tuks.co.za";
    this.addForm.controls["EmailAddress"].setValue(formatedEmailFromStudentNumber);

    if (this.addForm.valid) {

      this._userManagementService.addIndividualStudent(this.addForm.value, this.loggedInUser.UserName)
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
            

            this._nzNotificationService.success("Add Success", "New Campus Added");

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
    this._userManagementService.getAllStudents()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.getAllLookupsFromServer();
          this.listOfData = event.body as Student[];
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

  onResendAccountCreatedNotification(element: Student) {
    // this._userManagementService.resendHouseParentAccountCreatedNotification(element.id)
    //   .subscribe(event => {
    //     if (event.type === HttpEventType.Sent) {
    //       this.tableDataReady = false;
    //     }
    //     if (event.type === HttpEventType.Response) {
    //       this.getAllLookupsFromServer();
    //       this._nzNotificationService.success('Sent Success', "Notification Sent Successfuly");
    //     }
    //   },
    //     error => {
    //       this.tableDataReady = true;
    //       this._nzNotificationService.error('Get Records Error', error.error.message);
    //     })
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
          this._nzNotificationService.error('Get Residences Error', error.error.message);
        })

  }
  private getAllFaculties() {
    this._campusManagementService.getAllFaculties()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.listOfFaculties = event.body as Faculty[];
          this.tableDataReady = true;
        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Faculties Error', error.error.message);
        })

  }
  private getAllLookupsFromServer() {
    this.getAllResidences();
    this.getAllFaculties();
  }

}
