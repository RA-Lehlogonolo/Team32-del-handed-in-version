import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-room-inspection',
  templateUrl: './room-inspection.component.html',
  styleUrls: ['./room-inspection.component.css']
})
export class RoomInspectionComponent implements OnInit {
  isAddDisciplinaryVisible: boolean;
  isUpdateDisciplinaryVisible: boolean;
  isDeleteDisciplinaryVisible: boolean;
  validateForm: any;
  nowBtn= false;
  isViewRoomVisible: boolean;


  constructor(
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      description: [null, [Validators.required]],
      student: [null, [Validators.required]],
      room: [null, [Validators.required]],
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

  showViewRoomModal(): void {
    this.isViewRoomVisible = true;

  }

  handleOkViewRoom(): void {
    this.isViewRoomVisible = false;


  }

  handleCancelViewRoom(): void {
    this.isViewRoomVisible = false;


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


  }
  handleCancelDeleteDisciplinary(): void {
    this.isDeleteDisciplinaryVisible = false;
  }


  listOfData: any[] = [
    {
      date: "2021-09-15 15:00",
      description: "Caught vandalising res facilities.",
      room:"0703",
      student: "John Doe",
    },
   {
    date: "2021-09-14 15:00",
    description: "Caught vandalising res facilities.",
    room:"0453",
    student: "Jim Doe",
    },
   
  ];
}
