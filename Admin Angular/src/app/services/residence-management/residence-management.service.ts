import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ResidenceManagementService {

  endpointBase = environment.endpointBase;
  constructor(
    private _httpClient: HttpClient,
    private _router: Router
  ) { }




  getAllResidenceTypes() {
    return this._httpClient.get(this.endpointBase.concat("ResidenceTypes/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addResidenceType(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("ResidenceTypes/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateResidenceType(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("ResidenceTypes/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteResidenceType(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("ResidenceTypes/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

  getAllResidences() {
    return this._httpClient.get(this.endpointBase.concat("Residences/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addResidence(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Residences/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateResidence(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Residences/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteResidence(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Residences/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

  getAllBlocks() {
    return this._httpClient.get(this.endpointBase.concat("Blocks/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  uploadRoomsCSV(payload) {
    return this._httpClient.post(this.endpointBase.concat("Uploads/Rooms/Upload"),
      payload, { reportProgress: true, observe: 'events' });
  }
  addRoomsInCSV(payload, username: string, blockId:number) {
    return this._httpClient.post(this.endpointBase.concat("Rooms/AddMultiple/" + username+"/"+blockId),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  addBlock(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Blocks/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateBlock(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Blocks/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteBlock(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Blocks/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }


}
