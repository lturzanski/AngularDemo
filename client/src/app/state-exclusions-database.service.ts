import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, throwError } from 'rxjs';

import { ConfigService } from './config.service';
import { ODataClient } from './odata-client';
import * as models from './state-exclusions-database.model';

@Injectable()
export class StateExclusionsDatabaseService {
  odata: ODataClient;
  basePath: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.basePath = config.get('stateExclusionsDatabase');
    this.odata = new ODataClient(this.http, this.basePath, { legacy: false, withCredentials: true });
  }

  getExclusions(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Exclusions`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createExclusion(expand: string | null, exclusion: models.Exclusion | null) : Observable<any> {
    return this.odata.post(`/Exclusions`, exclusion, { expand }, []);
  }

  deleteExclusion(id: number | null) : Observable<any> {
    return this.odata.delete(`/Exclusions(${id})`, item => !(item.Id == id));
  }

  getExclusionById(expand: string | null, id: number | null) : Observable<any> {
    return this.odata.getById(`/Exclusions(${id})`, { expand });
  }

  updateExclusion(expand: string | null, id: number | null, exclusion: models.Exclusion | null) : Observable<any> {
    return this.odata.patch(`/Exclusions(${id})`, exclusion, item => item.Id == id, { expand }, []);
  }

  getExclusionDates(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/ExclusionDates`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createExclusionDate(expand: string | null, exclusionDate: models.ExclusionDate | null) : Observable<any> {
    return this.odata.post(`/ExclusionDates`, exclusionDate, { expand }, ['Exclusion']);
  }

  deleteExclusionDate(id: number | null) : Observable<any> {
    return this.odata.delete(`/ExclusionDates(${id})`, item => !(item.Id == id));
  }

  getExclusionDateById(expand: string | null, id: number | null) : Observable<any> {
    return this.odata.getById(`/ExclusionDates(${id})`, { expand });
  }

  updateExclusionDate(expand: string | null, id: number | null, exclusionDate: models.ExclusionDate | null) : Observable<any> {
    return this.odata.patch(`/ExclusionDates(${id})`, exclusionDate, item => item.Id == id, { expand }, ['Exclusion']);
  }

  getStates(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/States`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createState(expand: string | null, state: models.State | null) : Observable<any> {
    return this.odata.post(`/States`, state, { expand }, []);
  }

  deleteState(id: number | null) : Observable<any> {
    return this.odata.delete(`/States(${id})`, item => !(item.Id == id));
  }

  getStateById(expand: string | null, id: number | null) : Observable<any> {
    return this.odata.getById(`/States(${id})`, { expand });
  }

  updateState(expand: string | null, id: number | null, state: models.State | null) : Observable<any> {
    return this.odata.patch(`/States(${id})`, state, item => item.Id == id, { expand }, []);
  }

  getStateExclusions(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/StateExclusions`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createStateExclusion(expand: string | null, stateExclusion: models.StateExclusion | null) : Observable<any> {
    return this.odata.post(`/StateExclusions`, stateExclusion, { expand }, ['State', 'Exclusion']);
  }

  deleteStateExclusion(id: number | null) : Observable<any> {
    return this.odata.delete(`/StateExclusions(${id})`, item => !(item.Id == id));
  }

  getStateExclusionById(expand: string | null, id: number | null) : Observable<any> {
    return this.odata.getById(`/StateExclusions(${id})`, { expand });
  }

  updateStateExclusion(expand: string | null, id: number | null, stateExclusion: models.StateExclusion | null) : Observable<any> {
    return this.odata.patch(`/StateExclusions(${id})`, stateExclusion, item => item.Id == id, { expand }, ['State','Exclusion']);
  }

  getStateExclusionViews(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/StateExclusionViews`, { filter, top, skip, orderby, count, expand, format, select });
  }
}
