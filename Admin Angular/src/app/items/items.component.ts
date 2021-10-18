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
import { Item } from 'src/app/services/VillageFresh/village-fresh.types'
import { VillageFreshService } from 'src/app/services/VillageFresh/village-fresh.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {
 addForm: FormGroup;
  isAddModalVisible: boolean;
  

  isUpdateModalVisisble: boolean;
  updateForm: FormGroup;



  isDeleteModalVisible: boolean;

  tableDataReady: boolean = false;
  loggedInUser: CurrentUser;
  itemToDelete: Item;

  listOfData: Item [] = [];
  listOfDisplayData: Item [] = [];

  
  listOfItemTypes: GenericNameAndIdType [] = [];
  
  selectedItemType;

  //Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: Item) => item.name.indexOf(this.searchValue) !== -1);
  }

  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _VillageFreshService: VillageFreshService,
    private _userServiceManagementService: UserManagementService
    
    ) 
    {
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
      ItemTypeId: ['', [Validators.required]],
    });
  }
  onAddSubmit(): void {
    if (this.addForm.valid) {

      this._VillageFreshService.addItem(this.addForm.value, this.loggedInUser.UserName)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelAdd();
            this.tableDataReady = true;
            this._nzNotificationService.success("Add Success", "New Item Added");

          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Add Error', error.error.message);
          })
    }
  }
  
   //Update Operations
  onShowUpdateModal(element: Item): void {
    this.buildUpdateForm(element);
    this.isUpdateModalVisisble = true;
  }
  onCancelUpdate(): void {
    this.isUpdateModalVisisble = false;
  }
  private buildUpdateFormWithEmptyFields() {
    this.updateForm = this.fb.group({
      Name: ['', [Validators.required]],
      Id: ['']

    });
  }
  private buildUpdateForm(role: Item) {
    this.updateForm = this.fb.group({
      Name: [role.name, [Validators.required]],
      Id: [role.id]
    });
  }
  
   onUpdateSubmit(): void {
    if (this.updateForm.valid) {
      let updateId = this.updateForm.get('Id').value as number;
      this._VillageFreshService.updateItem(this.updateForm.value, this.loggedInUser.UserName, updateId)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
            this.tableDataReady = false;
          }
          if (event.type === HttpEventType.Response) {
            this.getAllRecords();
            this.onCancelUpdate();
            this.tableDataReady = true;
            this._nzNotificationService.success("Update Success", "Item Updated");
          }
        },
          error => {
            this.tableDataReady = true;
            this._nzNotificationService.error('Update Item Error', error.error.message);
          })
    }
  }
  //Delete Oprations
  onShowDeleteModal(item: Item): void {
    this.isDeleteModalVisible = true;
    this.itemToDelete = item;
  }
  
    onDeleteSubmit(): void {
    this.isDeleteModalVisible = false;
    if (this.itemToDelete != null) {
      this._VillageFreshService.deleteItem(this.loggedInUser.UserName, this.itemToDelete.id)
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
    this._VillageFreshService.getAllItems()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {

          this.listOfData = event.body as Item[];
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

   private getAllItemTypes() {
    this._VillageFreshService.getAllItemTypes()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {
          this.listOfItemTypes = event.body as GenericNameAndIdType[];
          this.tableDataReady = true;
        }
      },
        error => {
          this.tableDataReady = true;
          this._nzNotificationService.error('Get Item Type Error', error.error.message);
        })

  }
  
  private getAllLookupsFromServer() {
    
    this.getAllItemTypes();
  }

}
