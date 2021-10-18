import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { NzSelectSizeType } from 'ng-zorro-antd/select';

@Component({
  selector: 'app-days',
  templateUrl: './days.component.html',
  styleUrls: ['./days.component.css']
})
export class DaysComponent implements OnInit {
  isAddDayVisible: boolean;

  isViewDayVisible: boolean;
  isUpdateDayVisible: boolean;
  isDeleteDayVisible: boolean;

  multipleValue; multipleSauce; multipleGravy;  multipleVegetable;  multipleSalad;  multipleProtein;

  multipleValueVS;  multipleSauceVS;  multipleGravyVS;  multipleVegetableVS;  multipleSaladVS;  multipleProteinVS;

  multipleValueTL;  multipleSauceTL;  multipleGravyTL;  multipleVegetableTL;  multipleSaladTL;  multipleProteinTL;

  multipleValueTS;
  multipleSauceTS;
  multipleGravyTS;
  multipleVegetableTS;
  multipleSaladTS;
  multipleProteinTS;


  multipleValueSL;
  multipleSauceSL;
  multipleGravySL;
  multipleVegetableSL;
  multipleSaladSL;
  multipleProteinSL;


  multipleValueSS;
  multipleSauceSS;
  multipleGravySS;
  multipleVegetableSS;
  multipleSaladSS;
  multipleProteinSS;
  
  listOfOption: Array<{ label: string; value: string }> = [];
  size: NzSelectSizeType = 'default';
  validateForm: any;


  constructor(    private fb: FormBuilder,
    private notification: NzNotificationService,
    ) { }

    ngOnInit(): void {


      this.validateForm = this.fb.group({
        description: [null, [Validators.required]],
        name: [null, [Validators.required]],
        aType: [null, [Validators.required]],
        starch: [null, [Validators.required]],
        protein: [null, [Validators.required]],
        gravy: [null, [Validators.required]],
        vegetable: [null, [Validators.required]],
        salad: [null, [Validators.required]],
        sauce: [null, [Validators.required]],
  
        description1: [null, [Validators.required]],
        aType1: [null, [Validators.required]],
        starch1: [null, [Validators.required]],
        protein1: [null, [Validators.required]],
        gravy1: [null, [Validators.required]],
        vegetable1: [null, [Validators.required]],
        salad1: [null, [Validators.required]],
        sauce1: [null, [Validators.required]],

        description2: [null, [Validators.required]],
        aType2: [null, [Validators.required]],
        starch2: [null, [Validators.required]],
        protein2: [null, [Validators.required]],
        gravy2: [null, [Validators.required]],
        vegetable2: [null, [Validators.required]],
        salad2: [null, [Validators.required]],
        sauce2: [null, [Validators.required]],

        description3: [null, [Validators.required]],
        aType3: [null, [Validators.required]],
        starch3: [null, [Validators.required]],
        protein3: [null, [Validators.required]],
        gravy3: [null, [Validators.required]],
        vegetable3: [null, [Validators.required]],
        salad3: [null, [Validators.required]],
        sauce3: [null, [Validators.required]],

        description4: [null, [Validators.required]],
        aType4: [null, [Validators.required]],
        starch4: [null, [Validators.required]],
        protein4: [null, [Validators.required]],
        gravy4: [null, [Validators.required]],
        vegetable4: [null, [Validators.required]],
        salad4: [null, [Validators.required]],
        sauce4: [null, [Validators.required]],

        description5: [null, [Validators.required]],
        aType5: [null, [Validators.required]],
        starch5: [null, [Validators.required]],
        protein5: [null, [Validators.required]],
        gravy5: [null, [Validators.required]],
        vegetable5: [null, [Validators.required]],
        salad5: [null, [Validators.required]],
        sauce5: [null, [Validators.required]],
  
      });
    }
// add
  showAddDayModal(): void {
    this.isAddDayVisible = true;
  }

  handleOkAddDay(): void {
    this.isAddDayVisible = false;
  }

  handleCancelAddDay(): void {
    this.isAddDayVisible = false;
  }
//view
  showViewDayModal(): void {
    this.isViewDayVisible = true;
  }

  handleOkViewDay(): void {
    this.isViewDayVisible = false;
  }

  handleCancelViewDay(): void {
    this.isViewDayVisible = false;
  }

  //update
  showUpdateDayModal(): void {
    this.isUpdateDayVisible = true;
  }

  handleOkUpdateDay(): void {
    this.isUpdateDayVisible = false;
  }

  handleCancelUpdateDay(): void {
    this.isUpdateDayVisible = false;
  }

  showDeleteDayModal(): void {
    this.isDeleteDayVisible = true;
  }

  handleOkDeleteDay(): void {
    this.isDeleteDayVisible = false;
    this.notification.create('success','','Successfully deleted day!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );

  }
  handleCancelDeleteDay(): void {
    this.isDeleteDayVisible = false;
  }

  confirm(): void {
    this.notification.create('success','','Successfully updated day!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isUpdateDayVisible = false;


  }

  confirmAdd(): void {
    this.notification.create('success','','Successfully added day!',
      {
        nzStyle: {backgroundColor: 'green',color: 'white' },
        nzClass: ''
      }
    );
    this.isAddDayVisible = false;

  }
  

  listOfDat: any[] = [
    {
      item: "Crumbed chicken strips",
      itemType: "Protein",
    },
    {

      item: "Tortilla",
      itemType: "Starch",
    },
    {

      item: "Chicken Leg",
      itemType: "Protein",
    },

    {

      item: "Rice",
      itemType: "Starch",
    }, 
    {

      item: "French Salad & dressing",
      itemType: "Salad",
    },
    {

      item: "Greek Salad & dressing",
      itemType: "Salad",
    },
    {

      item: "Peas",
      itemType: "Vegetable",
    },
    {

      item: "Sea Food Sauce",
      itemType: "Sauce",
    },
    {

      item: "Creamed Spinach",
      itemType: "Vegetable",
    },
    {

      item: "Cheese Sauce",
      itemType: "Sauce",
    },
    

  ];

  listOfGravy: any[] = [
    {
      item: "Tomato and Onion Gravy",
    },
    {

      item: "Chicken Gravy",

    },
    {

      item: "Beef Steak",

    },

  ];


  listOfProtein: any[] = [
    {
      item: "Crumbed chicken strips",
    },
    {

      item: "Chicken Leg",

    },
    {

      item: "Beef Steak",

    },

  ];

  listOfVegetable: any[] = [
    {
      item: "Creamed Spinach",
    },
    {

      item: "Peas",

    },
  ];

  listOfSalad: any[] = [
    {
      item: "French Salad & dressing",
    },
    {

      item: "Greek Salad & dressing",

    },
  ];

  listOfSauce: any[] = [
    {
      item: "Sea Food Sauce",
    },
    {

      item: "Cheese Sauce",

    },
  ];
  
  listOfStarch: any[] = [
    {
      item: "Tortilla",
    },
    {

      item: "Rice",

    },
    {

      item: "Pap",

    },

  ];

  
  listOfData: any[] = [
    {
      day: "Day 1",
    },
    {

      day: "Day 2",

    },
    {

      day: "Day 3",

    },

    {

      day: "Day 4",

    }, 
 


  ];
}
