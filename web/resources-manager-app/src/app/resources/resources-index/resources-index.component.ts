import { Component, OnInit } from '@angular/core';
import { Resource } from 'src/core/models/resource';
import { ResourceDataService } from '../services/resource-data.service';

@Component({
  selector: 'app-resources-index',
  templateUrl: './resources-index.component.html',
  styleUrls: ['./resources-index.component.scss']
})
export class ResourcesIndexComponent implements OnInit {

  resources: Resource[];

  constructor(private resourceDataService: ResourceDataService) { }

  async ngOnInit() {
    this.resources = await this.resourceDataService.getResourcesAsync();
  }

}
