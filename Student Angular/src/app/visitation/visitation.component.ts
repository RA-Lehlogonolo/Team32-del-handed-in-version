import { style } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzNotificationService } from 'ng-zorro-antd/notification';


@Component({
  selector: 'app-visitation',
  templateUrl: './visitation.component.html',
  styleUrls: ['./visitation.component.css']
})
export class VisitationComponent implements OnInit {
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
      visitationReason: [null, [Validators.required]],
      host: [null, [Validators.required]],
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
    this.notification.create('success','','Successfully sent application!',
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
    this.notification.create('success','','Successfully updated application!',
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
      End: "2021-08-26",
      Reason: "I have to attend a relative's funeral",
      Status: "Pending"
    },
    {
      Date: "2021-03-11 21:38",
      Start: "2021-10-01",
      End: "2021-11-01",
      Reason: "Lorem ipsum dolor sit amet,",
      Status: "Approved"
    },
    {
      Date: "2021-03-25 21:40",
      Start: "2021-06-17",
      End: "2020-12-26",
      Reason: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur",
      Status: "Rejected"
    },
  ];


}
