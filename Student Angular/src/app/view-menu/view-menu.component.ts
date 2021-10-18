import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/core';
import 'fullcalendar';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';

@Component({
  selector: 'app-view-menu',
  templateUrl: './view-menu.component.html',
  styleUrls: ['./view-menu.component.css']
})
export class ViewMenuComponent implements OnInit {
  menu: any;
  calendarOptions: CalendarOptions;
  calendarPlugins = [dayGridPlugin, interactionPlugin];

  modalInfo: any;
  isViewMenuVisible: boolean;
  constructor() { }

  ngOnInit(): void {
    this.getMenu();
  }



  getMenu() {

    this.menu = [
      {
        title: 'Day 12',
        start: '2021-06-21',
        vegeterianLunch: 'Vegeterian strips, Tortilla, Yoghurt sauce',
        standardLunch:'Crumbed chicken strips, Tortilla, Yoghurt sauce',
        tuksResLunch:"Beef Stir-fry,Tortilla,Yoghurt sauce",
        vegeterianSupper:'Springrolls, Peas, Rice',
        standardSupper:'Chicken Leg,Rice, French Salad & dressing',
        tuksResSupper:'Wors, Rice, French Salad & dressing',
        allDay: true,
        id: "1",
        icon: "eye"
      },
      {
        title: 'Day 13',
        start: '2021-06-22',
        vegeterianLunch: 'Vegeterian strips, Tortilla, Yoghurt sauce',
        standardLunch:'Crumbed chicken strips, Tortilla, Yoghurt sauce',
        tuksResLunch:"Beef Stir-fry,Tortilla,Yoghurt sauce",
        vegeterianSupper:'Springrolls, Peas, Rice',
        standardSupper:'Chicken Leg,Rice, French Salad & dressing',
        tuksResSupper:'Wors, Rice, French Salad & dressing',
        allDay: true,
        id: "1",
        icon: "eye"
      },
      {
        title: 'Day 14',
        start: '2021-06-23',
        vegeterianLunch: 'Vegeterian strips, Tortilla, Yoghurt sauce',
        standardLunch:'Crumbed chicken strips, Tortilla, Yoghurt sauce',
        tuksResLunch:"Beef Stir-fry,Tortilla,Yoghurt sauce",
        vegeterianSupper:'Springrolls, Peas, Rice',
        standardSupper:'Chicken Leg,Rice, French Salad & dressing',
        tuksResSupper:'Wors, Rice, French Salad & dressing',
        allDay: true,
        id: "1",
        icon: "eye"
      },
      {
        title: 'Day 15',
        start: '2021-06-24',
        vegeterianLunch: 'Vegeterian strips, Tortilla, Yoghurt sauce',
        standardLunch:'Crumbed chicken strips, Tortilla, Yoghurt sauce',
        tuksResLunch:"Beef Stir-fry,Tortilla,Yoghurt sauce",
        vegeterianSupper:'Springrolls, Peas, Rice',
        standardSupper:'Chicken Leg,Rice, French Salad & dressing',
        tuksResSupper:'Wors, Rice, French Salad & dressing',
        allDay: true,
        id: "1",
        icon: "eye"
      },
      {
        title: 'Day 16',
        start: '2021-06-25',
        vegeterianLunch: 'Vegeterian strips, Tortilla, Yoghurt sauce',
        standardLunch:'Crumbed chicken strips, Tortilla, Yoghurt sauce',
        tuksResLunch:"Beef Stir-fry,Tortilla,Yoghurt sauce",
        vegeterianSupper:'Springrolls, Peas, Rice',
        standardSupper:'Chicken Leg,Rice, French Salad & dressing',
        tuksResSupper:'Wors, Rice, French Salad & dressing',
        allDay: true,
        id: "1",
        icon: "eye"
      },
      {
        title: 'Weekend A',
        start: '2021-06-26',
        vegeterianLunch: 'Vegeterian strips, Tortilla, Yoghurt sauce',
        standardLunch:'Crumbed chicken strips, Tortilla, Yoghurt sauce',
        tuksResLunch:"Beef Stir-fry,Tortilla,Yoghurt sauce",
        vegeterianSupper:'Springrolls, Peas, Rice',
        standardSupper:'Chicken Leg,Rice, French Salad & dressing',
        tuksResSupper:'Wors, Rice, French Salad & dressing',
        allDay: true,
        id: "1",
        icon: "eye"
      },
      {
        title: 'Weekend A',
        start: '2021-06-27',
        vegeterianLunch: 'Vegeterian strips, Tortilla, Yoghurt sauce',
        standardLunch:'Crumbed chicken strips, Tortilla, Yoghurt sauce',
        tuksResLunch:"Beef Stir-fry,Tortilla,Yoghurt sauce",
        vegeterianSupper:'Springrolls, Peas, Rice',
        standardSupper:'Chicken Leg,Rice, French Salad & dressing',
        tuksResSupper:'Wors, Rice, French Salad & dressing',
        allDay: true,
        id: "1",
        icon: "eye"
      }

    ]
    this.calendarOptions = {
      // headerToolbar: { center: 'dayGridWeek' }, 

      initialView: "dayGridWeek",
      firstDay: 1,
      events: this.menu,
      height:'auto',
      themeSystem: 'bootstrap',
      dayMaxEvents: true,
      eventTimeFormat: {
        hour: '2-digit',
        minute: '2-digit',
        meridiem: true
      },
      eventClick: this.handleDateClick.bind(this),
      eventContent: (args, createElement) => {
        const icon = args.event.extendedProps.img;
        const text = "<em class='far fa-" + icon + "'></em> " + args.event.title;
        return {
          html: text
        };
      },

      buttonText: {

        today: 'Go to Today',

      }

    };



  }

  handleDateClick(arg) {
    this.modalInfo = arg;
    console.log(this.modalInfo)
    this.isViewMenuVisible = true;
  }

  handleCloseViewModal() {
    this.isViewMenuVisible = false;

  }

}
