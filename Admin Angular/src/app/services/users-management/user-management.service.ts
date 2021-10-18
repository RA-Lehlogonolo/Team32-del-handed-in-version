import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserManagementService {
  getAllBuildingCoordinator() {
    throw new Error('Method not implemented.');
  }

  endpointBase = environment.endpointBase;
  constructor(
    private _httpClient: HttpClient,
    private _router: Router
  ) { }


  getAllHouseParents() {
    return this._httpClient.get(this.endpointBase.concat("HouseParents/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addHouseParent(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("HouseParents/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateHouseParent(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("HouseParents/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteHouseParent(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("HouseParents/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }
  resendHouseParentAccountCreatedNotification(houseParentId:number) {
    return this._httpClient.get(this.endpointBase.concat("HouseParents/ResendAccountCreatedNotification/"+houseParentId),
      { reportProgress: true, observe: 'events' });
  }

  getAllStudents() {
    return this._httpClient.get(this.endpointBase.concat("Students/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addIndividualStudent(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Students/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateStudent(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Students/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteStudent(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Students/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }
  resendStudentAccountCreatedNotification(studentId:number) {
    return this._httpClient.get(this.endpointBase.concat("Students/ResendAccountCreatedNotification/"+studentId),
      { reportProgress: true, observe: 'events' });
  }

  uploadStudentsCSV(payload) {
    return this._httpClient.post(this.endpointBase.concat("Uploads/Students/Upload"),
      payload, { reportProgress: true, observe: 'events' });
  }

  addStudentsInCSV(payload, username: string, residenceId:number) {
    return this._httpClient.post(this.endpointBase.concat("Students/AddMultiple/" + username+"/"+residenceId),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  
getAllBuildingCoordinators() {
    return this._httpClient.get(this.endpointBase.concat("BuildingCoordinators/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addBuildingCoordinator(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("BuildingCoordinators/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateBuildingCoordinator(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("BuildingCoordinators/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteBuildingCoordinator(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("BuildingCoordinators/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }
  resendBuildingCoordinatorAccountCreatedNotification(BuildingCoordinatorId:number) {
    return this._httpClient.get(this.endpointBase.concat("BuildingCoordinator/ResendAccountCreatedNotification/"+BuildingCoordinatorId),
      { reportProgress: true, observe: 'events' });
  }


}
