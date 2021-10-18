import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isCollapsed = false;
  showMenuItems: boolean;

  constructor(private router: Router) {}
 
  ngOnInit() {
    // listening to routing navigation event
    this.router.events.subscribe(event => this.modifyMenuItems(event));
   }

   openMap: { [name: string]: boolean } = {
    sub1: false,
    sub2: false,
    sub3: false,
    sub4: false,
    sub5: false,
    sub6: false,
    sub7: false,
    sub8: false


  };

  openHandler(value: string): void {
    for (const key in this.openMap) {
      if (key !== value) {
        this.openMap[key] = false;
      }
    }
  }
   modifyMenuItems(location){
    if (window.location.pathname=="/" ||window.location.pathname=="/login" || window.location.pathname =="/reset-password")
    {
      this.showMenuItems = false;
    } 
    else 
    {
      this.showMenuItems = true;
    }

  }

}
