import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  endpointBase = environment.endpointBase;
  constructor(
     private _httpClient: HttpClient,
    private _router: Router
  ) { }

getAllEvents() {
    return this._httpClient.get(this.endpointBase.concat("Events/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addEvent(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Events/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateEvent(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Events/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteEvent(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Events/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

  getAllEventTypes() {
    return this._httpClient.get(this.endpointBase.concat("EventTypes/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addEventType(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("EventTypes/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateEventType(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("EventTypes/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteEventType(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("EventTypes/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

}
