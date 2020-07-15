import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


/**
 * @title Basic select
 */
@Component({
  selector: 'app-resource-type',
  templateUrl: './resource-type.component.html',
  styleUrls: ['./resource-type.component.css'],
})
export class ResourceTypeComponent {

  public resourceTypes: ResourceType[];


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ResourceType[]>(baseUrl + 'api/FHIRResource').subscribe(result => {
      this.resourceTypes = result;
    }, error => console.error(error));
  }
}

interface ResourceType {
  value: string;
  //viewValue: string;
}
