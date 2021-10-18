import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CampusManagementService {

  endpointBase = environment.endpointBase;
  constructor(
    private _httpClient: HttpClient,
    private _router: Router
  ) { }


  getAllCampuses() {
    return this._httpClient.get(this.endpointBase.concat("Campuses/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addCampus(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Campuses/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateCampus(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Campuses/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteCampus(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Campuses/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

  getAllFaculties() {
    return this._httpClient.get(this.endpointBase.concat("Faculties/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addFaculty(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Faculties/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateFaculty(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Faculties/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteFaculty(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Faculties/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }
}
