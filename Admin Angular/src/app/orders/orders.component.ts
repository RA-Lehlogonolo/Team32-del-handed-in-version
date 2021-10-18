import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { NzUploadFile } from 'ng-zorro-antd/upload';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  isViewOrderVisible: boolean=false;
  isCancelOrderVisible : boolean=false;
  isProofOfPaymentVisible : boolean=false;
  loading = false;
  avatarUrl: boolean;
  uploading = false;
  fileList: NzUploadFile[] = [];
  keywords='';
  isUpdateOrderVisible: boolean;

  constructor(private msg: NzMessageService,
    private notification: NzNotificationService
    ) { }

  ngOnInit(): void {
  }



  
  showViewOrderModal(): void {
    this.isViewOrderVisible = true;
  }

  handleOkViewOrder(): void {
    this.isViewOrderVisible = false;
  }

  handleCancelViewOrder(): void {
    this.isViewOrderVisible = false;
  }

  showCancelOrderModal(): void {
    this.isCancelOrderVisible = true;
  }

  handleOkCancelOrder(): void {
    this.isCancelOrderVisible = false;
    this.isViewOrderVisible = false;
    this.notification.create('success','','Successfully cancelled order!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  }

  handleCancelCancelOrder(): void {
    this.isCancelOrderVisible = false;
   

  }

  showProofOfPaymentModal(): void {
    this.isProofOfPaymentVisible = true;
  }

  handleOkProofOfPayment(): void {
    this.isProofOfPaymentVisible = false;
    this.notification.create('success','','Successfully uploaded proof of payment!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  }

  handleCancelProofOfPayment(): void {
    this.isProofOfPaymentVisible = false;
   

  }

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


  confirmPaid(): void {
    this.notification.create('success','','Successfully updated status to Paid!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isUpdateOrderVisible = false;
    this.isViewOrderVisible = false;


  }

  confirmReady(): void {
    this.notification.create('success','','Successfully updated status to Ready for Collection!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isViewOrderVisible = false;


  }

  confirmCollected(): void {
    this.notification.create('success','','Successfully updated status to Collected!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isViewOrderVisible = false;


  }

  listOfData = [
    {
      OrderId: "12345",
      OrderDate:"2021-05-26 17:51",
      TotalCost: 300,
      Status: "Placed",
      student:"Jim Doe"
    
    },
    {
      OrderId: "12399",
      OrderDate:"2021-04-26 07:47",
      TotalCost: 200,
      Status: "Collected",
      student:"Jane Doe"

    },
    {
      OrderId: "12488",
      OrderDate:"2021-05-26 15:51",
      TotalCost: 300,
      Status: "Cancelled",
      student:"John Doe"

    },
  ];

  copylistOfData = [...this.listOfData];
  search(search){debugger;
     const targetValue: any[] = [];
    this.copylistOfData.forEach((value: any) => {
      let keys = Object.keys(value);
      for (let i = 0; i < keys.length; i++) {
        if (value[keys[i]] && value[keys[i]].toString().toLocaleLowerCase().includes(search)) {
          targetValue.push(value);
          console.log(targetValue)
          break;
        }
      }
    });
    this.listOfData = targetValue;
  }

  
  showUpdateOrderModal(): void {
    this.isUpdateOrderVisible = true;

  }

  handleOkUpdateOrder(): void {
    this.isUpdateOrderVisible = false;


  }

  handleCancelUpdateOrder(): void {
    this.isUpdateOrderVisible = false;


  }

}
