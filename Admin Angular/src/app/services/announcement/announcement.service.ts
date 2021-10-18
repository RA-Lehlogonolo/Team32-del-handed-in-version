import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {

  endpointBase = environment.endpointBase;
  constructor(
    private _httpClient: HttpClient,
    private _router: Router
  ) { }

  getAllAnnouncementTypes() {
    return this._httpClient.get(this.endpointBase.concat("AnnouncementTypes/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addAnnouncementType(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("AnnouncementTypes/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateAnnouncementType(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("AnnouncementTypes/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteAnnouncementType(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("AnnouncementTypes/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

getAllAnnouncements() {
    return this._httpClient.get(this.endpointBase.concat("Announcements/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addAnnouncement(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Announcements/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateAnnouncement(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Announcements/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteAnnouncement(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Announcements/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }



}
