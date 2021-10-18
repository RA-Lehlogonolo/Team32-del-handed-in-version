import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  endpointBase = environment.endpointBase;
  constructor(
    private _httpClient: HttpClient,
    private _router: Router
  ) { }


  getAllResidenceAuditLogs() {
    return this._httpClient.get(this.endpointBase.concat("Logs/ResidenceLog/GetAll"),
      { reportProgress: true, observe: 'events' });
  }
}
