import { Component, OnInit } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
selectMonth = [];
days = [];
MealDays =
[
{mealDay: 'Day 1'},
{mealDay: 'Day 2'},
{mealDay: 'Day 3'},
{mealDay: 'Day 4'},
{mealDay: 'Day 5'},
{mealDay: 'Day 6'},
{mealDay: 'Day 7'},
{mealDay: 'Day 8'},
{mealDay: 'Day 9'},
{mealDay: 'Day 10'},
{mealDay: 'Day 11'},
{mealDay: 'Day 12'},
{mealDay: 'Day 13'},
{mealDay: 'Day 14'},
{mealDay: 'Day 15'},
{mealDay: 'Day 16'},
{mealDay: 'Saturday A'},
{mealDay: 'Sunday A'},
{mealDay: 'Saturday B'},
{mealDay: 'Sunday B'},
{mealDay: 'Saturday C'},
{mealDay: 'Sunday C'},
];
  constructor(    private notification: NzNotificationService,
    ) { }

  ngOnInit(): void {
this.getDaysOfTheMonth();
  }

getDaysOfTheMonth(){
  const month = 6; // July
  const year = 2021;
  const date = new Date(Date.UTC(year, month, 1));
  const dayName = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
  while (date.getUTCMonth() === month) {
    const x = new Date(date).getDay();

    this.days.push({date: new Date(date).getUTCDate(), day: dayName[x]}
      );
    date.setUTCDate(date.getUTCDate() + 1);
  }
  const a = new Date();

  const currentDateString = (a.getMonth() + 1) + '/' + a.getDate() + '/' + a.getFullYear();
  console.log(currentDateString);


  const theMonths = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December');
  const now = new Date();

  for (let i = 0; i < 12; i++) {
  const future = new Date(now.getFullYear(), now.getMonth() + i, 1);
  const month1 = theMonths[future.getMonth()];
  const year1 = future.getFullYear();
  this.selectMonth.push({id: future.getMonth(), month: month1 + ' ' + year1});
}
  console.log(this.selectMonth);

}


confirm(): void {
  this.notification.create('success', '', 'Successfully saved menu!',
    {
      nzStyle: {backgroundColor: 'green', color: 'white' },
      nzClass: ''
    }
  );


}

}
