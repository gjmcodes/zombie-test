import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { OperationResult } from '../operations/operation-result';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ApiService {


  constructor(public http: HttpClient,
    private router: Router) {
  }

  async get(endpoint: string, params?: any, reqOpts?: any): Promise<OperationResult> {
    if (!reqOpts) {
      reqOpts = {
        params: new HttpParams()
      };
    }

    // Support easy query params for GET requests
    if (params) {
      reqOpts.params = new HttpParams();
      for (let k in params) {
        reqOpts.params = reqOpts.params.set(k, params[k]);
      }
    }
    let data = await this.http.get(environment.API_URL + endpoint, {
    }).toPromise();

    return this.toOperationResult(data);
  }

  async post(endpoint: string, body: any, reqOpts?: any): Promise<OperationResult> {
    let data = await this.http.post<OperationResult>(environment.API_URL + endpoint, body, reqOpts)
      .toPromise();

    return await this.toOperationResult(data);
  }

  async put(endpoint: string, body: any, reqOpts?: any): Promise<OperationResult> {
    let data = await this.http.put<HttpResponse<OperationResult>>(environment.API_URL + endpoint, body, reqOpts)
      .toPromise();
    return this.toOperationResult(data);
  }

  async delete(endpoint: string, reqOpts?: any): Promise<OperationResult> {
    let data = await this.http.delete<HttpResponse<OperationResult>>(environment.API_URL + endpoint, reqOpts)
      .toPromise();

    return this.toOperationResult(data);
  }

  async patch(endpoint: string, body: any, reqOpts?: any): Promise<OperationResult> {
    let data = this.http.patch(environment.API_URL + endpoint, body, reqOpts);
    return this.toOperationResult(data);
  }

  toOperationResult(data: any): OperationResult {

    let json = JSON.parse(JSON.stringify(data));

    return new OperationResult(json.success, json.message, json.extraMessages, json.data);
  }
}
