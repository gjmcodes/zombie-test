import { Injectable } from '@angular/core';
import { ApiService } from 'src/core/data/api.service';
import { Resource } from 'src/core/models/resource';
import { OperationResult } from 'src/core/operations/operation-result';

const endpoint = "resource/";

@Injectable({
  providedIn: 'root'
})


export class ResourceDataService {

  constructor(private api: ApiService) { }

  async getResourcesAsync(): Promise<Resource[]> {
    debugger
    var request = await this.api.get(endpoint);

    if (request.hasErrors) return null;

    return request.data;
  }

  async postResourcesAsync(resource: Resource): Promise<OperationResult> {
    var request = await this.api.post(endpoint, resource);

    return request;
  }

  async deleteResourcesAsync(resourceId: any): Promise<OperationResult> {
    var request = await this.api.delete(endpoint + resourceId);
    
    return request;
  }
}
