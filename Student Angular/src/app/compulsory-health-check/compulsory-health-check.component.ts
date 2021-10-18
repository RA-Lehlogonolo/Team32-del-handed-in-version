import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-compulsory-health-check',
  templateUrl: './compulsory-health-check.component.html',
  styleUrls: ['./compulsory-health-check.component.css']
})
export class CompulsoryHealthCheckComponent implements OnInit {
  validateForm: any;
  isAddItemVisible: boolean;
  isUpdateItemVisible: boolean;
  isDeleteItemVisible: boolean;
  isCompleteCheckVisible: boolean;
  constructor(
    private fb: FormBuilder,
    private notification: NzNotificationService
    ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      description: [null, [Validators.required]],
      name: [null, [Validators.required]],
      aType: [null, [Validators.required]],
      date: [null, [Validators.required]],


    });
  }

  showCompleteCheckModal(): void {
    this.isCompleteCheckVisible = true;

  }

  handleOkCompleteCheck(): void {
    this.isCompleteCheckVisible = false;
    this.notification.create('success','','Successfully completed health check!',
    {
      nzStyle: {backgroundColor: 'green',color: 'white' },
      nzClass: ''
    }
  );

  }

  handleCancelCompleteCheck(): void {
    this.isCompleteCheckVisible = false;


  }
  history: any[] = [
    {
      type:"Weekly Health Check",
    date:"2021-06-28",
      Chills:"No", 
      SoreThroat:"No",
      Coughing:"No",
      BodyAche:"No",
      Fatigue:"No", 
      RedEyes:"No", 
      DifficultyBreathing:"No",
      NauseaOrVomitting:"No",
      AnySysmptoms:"No", 
      Diarrhoea:"No",
      scannedby:"Wall scanner",
      temperature:"34.9",

    },
   {   type:"Weekly Health Check",
   date:"2021-06-21",
   Chills:"No", 
   SoreThroat:"No",
   Coughing:"No",
   BodyAche:"No",
   Fatigue:"No", 
   RedEyes:"No", 
   DifficultyBreathing:"No",
   NauseaOrVomitting:"No",
   AnySysmptoms:"No", 
   Diarrhoea:"No",
   scannedby:"Wall scanner",
   temperature:"35.0",
    },
    {   type:"Weekly Health Check",
    date:"2021-06-14",
    Chills:"No", 
    SoreThroat:"No",
    Coughing:"No",
    BodyAche:"No",
    Fatigue:"No", 
    RedEyes:"No", 
    DifficultyBreathing:"No",
    NauseaOrVomitting:"No",
    AnySysmptoms:"No", 
    Diarrhoea:"No",
    scannedby:"Wall scanner",
    temperature:"35.5",
     },
     {   type:"Weekly Health Check",
     date:"2021-06-07",
     Chills:"No", 
     SoreThroat:"No",
     Coughing:"No",
     BodyAche:"No",
     Fatigue:"No", 
     RedEyes:"No", 
     DifficultyBreathing:"No",
     NauseaOrVomitting:"No",
     AnySysmptoms:"No", 
     Diarrhoea:"No",
     scannedby:"Wall scanner",
     temperature:"34.0",

      },
   
  ];
}
