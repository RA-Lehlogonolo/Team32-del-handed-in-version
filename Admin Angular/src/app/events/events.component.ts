import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AdministrationService } from 'src/app/services/administration/administration.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import {Events} from 'src/app/services/event/events';
import { GenericNameAndIdType, UploadFinishedEventArgs } from 'src/app/services/shared/shared.types';
import { UserManagementService } from 'src/app/services/users-management/user-management.service';

import {EventService} from 'src/app/services/event/event.service';
@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  addForm: FormGroup;
  isAddModalVisible: boolean;

  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;

  isDeleteModalVisible: boolean;

  tableDataReady = false;
  loggedInUser: CurrentUser;
  itemToDelete: Events;

  listOfData:Events[] = [];
  listOfDisplayData: Events[] = [];
  listOfEventTypes:GenericNameAndIdType[] = [];
  selectedEventType;

  //Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: Events) => item.name.indexOf(this.searchValue) !== -1);
  }

  constructor(
   private fb: FormBuilder,
   private _nzNotificationService: NzNotificationService,
   private _authService: AuthService,
      private _EventService: EventService,
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
     Name: ['', [Validators.required]],
      Location: ['', [Validators.required]],
       Date: ['', [Validators.required]],
      StartTime: ['', [Validators.required]],
      EndTime: ['', [Validators.required]],
       eventTypeId: ['', [Validators.required]],
    });
  }

  onAddSubmit(): void {
    if (this.addForm.valid) {

      this._EventService.addEvent(this.addForm.value, this.loggedInUser.UserName)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelAdd();
            this.tableDataReady = true;
            this._nzNotificationService.success("Add Success", "New Event Added");

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Add Error', error.error.message);
          })
    }
  }

 //Update Operations
  onShowUpdateModal(element: Events): void {
    this.buildUpdateForm(element);
    this.isUpdateModalVisisble = true;
  }
  onCancelUpdate(): void {
    this.isUpdateModalVisisble = false;
  }

   private buildUpdateFormWithEmptyFields() {
    this.updateForm = this.fb.group({
      Name: ['', [Validators.required]],
      Location: ['', [Validators.required]],
       Date: ['', [Validators.required]],
      StartTime: ['', [Validators.required]],
      EndTime: ['', [Validators.required]],
      Id: ['']

    });
  }

  private buildUpdateForm(role: Events) {
    this.updateForm = this.fb.group({
      Name: [role.name, [Validators.required]],
      Location: [role.location, [Validators.required]],
      Date: [role.date, [Validators.required]],
      StartTime: [role.starttime, [Validators.required]],
      EndTime: [role.endtime, [Validators.required]],
      Id: [role.id]
    });
  }
   onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      let updateId = this.updateForm.get('Id').value as number;
      this._EventService.updateEvent(this.updateForm.value, this.loggedInUser.UserName, updateId)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelUpdate();
            this.tableDataReady = true;
            this._nzNotificationService.success("Update Success", "Event Updated");
          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Update Event Error', error.error.message);
          })
    }
  }

    //Delete Oprations
  onShowDeleteModal(item: Events): void {
    this.isDeleteModalVisible = true;
    this.itemToDelete = item;
  }
  onDeleteSubmit(): void {
    this.isDeleteModalVisible = false;
    if (this.itemToDelete != null) {
      this._EventService.deleteEvent(this.loggedInUser.UserName, this.itemToDelete.id)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {

            this.getAllRecords();
            this._nzNotificationService.success('Delete Success', "Delete Record");

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
    this._EventService.getAllEvents()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.getAllLookupsFromServer();
          this.listOfData = event.body as Events[];
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
  private getAllEventTypes() {
    this._EventService.getAllEventTypes()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.listOfEventTypes = event.body as GenericNameAndIdType[];
          this.tableDataReady = true;
        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Event Error', error.error.message);
        })

  }

  private getAllLookupsFromServer() {

    this.getAllEventTypes();
  }


}
