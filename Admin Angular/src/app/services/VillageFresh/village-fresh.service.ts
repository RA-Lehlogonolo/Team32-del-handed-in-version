import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VillageFreshService {

  endpointBase = environment.endpointBase;
  constructor(
     private _httpClient: HttpClient,
    private _router: Router
  ) { }

getAllMenuTypes() {
    return this._httpClient.get(this.endpointBase.concat("MenuType/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addMenuType(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("MenuType/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateMenuType(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("MenuType/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteMenuType(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("MenuType/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }


  getAllMealTypes() {
    return this._httpClient.get(this.endpointBase.concat("MealType/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addMealType(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("MealType/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateMealType(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("MealType/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteMealType(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("MealType/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

  getAllItemTypes() {
    return this._httpClient.get(this.endpointBase.concat("ItemType/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addItemType(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("ItemType/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateItemType(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("ItemType/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteItemType(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("ItemType/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

  getAllItems() {
    return this._httpClient.get(this.endpointBase.concat("Item/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addItem(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Item/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateItem(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Item/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteItem(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Item/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

  getAllDays() {
    return this._httpClient.get(this.endpointBase.concat("Day/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
  addDay(payload, username: string) {
    return this._httpClient.post(this.endpointBase.concat("Day/" + username),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  updateDay(payload, username: string, id:number) {
    return this._httpClient.put(this.endpointBase.concat("Day/" + username + "/"+id),
      payload,
      { reportProgress: true, observe: 'events' });
  }
  deleteDay(username: string, id:number) {
    return this._httpClient.delete(this.endpointBase.concat("Day/" + username + "/"+id),
      { reportProgress: true, observe: 'events' });
  }

}
