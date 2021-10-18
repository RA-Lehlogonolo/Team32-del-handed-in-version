import { element } from 'protractor';
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
import { Block, Residence } from 'src/app/services/residence-management/residence-management.types';
import { GenericNameAndIdType, UploadFinishedEventArgs } from 'src/app/services/shared/shared.types';
import { UserManagementService } from 'src/app/services/users-management/user-management.service';



@Component({
  selector: 'app-block',
  templateUrl: './block.component.html',
  styleUrls: ['./block.component.css']
})
export class BlockComponent implements OnInit {
  addForm: FormGroup;
  isAddModalVisible: boolean;

  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;

  isDeleteModalVisible: boolean;

  tableDataReady: boolean = false;
  loggedInUser: CurrentUser;
  itemToDelete: Block;

  listOfData: Block[] = [];
  listOfDisplayData: Block[] = [];
  listOfResidences: Residence[] = [];

  
  //For Upload via CSV
  form: FormGroup;
  isUploadModelVisible: boolean

  incorrectTypeErrorMessage = null;
  progress;
  showProgress = false;

  fileUrl: string = "";

  selectedfile: File;
  selectedBlockDuringUpload: Block;
  uploadUrlFromServer: UploadFinishedEventArgs;
  fileToUpload: File = null;

  isUploadReady: boolean = false;
  
  //Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: Block) => item.name.indexOf(this.searchValue) !== -1);
  }


  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _residenceManagementService:ResidenceManagementService

  ) { 
    this.getUserDetails();
    this.getAllRecords();
  }

  ngOnInit(): void {
    this.buildAddForm();
    this.buildUpdateFormWithEmptyFields();
    this.buildUploadForm(this.fb);
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

      this._residenceManagementService.addBlock(this.addForm.value, this.loggedInUser.UserName)
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
  onShowUpdateModal(element: Block): void {
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
  private buildUpdateForm(element: Block) {
    this.updateForm = this.fb.group({
      Name: [element.name, [Validators.required]],
      ResidenceId: [element.residenceId, [Validators.required]],
      Id: [element.id]
    });
  }
  onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      let updateId = this.updateForm.get('Id').value as number;
      this._residenceManagementService.updateBlock(this.updateForm.value, this.loggedInUser.UserName, updateId)
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
  onShowDeleteModal(item: Block): void {
    this.isDeleteModalVisible = true;
    this.itemToDelete = item;
  }
  onDeleteSubmit(): void {
    this.isDeleteModalVisible = false;
    if (this.itemToDelete != null) {
      this._residenceManagementService.deleteBlock(this.loggedInUser.UserName, this.itemToDelete.id)
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
    this._residenceManagementService.getAllBlocks()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.getAllLookupsFromServer();
          this.listOfData = event.body as Block[];
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

   //Upload Rooms via CSV
   onShowUploadModal( block: Block): void {
    this.selectedBlockDuringUpload = block;
    this.isUploadModelVisible = true;
  }

  onCancelUpload(): void {
    this.isUploadModelVisible = false;
  }
  onSubmitUpload() {
    if (this.uploadUrlFromServer) {
      this.FileUrl.setValue(this.uploadUrlFromServer.filePath);
      if (this.form.valid) {
        this._residenceManagementService
          .addRoomsInCSV(this.form.value, this._authService.currentUser.UserName, this.selectedBlockDuringUpload.id)
          .subscribe(event => {
            if (event.type === HttpEventType.Sent) {
              this.isUploadReady = true;
            }
            if (event.type === HttpEventType.Response) {
              this.isUploadReady = false;
              this._nzNotificationService.success('Success', "All records added successfully");
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
  addFile(element: Event,) {
    const elementTarget = element.target as HTMLInputElement;
    const file = elementTarget.files.item(0);

    this.incorrectTypeErrorMessage = null;
    const acceptedfileTypes = ['.csv', 'application/vnd.ms-excel'];
    const maxUploadSize = 1073741824; //1GB

    if (file.name === null) {
      return;
    }

    if (file.size > maxUploadSize) {
      this.incorrectTypeErrorMessage = "File too big. File should be less than 1GB";
      return;
    }
    if (!acceptedfileTypes.includes(file.type)) {
      this.incorrectTypeErrorMessage = "File type not accepted. Upload an file with [.csv] extensions";
      return;
    }

    //Show file preview
    var reader = new FileReader();
    reader.onload = (event: any) => {
      // this.showFileBackground(event.target.result)
    }
    reader.readAsDataURL(file);

    this.selectedfile = file;
    this.sendFileToServer()
  }

  private sendFileToServer() {
    let fileToUpload: File = this.selectedfile;

    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this._residenceManagementService.uploadRoomsCSV(formData)
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
      FileUrl: [""],
    });
  }

  get FileUrl() {
    return this.form.get('FileUrl');
  }
}

