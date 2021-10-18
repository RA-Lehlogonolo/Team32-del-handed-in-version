import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AdministrationService } from 'src/app/services/administration/administration.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import { CampusManagementService } from 'src/app/services/campus-management/campus-management.service';
import { ResidenceManagementService } from 'src/app/services/residence-management/residence-management.service';
import { Residence } from 'src/app/services/residence-management/residence-management.types';
import { GenericNameAndIdType, UploadFinishedEventArgs } from 'src/app/services/shared/shared.types';
import { UserManagementService } from 'src/app/services/users-management/user-management.service';

@Component({
  selector: 'app-residences',
  templateUrl: './residences.component.html',
  styleUrls: ['./residences.component.css']
})
export class ResidencesComponent implements OnInit {
  addForm: FormGroup;
  isAddModalVisible: boolean;


  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;



  isDeleteModalVisible: boolean;

  tableDataReady = false;
  loggedInUser: CurrentUser;
  itemToDelete: Residence;

  listOfData: Residence[] = [];
  listOfDisplayData: Residence[] = [];

  listOfCampuses: GenericNameAndIdType[] = [];
  listOfResidenceTypes: GenericNameAndIdType[] = [];

  selectedCampus;
  selectedResidenceType;

  // For Upload via CSV
  form: FormGroup;
  isUploadModelVisible: boolean;

  incorrectTypeErrorMessage = null;
  progress;
  showProgress = false;

  fileUrl = '';

  selectedfile: File;
  selectedResidenceDuringUpload: Residence;
  uploadUrlFromServer: UploadFinishedEventArgs;
  fileToUpload: File = null;

  isUploadReady = false;


  // Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: Residence) => item.name.indexOf(this.searchValue) !== -1);
  }

  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _residenceManagementSerice: ResidenceManagementService,
    private _campusManagementService: CampusManagementService,
    private _userServiceManagementService: UserManagementService
  ) {
    this.getUserDetails();
    this.getAllRecords();
  }

  ngOnInit(): void {
    this.buildAddForm();
    this.buildUpdateFormWithEmptyFields();
    this.buildUploadForm(this.fb);
  }

  // Add Operations
  onShowAddModal(): void {
    this.isAddModalVisible = true;
  }
  onCancelAdd(): void {
    this.isAddModalVisible = false;
  }
  private buildAddForm() {
    this.addForm = this.fb.group({
      Name: ['', [Validators.required]],
      Address: ['', [Validators.required]],
      CampusId: ['', [Validators.required]],
      ResidenceTypeId: ['', [Validators.required]],
    });
  }
  onAddSubmit(): void {
    if (this.addForm.valid) {

      this._residenceManagementSerice.addResidence(this.addForm.value, this.loggedInUser.UserName)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelAdd();
            this.tableDataReady = true;
            this._nzNotificationService.success('Add Success', 'New Campus Added');

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Add Error', error.error.message);
          });
    }
  }

  // Update Operations
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
      Address: ['', [Validators.required]],
      CampusId: ['', [Validators.required]],
      ResidenceTypeId: ['', [Validators.required]],
      Id: [role.id]
    });
  }
  onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      const updateId = this.updateForm.get('Id').value as number;
      this._residenceManagementSerice.updateResidence(this.updateForm.value, this.loggedInUser.UserName, updateId)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelUpdate();
            this.tableDataReady = true;
            this._nzNotificationService.success('Update Success', 'Residence Updated');
          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Update Residence Error', error.error.message);
          });
    }
  }

  // Delete Oprations
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
            this._nzNotificationService.success('Delete Sucess', 'Delete Record');

            this.tableDataReady = true;

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Delete Error', error.error.message);
          });
    }


  }
  onCalcenDelete(): void {
    this.isDeleteModalVisible = false;
  }

  // Get & Helper Operations
  private getAllRecords() {
    this._residenceManagementSerice.getAllResidences()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.getAllLookupsFromServer();
          this.listOfData = event.body as Residence[];
          this.listOfDisplayData = [...this.listOfData];
          this.tableDataReady = true;

        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Records Error', error.error.message);
        });

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
        });

  }
  private getAllResidenceTypes() {
    this._residenceManagementSerice.getAllResidenceTypes()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.listOfResidenceTypes = event.body as GenericNameAndIdType[];
          this.tableDataReady = true;
        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Campuses Error', error.error.message);
        });

  }
  private getAllLookupsFromServer() {
    this.getAllCampuses();
    this.getAllResidenceTypes();
  }

  // Upload Students via CSV
  onShowUploadModal( residence: Residence): void {
    this.selectedResidenceDuringUpload = residence;
    this.isUploadModelVisible = true;
  }

  onCancelUpload(): void {
    this.isUploadModelVisible = false;
  }
  onSubmitUpload() {
    if (this.uploadUrlFromServer) {
      this.FileUrl.setValue(this.uploadUrlFromServer.filePath);
      if (this.form.valid) {
        this._userServiceManagementService
          .addStudentsInCSV(this.form.value, this._authService.currentUser.UserName, this.selectedResidenceDuringUpload.id)
          .subscribe(event => {
            if (event.type === HttpEventType.Sent) {
              this.isUploadReady = true;
            }
            if (event.type === HttpEventType.Response) {
              this.isUploadReady = false;
              this._nzNotificationService.success('Success', 'All records added successfully');
              this.onCancelUpload();
            }
          },
            error => {
              this.isUploadReady = false;
              this._nzNotificationService.error('Upload Error', error.error.message);
            });
      }
    }
    else {
      // this.openErrorMessageSnackBar("Error: Upload members list file.");
    }
  }
  addFile(element: Event, ) {
    const elementTarget = element.target as HTMLInputElement;
    const file = elementTarget.files.item(0);

    this.incorrectTypeErrorMessage = null;
    const acceptedfileTypes = ['.csv', 'application/vnd.ms-excel'];
    const maxUploadSize = 1073741824; // 1GB

    if (file.name === null) {
      return;
    }

    if (file.size > maxUploadSize) {
      this.incorrectTypeErrorMessage = 'File too big. File should be less than 1GB';
      return;
    }
    if (!acceptedfileTypes.includes(file.type)) {
      this.incorrectTypeErrorMessage = 'File type not accepted. Upload an file with [.csv] extensions';
      return;
    }

    // Show file preview
    let reader = new FileReader();
    reader.onload = (event: any) => {
      // this.showFileBackground(event.target.result)
    };
    reader.readAsDataURL(file);

    this.selectedfile = file;
    this.sendFileToServer();
  }

  private sendFileToServer() {
    const fileToUpload: File = this.selectedfile;

    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this._userServiceManagementService.uploadStudentsCSV(formData)
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
          this.showProgress = true;
        }

        else if (event.type === HttpEventType.Response) {
          this.showProgress = false;
          this.uploadUrlFromServer = event.body as UploadFinishedEventArgs;
        }
      },
        error => {
          this.showProgress = false;
          this._nzNotificationService.error('Upload Error', error.error.message);
        }
      );
  }

  private buildUploadForm(_formBuilder: FormBuilder) {
    this.form = _formBuilder.group({
      FileUrl: [''],
    });
  }

  get FileUrl() {
    return this.form.get('FileUrl');
  }
}
