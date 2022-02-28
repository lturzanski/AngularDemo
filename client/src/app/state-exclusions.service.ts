import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, throwError } from 'rxjs';

import { ConfigService } from './config.service';
import { ODataClient } from './odata-client';
import * as models from './state-exclusions.model';

@Injectable()
export class StateExclusionsService {
  odata: ODataClient;
  basePath: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.basePath = config.get('stateExclusions');
    this.odata = new ODataClient(this.http, this.basePath, { legacy: false, withCredentials: true });
  }

  getStateExclExclusions(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/StateExclExclusions`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createStateExclExclusion(expand: string | null, stateExclExclusion: models.StateExclExclusion | null) : Observable<any> {
    return this.odata.post(`/StateExclExclusions`, stateExclExclusion, { expand }, []);
  }

  deleteStateExclExclusion(id: number | null) : Observable<any> {
    return this.odata.delete(`/StateExclExclusions(${id})`, item => !(item.Id == id));
  }

  getStateExclExclusionById(expand: string | null, id: number | null) : Observable<any> {
    return this.odata.getById(`/StateExclExclusions(${id})`, { expand });
  }

  updateStateExclExclusion(expand: string | null, id: number | null, stateExclExclusion: models.StateExclExclusion | null) : Observable<any> {
    return this.odata.patch(`/StateExclExclusions(${id})`, stateExclExclusion, item => item.Id == id, { expand }, []);
  }

  getStateExclExclusionDates(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/StateExclExclusionDates`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createStateExclExclusionDate(expand: string | null, stateExclExclusionDate: models.StateExclExclusionDate | null) : Observable<any> {
    return this.odata.post(`/StateExclExclusionDates`, stateExclExclusionDate, { expand }, ['StateExclExclusion']);
  }

  deleteStateExclExclusionDate(id: number | null) : Observable<any> {
    return this.odata.delete(`/StateExclExclusionDates(${id})`, item => !(item.Id == id));
  }

  getStateExclExclusionDateById(expand: string | null, id: number | null) : Observable<any> {
    return this.odata.getById(`/StateExclExclusionDates(${id})`, { expand });
  }

  updateStateExclExclusionDate(expand: string | null, id: number | null, stateExclExclusionDate: models.StateExclExclusionDate | null) : Observable<any> {
    return this.odata.patch(`/StateExclExclusionDates(${id})`, stateExclExclusionDate, item => item.Id == id, { expand }, ['StateExclExclusion']);
  }

  getStateExclStates(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/StateExclStates`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createStateExclState(expand: string | null, stateExclState: models.StateExclState | null) : Observable<any> {
    return this.odata.post(`/StateExclStates`, stateExclState, { expand }, []);
  }

  deleteStateExclState(id: number | null) : Observable<any> {
    return this.odata.delete(`/StateExclStates(${id})`, item => !(item.Id == id));
  }

  getStateExclStateById(expand: string | null, id: number | null) : Observable<any> {
    return this.odata.getById(`/StateExclStates(${id})`, { expand });
  }

  updateStateExclState(expand: string | null, id: number | null, stateExclState: models.StateExclState | null) : Observable<any> {
    return this.odata.patch(`/StateExclStates(${id})`, stateExclState, item => item.Id == id, { expand }, []);
  }

  getStateExclStateExclusions(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/StateExclStateExclusions`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createStateExclStateExclusion(expand: string | null, stateExclStateExclusion: models.StateExclStateExclusion | null) : Observable<any> {
    return this.odata.post(`/StateExclStateExclusions`, stateExclStateExclusion, { expand }, ['StateExclState', 'StateExclExclusion']);
  }

  deleteStateExclStateExclusion(id: number | null) : Observable<any> {
    return this.odata.delete(`/StateExclStateExclusions(${id})`, item => !(item.Id == id));
  }

  getStateExclStateExclusionById(expand: string | null, id: number | null) : Observable<any> {
    return this.odata.getById(`/StateExclStateExclusions(${id})`, { expand });
  }

  updateStateExclStateExclusion(expand: string | null, id: number | null, stateExclStateExclusion: models.StateExclStateExclusion | null) : Observable<any> {
    return this.odata.patch(`/StateExclStateExclusions(${id})`, stateExclStateExclusion, item => item.Id == id, { expand }, ['StateExclState','StateExclExclusion']);
  }

  getStateExclusionViews(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/StateExclusionViews`, { filter, top, skip, orderby, count, expand, format, select });
  }
}
