import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { ResidenceAllocationLog } from 'src/app/services/audit/audit.types';
import { LogService } from 'src/app/services/audit/log.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CurrentUser } from 'src/app/services/auth/auth.types';
import { CampusManagementService } from 'src/app/services/campus-management/campus-management.service';
import { GenericNameAndIdType } from 'src/app/services/shared/shared.types';

@Component({
  selector: 'app-residence-allocation-audit-log',
  templateUrl: './residence-allocation-audit-log.component.html',
  styleUrls: ['./residence-allocation-audit-log.component.css']
})
export class ResidenceAllocationAuditLogComponent implements OnInit {

  tableDataReady: boolean = false;
  loggedInUser: CurrentUser;

  listOfData: ResidenceAllocationLog[] = [];
  listOfDisplayData: ResidenceAllocationLog[] = [];

  //Search Operations
  searchValue = '';
  visible = false;
  reset(): void {
    this.searchValue = '';
    this.search();
  }
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.listOfData.filter((item: ResidenceAllocationLog) => item.studentNumber.indexOf(this.searchValue) !== -1);
  }

  constructor(
    private fb: FormBuilder,
    private _nzNotificationService: NzNotificationService,
    private _authService: AuthService,
    private _logService: LogService
  ) {
    this.getUserDetails();
    this.getAllRecords();
  }

  ngOnInit(): void {
  }


  private getAllRecords() {
    this._logService.getAllResidenceAuditLogs()
      .subscribe(event => {
        if (event.type === HttpEventType.Sent) {
          this.tableDataReady = false;
        }
        if (event.type === HttpEventType.Response) {

          this.listOfData = event.body as ResidenceAllocationLog[];
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
}
