import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-health-inspection-results',
  templateUrl: './health-inspection-results.component.html',
  styleUrls: ['./health-inspection-results.component.css']
})
export class HealthInspectionResultsComponent implements OnInit {


  constructor(
    private fb: FormBuilder) { }
  validateForm!: FormGroup;
  isAddUserVisible: boolean;
  isUpdateUserVisible: boolean;
  isDeleteUserVisible: boolean;
  isViewResultVisible: boolean;




  listOfData: any[] = [
    {
      fullName: 'John Doe',
      email: 'johndoe@gmail.com',
      status: 'Complete',
      result: 'At Low risk',
    },
   {
    fullName: 'Jim Doe',
    email: 'jimdoe@gmail.com',
    status: 'Incomplete',
    result: 'Pending',

    },

  ];


  history: any[] = [
    {
      type: 'Weekly Health Check',
    date: '2021-06-28',
      Chills: 'No',
      SoreThroat: 'No',
      Coughing: 'No',
      BodyAche: 'No',
      Fatigue: 'No',
      RedEyes: 'No',
      DifficultyBreathing: 'No',
      NauseaOrVomitting: 'No',
      AnySysmptoms: 'No',
      Diarrhoea: 'No'

    },
   {   type: 'Weekly Health Check',
   date: '2021-06-21',
   Chills: 'No',
   SoreThroat: 'No',
   Coughing: 'No',
   BodyAche: 'No',
   Fatigue: 'No',
   RedEyes: 'No',
   DifficultyBreathing: 'No',
   NauseaOrVomitting: 'No',
   AnySysmptoms: 'No',
   Diarrhoea: 'No'
    },
    {   type: 'Weekly Health Check',
    date: '2021-06-14',
    Chills: 'No',
    SoreThroat: 'No',
    Coughing: 'No',
    BodyAche: 'No',
    Fatigue: 'No',
    RedEyes: 'No',
    DifficultyBreathing: 'No',
    NauseaOrVomitting: 'No',
    AnySysmptoms: 'No',
    Diarrhoea: 'No'
     },
     {   type: 'Weekly Health Check',
     date: '2021-06-07',
     Chills: 'No',
     SoreThroat: 'No',
     Coughing: 'No',
     BodyAche: 'No',
     Fatigue: 'No',
     RedEyes: 'No',
     DifficultyBreathing: 'No',
     NauseaOrVomitting: 'No',
     AnySysmptoms: 'No',
     Diarrhoea: 'No'
      },

  ];

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      description: [null, [Validators.required]],
      name: [null, [Validators.required]],
      aType: [null, [Validators.required]],
      username: [null, [Validators.required]],
      surname: [null, [Validators.required]],
      email: [null, [Validators.required]],


    });
  }

  showViewResultsModal(): void {
    this.isViewResultVisible = true;

  }

  handleOkViewResult(): void {
    this.isViewResultVisible = false;


  }

  handleCancelViewResult(): void {
    this.isViewResultVisible = false;


  }

  showUpdateUserModal(): void {
    this.isUpdateUserVisible = true;
  }

  handleOkUpdateUser(): void {
    this.isUpdateUserVisible = false;
  }

  handleCancelUpdateUser(): void {
    this.isUpdateUserVisible = false;
  }

  showDeleteUserModal(): void {
    this.isDeleteUserVisible = true;
  }

  handleOkDeleteUser(): void {
    this.isDeleteUserVisible = false;


  }
  handleCancelDeleteUser(): void {
    this.isDeleteUserVisible = false;
  }

}
