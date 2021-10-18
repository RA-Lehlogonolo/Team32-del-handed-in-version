import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { NzUploadFile } from 'ng-zorro-antd/upload';
function getBase64(file: File): Promise<string | ArrayBuffer | null> {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
  });
} 

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  validateForm: any;
  isAddProductVisible: boolean;
  isUpdateProductVisible: boolean;
  isDeleteProductVisible: boolean;
  isViewProductVisible: boolean;
  fileList: NzUploadFile[]=[];  
  updatefileList: NzUploadFile[]=[   
    {
    uid: '-1',
    name: 'image.png',
    status: 'done',
    url: '../assets/Images/RMC_Back.jpg'
  },
];  

  previewImage: string | undefined = '';
  previewVisible = false;
  constructor(
    private fb: FormBuilder,
    private notification: NzNotificationService,
    ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      type: [null, [Validators.required]],
      name: [null, [Validators.required]],
      price: [null, [Validators.required]],
      image: [null, [Validators.required]],


    });

    console.log(this.fileList)
  }


  showAddProductModal(): void {
    this.isAddProductVisible = true;

  }

  handleOkAddProduct(): void {
    this.isAddProductVisible = false;


  }

  handleCancelAddProduct(): void {
    this.isAddProductVisible = false;


  }

  showViewProductModal(): void {
    this.isViewProductVisible = true;

  }

  handleOkViewProduct(): void {
    this.isViewProductVisible = false;


  }

  handleCancelViewProduct(): void {
    this.isViewProductVisible = false;


  }

  showUpdateProductModal(): void {
    this.isUpdateProductVisible = true;
  }

  handleOkUpdateProduct(): void {
    this.isUpdateProductVisible = false;
    this.isViewProductVisible = false;

  }

  handleCancelUpdateProduct(): void {
    this.isUpdateProductVisible = false;
  }

  showDeleteProductModal(): void {
    this.isDeleteProductVisible = true;
  }

  handleOkDeleteProduct(): void {
    this.isDeleteProductVisible = false;
    this.isViewProductVisible = false;
    this.notification.create('success','','Successfully deleted product!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );

  }
  handleCancelDeleteProduct(): void {
    this.isDeleteProductVisible = false;

  }



  handlePreview = async (file: NzUploadFile) => {
    if (!file.url && !file.preview) {
      file.preview = await getBase64(file.originFileObj!);
    }
    this.previewImage = file.url || file.preview;
    this.previewVisible = true;
  }


  confirm(): void {
    this.notification.create('success','','Successfully updated product!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isUpdateProductVisible = false;


  }

  confirmAdd(): void {
    this.notification.create('success','','Successfully added product!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isAddProductVisible = false;

  }
}
