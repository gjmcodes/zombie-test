import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Resource } from 'src/core/models/resource';
import { ResourceDataService } from '../services/resource-data.service';

@Component({
  selector: 'app-resources-edit',
  templateUrl: './resources-edit.component.html',
  styleUrls: ['./resources-edit.component.scss']
})
export class ResourcesEditComponent implements OnInit {

  model: Resource = new Resource();
  resourceForm: any;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private resourcesDataService: ResourceDataService,
    private formBuilder: FormBuilder
  ) { }

  async ngOnInit() {
    let id = this.activatedRoute.snapshot.paramMap.get('id');
    let result = await this.resourcesDataService.getResourceAsync(id);
    this.model = result;
  }

  async onSubmit() {
    let result = await this.resourcesDataService.putResourcesAsync(this.model);
    if (!result.hasErrors)
      this.router.navigate(['/resources']);
  }
}
