import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-health-inspection-report',
  templateUrl: './health-inspection-report.component.html',
  styleUrls: ['./health-inspection-report.component.css']
})
export class HealthInspectionReportComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  listOfData: any[] = [
    { date:"2021-04-24 15:51",
    student: "John Doe",
    number: "12345678",
    email: "johndoe@gmail.com",
      status: "Complete",
      result:"At Low risk",
    },
   { date:"2021-04-21 15:51",
    student: "Jim Doe",
    number: "12445678",
    email: "jimdoe@gmail.com",
    status: "Incomplete",
    result:"Pending",
 
    },
   
  ];

}
