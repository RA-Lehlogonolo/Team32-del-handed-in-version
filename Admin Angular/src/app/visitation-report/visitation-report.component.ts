import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-visitation-report',
  templateUrl: './visitation-report.component.html',
  styleUrls: ['./visitation-report.component.css']
})
export class VisitationReportComponent implements OnInit {

  constructor() { }

  listOfData = [
    {
      date: '2020-07-18 23:16',
      start: '2021-05-26',
      end: '2021-08-23',
      reason: 'I have to attend a relative\'s funeral',
      status: 'Pending',
      student: 'John Doe',
      number: 'u20135543'

    },
    {
      date: '2021-03-11 21:38',
      start: '2021-10-01',
      end: '2021-11-01',
      reason: ' I have to attend to a family emergency,',
      status: 'Approved',
      student: 'Jim Doe',
      number: 'u19877587'

    },
    {
      date: '2021-03-25 21:40',
      atart: '2021-06-17',
      end: '2020-12-26',
      reason: 'I miss home !',
      status: 'Rejected',
      student: 'Jim Doe',
      number: 'u17535434'
    },
  ];

  ngOnInit(): void {
  }
}
