import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent implements OnInit {

  validateForm!: FormGroup;
  isAddRoomVisible: boolean;
  isDeleteRoomVisible: boolean;
  isUpdateRoomVisible: boolean;
  isViewRoomVisible: boolean;
  isViewRoom1Visible: boolean;
  isAssignRoomVisible: boolean;

  constructor(
    private fb: FormBuilder,
    private notification: NzNotificationService,
    ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      address: [null, [Validators.required]],
      name: [null, [Validators.required]],
      block: [null, [Validators.required]],
      campus: [null, [Validators.required]],


    });
  }

  showViewRoomModal(): void {
    //this.isViewRoomVisible = true;
    this.isViewRoom1Visible=true;
  }

  handleOkViewRoom(): void {
    //this.isViewRoomVisible = false;
    this.isViewRoom1Visible = false;

  }

  handleCancelViewRoom(): void {
    //this.isViewRoomVisible = false;
    this.isViewRoom1Visible = false;

  }

  showAssignRoomModal(): void {
    this.isAssignRoomVisible = true;

  }

  handleOkAssignRoom(): void {
    this.isAssignRoomVisible = false;
    //this.isViewRoomVisible=false;
    this.isViewRoom1Visible=false;
    this.notification.create('success','','Successfully assigned room!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
  }

  handleCancelAssignRoom(): void {
    this.isAssignRoomVisible = false;


  }


  showUpdateRoomModal(): void {
    this.isUpdateRoomVisible = true;
  }

  handleOkUpdateRoom(): void {
    this.isUpdateRoomVisible = false;
  }

  handleCancelUpdateRoom(): void {
    this.isUpdateRoomVisible = false;
  }

  showDeleteRoomModal(): void {
    this.isDeleteRoomVisible = true;
  }

  handleOkDeleteRoom(): void {
    this.isDeleteRoomVisible = false;
    //this.isViewRoomVisible=false;
    this.isViewRoom1Visible=false;
    this.notification.create('success','','Successfully deleted room!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
  }

  handleCancelDeleteRoom(): void {
    this.isDeleteRoomVisible = false;
  }

  showAddRoomModal(): void {
    this.isAddRoomVisible = true;
  }

  handleOkAddRoom(): void {
    this.isAddRoomVisible = false;
  }

  handleCancelAddRoom(): void {
    this.isAddRoomVisible = false;
  }

  
  confirm(): void {
    this.notification.create('success','','Successfully updated room!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isUpdateRoomVisible = false;


  }

  confirmAdd(): void {
    this.notification.create('success','','Successfully added room!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isAddRoomVisible = false;


  }

  listOfData: any[] = [
    {
      room: "0703",
      res: "TuksVillage",
      block:"Block G",
      status: "Occupied",
    },
   {
      room: "0709",
      res: "TuksVillage",
      block:"Block G",
      status: "Unoccupied",
    },
   
  ];

}
