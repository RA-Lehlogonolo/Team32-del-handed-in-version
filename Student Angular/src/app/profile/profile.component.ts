import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  isVisibleMiddle: boolean=false;
  validateForm: any;

  constructor(
    private modal: NzModalService,
    private fb: FormBuilder,
    private message: NzMessageService,
    private notification: NzNotificationService
    ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      pEmail: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],


    });
  }

  showModalMiddle(): void {
    this.isVisibleMiddle = true;
  }

  handleOkMiddle(): void {
    console.log('click ok');
    this.isVisibleMiddle = false;

  }

  handleCancelMiddle(): void {
    this.isVisibleMiddle = false;
  }

  cancel(): void {

  }

  confirm(): void {
    this.notification.create('success','','Successfully updated profile!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  this.isVisibleMiddle = false;

  }

}
