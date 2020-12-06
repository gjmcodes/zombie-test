import { Injectable } from '@angular/core';
import { ApiService } from 'src/core/data/api.service';
import { Resource } from 'src/core/models/resource';

@Injectable({
  providedIn: 'root'
})
export class ResourceDataService {

  constructor(private api: ApiService) { }

  async getResourcesAsync(): Promise<Resource[]> {

    var request = await this.api.get("resource");
    
    if (!request.success) return null;

      return request.data;
  }

}
