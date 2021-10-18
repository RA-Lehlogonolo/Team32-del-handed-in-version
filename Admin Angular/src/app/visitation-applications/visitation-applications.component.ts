import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-visitation-applications',
  templateUrl: './visitation-applications.component.html',
  styleUrls: ['./visitation-applications.component.css']
})
export class VisitationApplicationsComponent implements OnInit {
  validateForm: any;
  isViewApplicationVisible: boolean;
  isApproveApplicationVisible: boolean;
  isRejectApplicationVisible: boolean;
  constructor(
    private fb: FormBuilder,
    private notification: NzNotificationService,
    ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      description: [null, [Validators.required]],
      name: [null, [Validators.required]],
      aType: [null, [Validators.required]],
      campus: [null, [Validators.required]],


    });
  }

  showViewApplicationModal(): void {
    this.isViewApplicationVisible = true;

  }

  handleOkViewApplication(): void {
    this.isViewApplicationVisible = false;


  }

  handleCancelViewApplication(): void {
    this.isViewApplicationVisible = false;


  }

  showApproveApplicationModal(): void {
    this.isApproveApplicationVisible = true;
  }

  handleOkApproveApplication(): void {
    this.isApproveApplicationVisible = false;
    this.isViewApplicationVisible = false;
    this.notification.create('success','','Successfully approved application!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
  }

  handleCancelApproveApplication(): void {
    this.isApproveApplicationVisible = false;
  }

  showRejectApplicationModal(): void {
    this.isRejectApplicationVisible = true;
  }

  handleOkRejectApplication(): void {
    this.isRejectApplicationVisible = false;
    this.isViewApplicationVisible = false;
    this.notification.create('success','','Successfully rejected application!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );

  }
  handleCancelRejectApplication(): void {
    this.isRejectApplicationVisible = false;
  }

  listOfData: any[] = [
    {
      Date: "2020-07-18 23:16",
      Start: "2021-05-26",
      End: "2021-08-23",
      Reason: "I have to attend a relative's funeral",
      Status: "Pending",
      Student: "John Doe"

    },
    {
      Date: "2021-03-11 21:38",
      Start: "2021-10-01",
      End: "2021-11-01",
      Reason: " I have to attend to a family emergency,",
      Status: "Approved",
      Student: "Jim Doe"

    },
    {
      Date: "2021-03-25 21:40",
      Start: "2021-06-17",
      End: "2020-12-26",
      Reason: "I miss home !",
      Status: "Rejected",
      Student: "Jim Doe"
    },
  ];


}
