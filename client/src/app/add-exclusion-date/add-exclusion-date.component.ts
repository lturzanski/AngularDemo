import { Component, Injector } from '@angular/core';
import { AddExclusionDateGenerated } from './add-exclusion-date-generated.component';

@Component({
  selector: 'page-add-exclusion-date',
  templateUrl: './add-exclusion-date.component.html'
})
export class AddExclusionDateComponent extends AddExclusionDateGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
