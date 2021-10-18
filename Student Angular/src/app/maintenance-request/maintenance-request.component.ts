import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-maintenance-request',
  templateUrl: './maintenance-request.component.html',
  styleUrls: ['./maintenance-request.component.css']
})
export class MaintenanceRequestComponent implements OnInit {
  isVisibleMiddle: boolean;
  isAddRequestMiddle: boolean;
  isCancelRequestVisible: boolean;
  validateForm: any;
  isUpdateVisible: boolean;

  constructor(private modal: NzModalService,
    private fb: FormBuilder,
    private message: NzMessageService,
    private notification: NzNotificationService
  ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      sDate: [null, [Validators.required]],
      eDate: [null, [Validators.required]],
      type: [null, [Validators.required]],
      description: [null, [Validators.required]],
      address: [null, [Validators.required]],
      cellphone: [null, [Validators.required]],

    });
  }



  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
  }


  showModalMiddle(): void {
    this.isVisibleMiddle = true;
  }

  showAddRequestModal(): void {
    this.isAddRequestMiddle = true;
  }


  showCancelRequestModal(): void {
    this.isCancelRequestVisible = true;
  }


  showCancelRequestConfirm(): void {
    this.isVisibleMiddle = false;
    this.isCancelRequestVisible = false;
    this.notification.create('success','','Successfully cancelled application!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  }

  handleOkMiddle(): void {
    this.isVisibleMiddle = false;
  }

  handleOkAddRequest(): void {
    this.isAddRequestMiddle = false;
    this.notification.create('success','','Successfully created maintenance request!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  }

  handleCancelMiddle(): void {
    this.isVisibleMiddle = false;
  }

  handleCancelRequestModal(): void {
    this.isCancelRequestVisible = false;
  }

  handleCancelAddRequestModal(): void {
    this.isAddRequestMiddle = false;
  }

  showUpdateModal(): void {
    this.isUpdateVisible = true;

  }

  handleOkUpdate(): void {
    this.isUpdateVisible = false;


  }

  handleCancelUpdate(): void {
    this.isUpdateVisible = false;


  }


  cancel(): void {

  }

  confirm(): void {
    this.notification.create('success','','Successfully updated maintenance request!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isUpdateVisible = false;


  }


  listOfData: any[] = [
    {
      Date: "2020-08-18 23:16",
      Start: "2021-08-23",
      type: "Electrical",
      description: "My lights are not working.",
      Status: "Incomplete"
    },
    {
      Date: "2020-06-18 11:16",
      Start: "2021-08-23",
      type: "IT",
      description: "My LAN connection is not working.",
      Status: "Completed"
    }
  ];



}
