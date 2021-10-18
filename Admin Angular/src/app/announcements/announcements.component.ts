import { Component, OnInit } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import { AnnouncementService } from 'src/app/services/announcement/announcement.service';
import { AdministrationService } from 'src/app/services/administration/administration.service';
import { GenericNameAndIdType} from 'src/app/services/shared/shared.types';
import { UserManagementService } from 'src/app/services/users-management/user-management.service';

import { Announcement } from 'src/app/services/announcement/announcement.types';
import { Residence } from '../services/residence-management/residence-management.types';
@Component({
  selector: 'app-announcements',
  templateUrl: './announcements.component.html',
  styleUrls: ['./announcements.component.css']
})
export class AnnouncementsComponent implements OnInit {

 addForm: FormGroup;
  isAddModalVisible: boolean;


  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;



  isDeleteModalVisible: boolean;

  tableDataReady: boolean = false;
  loggedInUser: CurrentUser;
  itemToDelete: Announcement;

  listOfData: Announcement[] = [];
  listOfDisplayData: Announcement [] = [];

  listOfAnnouncementTypes: GenericNameAndIdType[] = [];

  listOfResidences:Residence
  selectedResidence;

  selectedAnnouncementType;


 //Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: Announcement) => item.announcementtype.indexOf(this.searchValue) !== -1);
  }


  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
     private _authService: AuthService,
     private _announcementService: AnnouncementService,
       private _userServiceManagementService: UserManagementService

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
      Description: ['', [Validators.required]],
       AnnouncementTypeId: ['', [Validators.required]],
       ResidenceId: ['', [Validators.required]],
       Date: ['', [Validators.required]],
    });
  }
onAddSubmit(): void {
    if (this.addForm.valid) {

      this._announcementService.addAnnouncement(this.addForm.value, this.loggedInUser.UserName)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelAdd();
            this.tableDataReady = true;
            this._nzNotificationService.success("Add Success", "New Announcement Added");

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Add Announcement Error', error.error.message);
          })
    }
  }

  //Update Operations
  onShowUpdateModal(element: Announcement): void {
    this.buildUpdateForm(element);
    this.isUpdateModalVisisble = true;
  }
  onCancelUpdate(): void {
    this.isUpdateModalVisisble = false;
  }
  private buildUpdateFormWithEmptyFields() {
    this.updateForm = this.fb.group({
     /* Name: ['', [Validators.required]],*/
      Description: ['', [Validators.required]],
      Id: ['']

    });
  }

  private buildUpdateForm(role: Announcement) {
    this.updateForm = this.fb.group({
     /* Name: [role.name, [Validators.required]],*/

      Id: [role.id]
    });
  }

  onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      let updateId = this.updateForm.get('Id').value as number;
      this._announcementService.updateAnnouncement(this.updateForm.value, this.loggedInUser.UserName, updateId)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelUpdate();
            this.tableDataReady = true;
            this._nzNotificationService.success("Update Success", "Announcement Updated");
          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Update Announcement Error', error.error.message);
          })
    }
  }

   //Delete Oprations
  onShowDeleteModal(item: Announcement): void {
    this.isDeleteModalVisible = true;
    this.itemToDelete = item;
  }

   onDeleteSubmit(): void {
    this.isDeleteModalVisible = false;
    if (this.itemToDelete != null) {
      this._announcementService.deleteAnnouncement(this.loggedInUser.UserName, this.itemToDelete.id)
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
    this._announcementService.getAllAnnouncements()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.getAllLookupsFromServer();
          this.listOfData = event.body as Announcement[];
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
   private getAllAnnouncementTypes() {
    this._announcementService.getAllAnnouncementTypes()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.listOfAnnouncementTypes = event.body as GenericNameAndIdType[];
          this.tableDataReady = true;
        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Announcement Type Error', error.error.message);
        })

  }
private getAllLookupsFromServer() {

    this.getAllAnnouncementTypes();
  }

}
