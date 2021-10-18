import { Component, OnInit } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-browse-merchandise',
  templateUrl: './browse-merchandise.component.html',
  styleUrls: ['./browse-merchandise.component.css']
})
export class BrowseMerchandiseComponent implements OnInit {
  isVisibleMiddle: boolean=false;
  isViewCartVisible: boolean=false;
  isUpdateCartItemVisible: boolean=false;
  isRemoveCartItemVisible: boolean=false;
  isEmptyCartVisible: boolean=false;
  demoValue1=3;
  cartTotal: number;
  isPlaceVisible: boolean;


  constructor(    private notification: NzNotificationService
    ) { }

  ngOnInit(): void {
  this.getCartTotal();
    
  }

  
  showModalMiddle(): void {
    this.isVisibleMiddle = true;
  }

  handleOkMiddle(): void {
    this.isVisibleMiddle = false;
    this.notification.create('success','','Successfully added to cart!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  }

  handleCancelMiddle(): void {
    this.isVisibleMiddle = false;
  }

  showUpdateCartItemModal(): void {
    this.isUpdateCartItemVisible = true;
  }

  handleOkUpdateCartItem(): void {
    this.isUpdateCartItemVisible = false;
    this.notification.create('success','','Successfully updated cart item!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  }

  handleCancelUpdateCartItem(): void {
    this.isUpdateCartItemVisible = false;
  }

  showViewCartModal(): void {
    this.isViewCartVisible = true;
  }

  handleOkViewCart(): void {
    this.isViewCartVisible = false;
  }

  handleCancelViewCart(): void {
    this.isViewCartVisible = false;
  }

  showRemoveCartItemModal(): void {
    this.isRemoveCartItemVisible = true;
  }

  handleOkRemoveCartItem(): void {
    this.isRemoveCartItemVisible = false;
    this.notification.create('success','','Successfully removed cart item!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  }

  handleCancelRemoveCartItem(): void {
    this.isRemoveCartItemVisible = false;
  }

  showEmptyCartModal(): void {
    this.isEmptyCartVisible = true;
  }

  handleOkEmptyCart(): void {
    this.isEmptyCartVisible = false;
    this.notification.create('success','','Successfully cleared cart!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );
  }

  handleCancelEmptyCart(): void {
    this.isEmptyCartVisible = false;
  }

  showPlaceModal(): void {
    this.isPlaceVisible = true;
  }

  handleOkPlace(): void {
    this.isPlaceVisible = false;
  }

  handleCancelPlace(): void {
    this.isPlaceVisible = false;
  }

  listOfData: any[] = [
    {
      Product: "RMC T-shirt  Size: XS",
      Price: 300,
      Quantity: 3,
    
    },
    {
      Product: "Village T-shirt  Size: XS",
      Price: 200,
      Quantity: 2,
    },
    {
      Product: "RMC T-shirt  Size: M",
      Price: 300,
      Quantity: 1,
    },
  ];

  getCartTotal(){
    var sum = 0;
    for( var i = 0; i < this.listOfData.length; i++ ){
        sum += this.listOfData[i].Price*this.listOfData[i].Quantity; 
    }

    this.cartTotal=sum;

  }
}
