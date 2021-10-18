import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-room-inspection',
  templateUrl: './room-inspection.component.html',
  styleUrls: ['./room-inspection.component.css']
})
export class RoomInspectionComponent implements OnInit {
  isVisibleMiddle: boolean;
  isAddRequestMiddle: boolean;
  isCancelRequestVisible: boolean;
  validateForm: any;
  isUpdateVisible: boolean;
  isViewVisible: boolean;

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
    this.notification.create('success', '', 'Successfully cancelled application!',
      {
        nzStyle: { backgroundColor: 'green', color: 'white' },
        nzClass: ''
      }
    );
  }

  handleOkMiddle(): void {
    this.isVisibleMiddle = false;
  }

  handleOkAddRequest(): void {
    this.isAddRequestMiddle = false;
    this.notification.create('success', '', 'Successfully completed move-in inspection!',
      {
        nzStyle: { backgroundColor: 'green', color: 'white' },
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

  showViewModal(): void {
    this.isViewVisible = true;

  }

  handleOkView(): void {
    this.isViewVisible = false;


  }

  handleCancelView(): void {
    this.isViewVisible = false;


  }


  cancel(): void {

  }

  confirm(): void {
    this.notification.create('success', '', 'Successfully completed move-in inspection!',
      {
        nzStyle: { backgroundColor: 'green', color: 'white' },
        nzClass: ''
      }
    );
    this.isAddRequestMiddle = false;


  }


  listOfData: any[] = [
    {
      Date: "2020-08-18 23:16",
      block: "Block B",
      room:"0436",
 
    },
    {
      Date: "2020-06-18 11:16",
      block: "Block C",
      room:"0766",
    }
  ];

}
