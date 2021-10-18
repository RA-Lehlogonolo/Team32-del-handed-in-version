import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import { NzCalendarMode } from 'ng-zorro-antd/calendar';
import 'fullcalendar';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';


@Component({
  selector: 'app-view-events',
  templateUrl: './view-events.component.html',
  styleUrls: ['./view-events.component.css']
})
export class ViewEventsComponent implements OnInit {
  modalInfo: any;
  events: any;
  isViewEventVisible: boolean;

  constructor() { }
  mode: NzCalendarMode = 'month';
  calendarOptions: CalendarOptions;
  calendarPlugins = [dayGridPlugin, interactionPlugin];


  ngOnInit(): void {
    this.getEvents();
  }

  getEvents() {

    this.events = [
      {
        title: 'TuksVillage Seminar',
        eventType: "Seminar",
        date: '2021-06-27',
        start: '2021-06-27T10:00:00',
        end: '2021-06-27T16:00:00',
        id: "1",
      },
      {
        title: 'TuksVilage Sports Day',
        eventType: "Sport",
        date: '2021-06-29',
        start: '2021-06-29T10:00:00',
        end: '2021-06-29T16:00:00',
        id: "1"
      }

    ]
    this.calendarOptions = {
      headerToolbar: { center: 'dayGridMonth,dayGridWeek,dayGridDay,listMonth' }, // buttons for switching between views

      initialView: "dayGridMonth",
      events: this.events,
      themeSystem: 'bootstrap',
      dayMaxEvents: true,
         eventTimeFormat: {
        hour: '2-digit',
        minute: '2-digit',
        meridiem: true
      },
      eventClick: this.handleDateClick.bind(this),
      
      buttonText: {

        today: 'Go to Today',

      }

    };



  }

  handleDateClick(arg) {
    this.modalInfo = arg;
    this.isViewEventVisible = true;
  }

  handleCloseViewModal() {
    this.isViewEventVisible = false;

  }

}

