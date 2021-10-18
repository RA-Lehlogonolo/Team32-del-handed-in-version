import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdministrationService {

  endpointBase = environment.endpointBase;
  constructor(
    private _httpClient: HttpClient,
    private _router: Router
  ) { }


  getAllUserRoles() {
    return this._httpClient.get(this.endpointBase.concat("Administration/Roles/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addUserRole(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Administration/Roles/Add/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateUserRole(payload, username: string, id: string) {
    return this._httpClient.put(this.endpointBase.concat("Administration/Roles/Update/" + username + "/" + id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deletetUserRole(username: string,id: string) {
    return this._httpClient.delete(this.endpointBase.concat("Administration/Roles/Delete/" + username + "/" + id),
      { reportProgress: true, observe: 'events' });
  }

  getAllStudentRoles() {
    return this._httpClient.get(this.endpointBase.concat("Administration/StudentRole/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addStudentRole(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Administration/StudentRole/Add/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateStudentRole(payload, username: string, id: number) {
    return this._httpClient.put(this.endpointBase.concat("Administration/StudentRole/Update/" + username + "/" + id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteStudentRole(username: string,id: number) {
    return this._httpClient.delete(this.endpointBase.concat("Administration/StudentRole/Delete/" + username + "/" + id),
      { reportProgress: true, observe: 'events' });
  }

}
