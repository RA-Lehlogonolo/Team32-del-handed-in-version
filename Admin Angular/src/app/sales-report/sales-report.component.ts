import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-sales-report',
  templateUrl: './sales-report.component.html',
  styleUrls: ['./sales-report.component.css']
})
export class SalesReportComponent implements OnInit {
  validateForm: any;
  Total: number;

  constructor(    private fb: FormBuilder,
    ) { }

  ngOnInit(): void {

    this.getCartTotal()
    this.validateForm = this.fb.group({
      description: [null, [Validators.required]],
      student: [null, [Validators.required]],
      name: [null, [Validators.required]],
      date: [null, [Validators.required]],


    });
  }
  listOfData = [
    {
      OrderId: "12345",
      OrderDate:"2021-05-26 17:51",
      TotalCost: 300,
      Type: "EFT",
      Products:"TuksVillage T-shirt, TuksVillage Hoodie"
    
    },
    {
      OrderId: "12399",
      OrderDate:"2021-04-26 07:47",
      TotalCost: 200,
      Type: "Cash",
      Products:"TuksVillage T-shirt"
    },
    {
      OrderId: "12488",
      OrderDate:"2021-04-24 15:51",
      TotalCost: 300,
      Type: "Cash",
      Products:"TuksVillage Hoodie"
    },
  ];

  getCartTotal(){
    var sum = 0;
    for( var i = 0; i < this.listOfData.length; i++ ){
        sum += this.listOfData[i].TotalCost; 
    }

    this.Total=sum;

  }

}
