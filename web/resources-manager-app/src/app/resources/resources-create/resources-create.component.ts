import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Resource } from 'src/core/models/resource';
import { ResourceDataService } from '../services/resource-data.service';

@Component({
  selector: 'app-resources-create',
  templateUrl: './resources-create.component.html',
  styleUrls: ['./resources-create.component.scss']
})
export class ResourcesCreateComponent implements OnInit {

  model: Resource = new Resource();
  form: FormGroup;
  constructor(private resourceDataService: ResourceDataService,
    private router: Router) { }

  ngOnInit(): void {
  }

  async onSubmit() {
    let result = await this.resourceDataService.postResourcesAsync(this.model);
    if (result.hasErrors) {
      result.validationResult.errors.forEach(error => {
        if (error.propertyName.toLocaleLowerCase() == "name") {
          this.form.controls.name.setErrors(null);
        }
      });
    } else {
      this.router.navigate(['/resources'])
    }
  }
}
