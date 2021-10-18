import { Component, OnInit } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AdministrationService } from 'src/app/services/administration/administration.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import { GenericNameAndIdType } from 'src/app/services/shared/shared.types';
import {EventService} from 'src/app/services/event/event.service'; ;

@Component({
  selector: 'app-event-type',
  templateUrl: './event-type.component.html',
  styleUrls: ['./event-type.component.css']
})
export class EventTypeComponent implements OnInit {

 addForm: FormGroup;
  isAddModalVisible: boolean;

  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;

  isDeleteModalVisible: boolean;

  tableDataReady = false;
  loggedInUser: CurrentUser;
  itemToDelete: GenericNameAndIdType;

  listOfData: GenericNameAndIdType[] = [];
  listOfDisplayData: GenericNameAndIdType[] = [];

  // Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: GenericNameAndIdType) => item.name.indexOf(this.searchValue) !== -1);
  }


  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _EventService: EventService
    ) {
      this.getUserDetails();
      this.getAllRecords();

     }

  ngOnInit(): void {
    this.buildAddForm();
    this.buildUpdateFormWithEmptyFields();

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
    });
  }

  onAddSubmit(): void {
    if (this.addForm.valid) {

      this._EventService.addEventType(this.addForm.value, this.loggedInUser.UserName)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelAdd();
            this.tableDataReady = true;
            this._nzNotificationService.success('Add Success', 'New Event Type Added');

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Add Error', error.error.message);
          });
    }
  }

 // Update Operations
  onShowUpdateModal(element: GenericNameAndIdType): void {
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

  private buildUpdateForm(role: GenericNameAndIdType) {
    this.updateForm = this.fb.group({
      Name: [role.name, [Validators.required]],
      Id: [role.id]
    });
  }
   onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      const updateId = this.updateForm.get('Id').value as number;
      this._EventService.updateEventType(this.updateForm.value, this.loggedInUser.UserName, updateId)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelUpdate();
            this.tableDataReady = true;
            this._nzNotificationService.success('Update Success', 'Event Type Updated');
          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Update Event Type Error', error.error.message);
          });
    }
  }

    // Delete Oprations
  onShowDeleteModal(item: GenericNameAndIdType): void {
    this.isDeleteModalVisible = true;
    this.itemToDelete = item;
  }
  onDeleteSubmit(): void {
    this.isDeleteModalVisible = false;
    if (this.itemToDelete != null) {
      this._EventService.deleteEventType(this.loggedInUser.UserName, this.itemToDelete.id)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {

            this.getAllRecords();
            this._nzNotificationService.success('Delete Success', 'Delete Record');

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
    this._EventService.getAllEventTypes()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {

          this.listOfData = event.body as GenericNameAndIdType[];
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



}
