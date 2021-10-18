import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-disciplinary-hearing',
  templateUrl: './disciplinary-hearing.component.html',
  styleUrls: ['./disciplinary-hearing.component.css']
})
export class DisciplinaryHearingComponent implements OnInit {
  isAddDisciplinaryVisible: boolean;
  isUpdateDisciplinaryVisible: boolean;
  isDeleteDisciplinaryVisible: boolean;
  validateForm: any;
  nowBtn= false;
  isViewHearingVisible: boolean;
  isUploadVisible: boolean;
  uploading: boolean;
  loading: boolean;
  avatarUrl: boolean;
  msg: any;
  fileList: NzUploadFile[] = [];


  constructor(
    private fb: FormBuilder,
    private notification: NzNotificationService,
    ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      description: [null, [Validators.required]],
      student: [null, [Validators.required]],
      venue: [null, [Validators.required]],
      date: [null, [Validators.required]],


    });
  }

  showAddDisciplinaryModal(): void {
    this.isAddDisciplinaryVisible = true;

  }

  handleOkAddDisciplinary(): void {
    this.isAddDisciplinaryVisible = false;


  }

  handleCancelAddDisciplinary(): void {
    this.isAddDisciplinaryVisible = false;


  }

  showViewHearingModal(): void {
    this.isViewHearingVisible = true;

  }

  handleOkViewHearing(): void {
    this.isViewHearingVisible = false;


  }

  handleCancelViewHearing(): void {
    this.isViewHearingVisible = false;


  }

  showUpdateDisciplinaryModal(): void {
    this.isUpdateDisciplinaryVisible = true;
  }

  handleOkUpdateDisciplinary(): void {
    this.isUpdateDisciplinaryVisible = false;
  }

  handleCancelUpdateDisciplinary(): void {
    this.isUpdateDisciplinaryVisible = false;
  }

  showDeleteDisciplinaryModal(): void {
    this.isDeleteDisciplinaryVisible = true;
  }

  handleOkDeleteDisciplinary(): void {
    this.isDeleteDisciplinaryVisible = false;
    this.notification.create('success','','Successfully deleted disciplinary hearing!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
  }
  handleCancelDeleteDisciplinary(): void {
    this.isDeleteDisciplinaryVisible = false;

  }

  showUploadModal(): void {
    this.isUploadVisible = true;

  }

  handleOkUpload(): void {
    this.isUploadVisible = false;
    this.notification.create('success','','Successfully uploaded disciplinary hearing notes!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );

  }

  handleCancelUpload(): void {
    this.isUploadVisible = false;


  }

  
  confirm(): void {
    this.notification.create('success','','Successfully updated disciplinary hearing!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isUpdateDisciplinaryVisible = false;


  }

  confirmAdd(): void {
    this.notification.create('success','','Successfully added disciplinary hearing!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isAddDisciplinaryVisible = false;


  }


  listOfData: any[] = [
    {
      date: "2021-09-15 15:00",
      description: "Caught vandalising res facilities.",
      venue:"TuksVillage Boardroom",
      student: "John Doe",
      misconductType: "Vandalism",

    },
   {
    date: "2021-09-14 15:00",
    description: "Caught vandalising res facilities.",
    venue:"TuksVillage Boardroom",
    student: "Jim Doe",
    misconductType: "Vandalism",

    },
   
  ];

  beforeUpload = (file: NzUploadFile): boolean => {
    this.fileList = this.fileList.concat(file);
    return false;
  };

  handleUpload(): void {
    const formData = new FormData();
    // tslint:disable-next-line:no-any
    this.fileList.forEach((file: any) => {
      formData.append('files[]', file);
    });
    this.uploading = true;

  }


  getBase64(img: File, callback: (img: string) => void): void {
    const reader = new FileReader();
    reader.addEventListener('load', () => callback(reader.result!.toString()));
    reader.readAsDataURL(img);
  }

  handleChange(info: { file: NzUploadFile }): void {debugger;
    switch (info.file.status) {
      case 'uploading':
        this.loading = true;
        break;
      case 'done':
        // Get this url from response in real world.
        this.loading = false;
        this.avatarUrl = true;
   
        break;
      case 'error':debugger;
        this.msg.error('Network error');
        this.loading = false;
        break;
    }
  }

}
