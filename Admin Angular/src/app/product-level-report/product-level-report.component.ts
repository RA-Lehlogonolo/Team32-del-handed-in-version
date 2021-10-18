import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-level-report',
  templateUrl: './product-level-report.component.html',
  styleUrls: ['./product-level-report.component.css']
})
export class ProductLevelReportComponent implements OnInit {

  constructor() { }

  listOfData: any[] = [
    { NumberOnHand: '72',
    Product: 'Caps',
    },

   { NumberOnHand: '58',
   Product: 'Grocery-bag',
    },

    { NumberOnHand: '14',
    Product: 'RMC T-shirts',
     },


  ];


  ngOnInit(): void {
  }

}
