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

    let result = await this.http.get(environment.API_URL + endpoint, {
    }).toPromise()
      .then(res => { return this.toOkRequestResult(res) })
      .catch(err => { return this.catchPromiseError(err) });

    return result;
  }

  async post(endpoint: string, body: any, reqOpts?: any): Promise<OperationResult> {
    let result = await this.http.post<OperationResult>(environment.API_URL + endpoint, body, reqOpts)
      .toPromise()
      .then(res => { return this.toOkRequestResult(res) })
      .catch(err => { return this.catchPromiseError(err) });

    return result;
  }

  async put(endpoint: string, body: any, reqOpts?: any): Promise<OperationResult> {
    let result = await this.http.put<HttpResponse<OperationResult>>(environment.API_URL + endpoint, body, reqOpts)
      .toPromise()
      .then(res => { return this.toOkRequestResult(res) })
      .catch(err => { return this.catchPromiseError(err) });

    return result;
  }

  async delete(endpoint: string, reqOpts?: any): Promise<OperationResult> {
    let result = await this.http.delete<HttpResponse<OperationResult>>(environment.API_URL + endpoint)
      .toPromise()
      .then(res => { return this.toOkRequestResult(res) })
      .catch(err => { return this.catchPromiseError(err) });

    return result;
  }

  async patch(endpoint: string, body: any, reqOpts?: any): Promise<OperationResult> {
    let result = this.http.patch(environment.API_URL + endpoint, body, reqOpts)
      .toPromise()
      .then(res => { return this.toOkRequestResult(res) })
      .catch(err => { return this.catchPromiseError(err) });

    return result;
  }

  catchPromiseError(promise: any) {
    if (promise.status == 400) return this.toBadRequestResult(promise);
  }

  toOkRequestResult(promise: any): OperationResult {
    return new OperationResult(null, false, promise);
  }

  toBadRequestResult(promise: any): OperationResult {

    return new OperationResult(promise.validationResult, promise.hasErrors, promise.data);
  }
}
