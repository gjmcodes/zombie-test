import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Resource } from 'src/core/models/resource';
import { ResourceDataService } from '../services/resource-data.service';

@Component({
  selector: 'app-resources-index',
  templateUrl: './resources-index.component.html',
  styleUrls: ['./resources-index.component.scss']
})
export class ResourcesIndexComponent implements OnInit {

  resources: Resource[];

  constructor(private resourceDataService: ResourceDataService,
    private router: Router) { }

  async ngOnInit() {
    await this.loadResourcesAsync();
  }

  async loadResourcesAsync() {
    this.resources = await this.resourceDataService.getResourcesAsync();
  }
  newResource() {
    this.router.navigate(['/resources/create']);
  }

  editResource() {
    this.router.navigate(['/resources/edit']);
  }

  async deleteAsync(resource: Resource) {
    var result = await this.resourceDataService.deleteResourcesAsync(resource.id);
    if (!result.hasErrors) await this.loadResourcesAsync();
  }

}
