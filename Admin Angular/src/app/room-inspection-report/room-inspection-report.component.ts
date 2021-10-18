import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-room-inspection-report',
  templateUrl: './room-inspection-report.component.html',
  styleUrls: ['./room-inspection-report.component.css']
})
export class RoomInspectionReportComponent implements OnInit {

  constructor() { }

  listOfData: any[] = [
    { date: '2021-04-24 15:51',
    student: 'John Doe',
    number: '12345678',
      status: 'Occuppied',
      result: 'Satified',
      block: 'G',
      room: '2-5',
    },

   { date: '2021-03-1 08:00',
    student: 'Jim kyle',
    number: '12445678',
    email: 'jimdoe@gmail.com',
    status: 'Occuppied',
    result: 'Unsatisfied',
    block: 'C',
    room: '1-7'
    },

    { date: '2021-07-08 11:21',
    student: 'Fred Lepara',
    number: '15786648',
    email: 'FredLepara@gmail.com',
    status: 'Occuppied',
    result: 'Unsatisfied',
    block: 'A',
    room: '1-7'
    },

  ];

  ngOnInit(): void {
  }

}
